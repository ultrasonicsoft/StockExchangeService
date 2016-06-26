using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockExchangeRepository.Model
{
    public class DbStock
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
