using System;
using System.Collections.Generic;
using System.Text;

namespace AutoFixtureSample
{
    public class MyClass
    {
        public MyClass()
        {
            this.Orders = new List<Order>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public List<Order> Orders { get; set; }
    }

    public class Order
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}