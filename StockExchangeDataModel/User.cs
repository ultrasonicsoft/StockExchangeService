﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockExchangeDataModel
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
