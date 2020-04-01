﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GenericHost1.DatabaseModel
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustumerID { get; set; }
        public int EmployeeID { get; set; }
        public string Description { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

    }
}
