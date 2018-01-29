
using PipelineApp.Purchases;
using PipelineApp.Purchases.Modules;
using PipelineFramework;
using System;

namespace PipelineApp
{
    class PurchaseSupplier : PipelineModule<PurchasePipelineEvent>
    {
        public override void Initialize(PurchasePipelineEvent events)
        {
            events.ValidateSupplier += (context) =>
            {
                context.message = "Validate Supplier";
                Console.WriteLine("Validate Supplier");
            };
        }
    }
}
