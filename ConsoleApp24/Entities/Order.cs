using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp24.Entities
{
    public class Order
    {
        public int _id { get; set; }
        public int _customerId { get; set; }
        public int _productId { get; set; }
        public int _quantity { get; set; }
        public DateTime _orderDate { get; set; }
        public Order()
        {
            
        }
    }
}
