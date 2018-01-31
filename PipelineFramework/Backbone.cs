
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Transactions;

namespace PipelineFramework
{
    //T  is like sales, purchase... event
    public class Backbone<E> where E : PipelineEvent,new()
    {
        public Backbone(IEnumerable<Type> types)
        {
            if (types == null) throw new Exception();

            var pipelineEvent = new E();

            foreach (var item in types)
            {
                object obj = Activator.CreateInstance(item);
                var module = (PipelineModule<E>)obj;
                module.Initialize(pipelineEvent);
            }
            PipelineEvent = pipelineEvent;
        }
        public E PipelineEvent { get; set; }
        public void Execute<C>(C context) where C: PipelineContext
        {
            PropertyInfo[] properties = PipelineEvent.GetType().GetProperties();

            List<PropertyInfo> sortedProperties = properties.ToList<PropertyInfo>();
            sortedProperties.Sort(new PropertyComparer());

            System.Transactions.TransactionScopeOption pipelineScopeOption = TransactionRequirement(sortedProperties);

            using (TransactionScope pipelineScope = new TransactionScope(pipelineScopeOption))
            {
                sortedProperties.ForEach(property =>
                {
                    
                    object[] attributes =
                        property.GetCustomAttributes(typeof(PipelineEventAttribute), true);

                    if (attributes.Length > 0)
                    {
                        PipelineEventAttribute attr = (PipelineEventAttribute)attributes[0];

                        System.Transactions.TransactionScopeOption scopeOption =
                            GetTransactionScopeOption(attr.TransactionScopeOption);

                        object value = property.GetValue(PipelineEvent, null);
                        Action<C> eventProp = (Action<C>)value;

                        if (eventProp != null)
                        {
                            using (TransactionScope eventScope = new TransactionScope(scopeOption))
                            {
                                if (eventProp != null)
                                {
                                    eventProp(context);
                                    if (context.Cancel == true) throw new Exception(property.Name + " failed.");
                                }
                                    
                                eventScope.Complete();
                            }
                        }
                    }
                });

                pipelineScope.Complete();
            }
        }
        private System.Transactions.TransactionScopeOption TransactionRequirement(List<PropertyInfo> sortedProperties)
        {
            System.Transactions.TransactionScopeOption pipelineScopeOption = System.Transactions.TransactionScopeOption.Suppress;

            foreach (PropertyInfo property in sortedProperties)
            {
                object[] attributes = property.GetCustomAttributes(typeof(PipelineEventAttribute), true);
                if (attributes.Length > 0)
                {
                    PipelineEventAttribute attr = (PipelineEventAttribute)attributes[0];
                    if (attr.TransactionScopeOption != TransactionScopeOption.Suppress)
                    {
                        pipelineScopeOption = System.Transactions.TransactionScopeOption.Required;
                        break;
                    }
                }
            }

            return pipelineScopeOption;
        }
        private System.Transactions.TransactionScopeOption GetTransactionScopeOption(TransactionScopeOption transactionScopeOption)
        {
            System.Transactions.TransactionScopeOption scopeOption = System.Transactions.TransactionScopeOption.Required;

            if (transactionScopeOption == TransactionScopeOption.RequiredNew)
                scopeOption = System.Transactions.TransactionScopeOption.RequiresNew;
            else if (transactionScopeOption == TransactionScopeOption.Suppress)
                scopeOption = System.Transactions.TransactionScopeOption.Suppress;

            return scopeOption;
        }
    }
}
