using PipelineFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineApp
{
    public class SalesOrderPipelineEvent:PipelineEvent
    {
        [PipelineEvent(Order = 0, TransactionScopeOption = TransactionScopeOption.Required)]
        public PipelineDelegate<SalesOrderPipelineContext> ValidateCustomer { get; set; }

        [PipelineEvent(Order = 1, TransactionScopeOption = TransactionScopeOption.Required)]
        public PipelineDelegate<SalesOrderPipelineContext> AdjustInventory { get; set; }

    }
}
