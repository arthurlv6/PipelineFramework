using PipelineApp;
using System;
using System.Collections.Generic;

namespace PipelineApp
{
    public class StoreRepository: IStoreRepository
    {
        public StoreRepository()
        {
            var Stocks = new List<Stock>();
            Stocks.Add(new Stock() { Id = 1, Name = "Product1", Quantity=100});
            Stocks.Add(new Stock() { Id = 2, Name = "Product2", Quantity = 123 });
            Stocks.Add(new Stock() { Id = 3, Name = "Product3", Quantity = 23 });
        }
        public List<Stock> Stocks { get; set; }
    }
    public class Stock
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
