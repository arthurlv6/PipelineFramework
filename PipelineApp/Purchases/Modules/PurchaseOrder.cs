using PipelineFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineApp.Purchases.Modules
{
    public class PurchaseOrder : PipelineModule<PurchasePipelineEvent>
    {
        public override void Initialize(PurchasePipelineEvent events)
        {
            events.CreatePurchaseOrder += (context) =>
            {
                context.message = "Create Purchase Order";
                Console.WriteLine("Create Purchase Order");
            };
        }
    }
}
