using PipelineFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineApp.Purchases
{
    public class PurchasePipelineEvent : PipelineEvent
    {
        [PipelineEvent(Order = 0, TransactionScopeOption = TransactionScopeOption.Required)]
        public PipelineDelegate<PurchaseContext> ValidateSupplier { get; set; }

        [PipelineEvent(Order = 1, TransactionScopeOption = TransactionScopeOption.Required)]
        public PipelineDelegate<PurchaseContext> CreatePurchaseOrder { get; set; }

    }
}
