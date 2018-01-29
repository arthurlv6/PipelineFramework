
using PipelineFramework;

namespace PipelineApp
{
    public class SalesOrderPipelineContext: PipelineContext
    {
        public IStoreRepository StoreRepository { get; set; }
        public IPaymentProcessor PaymentProcessor { get; set; }
        public string message { get; set; }
    }
}
