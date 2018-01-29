
using PipelineApp.Purchases;
using PipelineApp.Purchases.Modules;
using PipelineFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PipelineApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Sales order example
                var pipelineContext = new SalesOrderPipelineContext()
                {
                    StoreRepository = new StoreRepository(),
                    PaymentProcessor = new PaymentProcessor(),
                };

                var modules = from type in Assembly.GetExecutingAssembly().GetTypes()
                              where typeof(ISalesOrder).IsAssignableFrom(type) && !type.IsInterface
                              select type;

                var backbone =new Backbone<SalesOrderPipelineEvent>(modules);

                backbone.Execute(pipelineContext);

                #region purchase
                /* Purchase example
                var purchasePipelineContext = new PurchaseContext()
                {
                    StoreRepository = new StoreRepository(),
                    PaymentProcessor = new PaymentProcessor(),
                };


                var backbonePurchase = new Backbone<PurchasePipelineEvent>(new List<Type>(){ typeof(PurchaseOrder), typeof(PurchaseSupplier) });

                backbonePurchase.Execute(purchasePipelineContext);
                */
                #endregion

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                Console.ReadKey();
            }
        }
    }
}
