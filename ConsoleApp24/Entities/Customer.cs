using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp24.Entities
{
    public class Customer
    {
        public int id { get; set; }
        public string name { get; set; }
        public Customer(int Id,string Name)
        {
            Id  = id;
            Name = name;              
        }
        public Customer() { }
    }
}
