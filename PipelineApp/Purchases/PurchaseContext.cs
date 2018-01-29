using PipelineApp.Contexts;
using PipelineFramework;

namespace PipelineApp.Purchases
{
    public class PurchaseContext : PipelineContext
    {
        public IStoreRepository StoreRepository { get; set; }
        public IPaymentProcessor PaymentProcessor { get; set; }
        public IPurchaseRepository PurchaseRepository { get; set; }
        public string message { get; set; }
    }
}
