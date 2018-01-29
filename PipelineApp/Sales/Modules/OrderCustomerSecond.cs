using PipelineFramework;
using System;

namespace PipelineApp
{
    public class OrderCustomerSecond : PipelineModule<SalesOrderPipelineEvent>,ISalesOrder
    {
        public override void Initialize(SalesOrderPipelineEvent events)
        {
            events.ValidateCustomer += (context) =>
            {
                context.message = "ValidateCustomer 2";
                Console.WriteLine("ValidateCustomer 2");
            };
        }
    }
}
