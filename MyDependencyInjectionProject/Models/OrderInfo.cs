using System;
using System.Collections.Generic;
using System.Text;

namespace MyDependencyInjectionProject.Models
{
    public class OrderInfo
    {
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Product { get; set; }
        public int Price { get; set; }
        public string CreditCardNumber { get; set; }

    }
}
