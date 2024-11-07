using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp24.Entities
{
    public class Product
    {
        public int _id { get; set; }
        public string _name { get; set; }
        public string _category { get; set; }
        public  int _price { get; set; }
        public Product()
        {
            
        }
        public override string ToString()
        {
            return $"Name: {_name} | Category: {_category} - Price:{_price}";
        }
    }
}
