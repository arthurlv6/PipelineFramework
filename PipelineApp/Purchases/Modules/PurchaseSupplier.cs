
using PipelineFramework;

namespace PipelineApp
{
    class PurchaseSupplier : IPurchase
    {
        public void Initialize(PipelineEvent events)
        {
            //events.AdjustInventory += (context) =>
            //{
            //    Console.WriteLine("purchase inventory");
            //};
        }

    }
}
