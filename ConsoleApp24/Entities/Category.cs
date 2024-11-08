using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp24.Entities
{
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public Category()
        {

        }
        public Category(int Id,string Name)
        {
            id = Id;
            name = Name;
        }
    }
}
