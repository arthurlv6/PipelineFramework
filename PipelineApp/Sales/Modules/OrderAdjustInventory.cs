using PipelineFramework;
using System;

namespace PipelineApp
{
    class OrderAdjustInventory : PipelineModule<SalesOrderPipelineEvent>, ISalesOrder
    {
        public override void Initialize(SalesOrderPipelineEvent events)
        {
            events.AdjustInventory += Logic;
        }
        public void Logic(SalesOrderPipelineContext context)
        {
            context.message = "AdjustInventory";
            Console.WriteLine("AdjustInventory");
        }
    }
}
