
using PipelineFramework;
using System;
using System.Linq;
using System.Reflection;

namespace PipelineApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var pipelineContext = new SalesOrderPipelineContext()
                {
                    StoreRepository = new StoreRepository(),
                    PaymentProcessor = new PaymentProcessor(),
                };

                var modules = from type in Assembly.GetExecutingAssembly().GetTypes()
                              where typeof(ISalesOrder).IsAssignableFrom(type) && !type.IsInterface
                              select type;

                var backbone =new Backbone<SalesOrderPipelineEvent>(modules);

                backbone.Execute(pipelineContext);

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                Console.ReadKey();
            }
        }
    }
}
