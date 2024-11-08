using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp24.Entities
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public  int price { get; set; }
        public Product()
        {
            
        }
        public Product(int Id,string Name,string Category,int Price)
        {
            id = Id;
            name = Name;
            category = Category;
            price = Price;
        }
        public override string ToString()
        {
            return $"Name: {name} | Category: {category} - Price:{price}";
        }
    }
}
