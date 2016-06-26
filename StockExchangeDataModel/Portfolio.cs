﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockExchangeDataModel
{
    public class Portfolio
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public List<int> StockIds { get; set; }
    }
}
