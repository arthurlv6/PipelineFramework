using PipelineFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineApp
{
    public class OrderCustomer : PipelineModule<SalesOrderPipelineEvent>,ISalesOrder
    {
        public override void Initialize(SalesOrderPipelineEvent events)
        {
            events.ValidateCustomer += (context) =>
            {
                try
                {
                    context.message = "ValidateCustomer";
                    Console.WriteLine("ValidateCustomer");
                }
                catch (Exception)
                {
                    context.Cancel = true;
                }
            };
        }
    }
}
