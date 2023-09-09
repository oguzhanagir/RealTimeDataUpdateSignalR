﻿using RealTimeDataUpdate.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeDataUpdate.Entity.Concrete
{
    public class User:BaseEntity
    {
        public string UserName { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
    }
}
