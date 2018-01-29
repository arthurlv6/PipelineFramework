using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineFramework
{
    public class PipelineEventAttribute:Attribute
    {
        public int Order { get; set; }
        public TransactionScopeOption TransactionScopeOption { get; set; }
    }
}
