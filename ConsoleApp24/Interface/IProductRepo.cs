using ConsoleApp24.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11.Interface
{
    public interface IProductRepo
    {
        void Add(Product item);
        Product Get(int id);
        List<Product> GetAll();
        void Update(Product user);
        int Delete(int id);
        List<Category> GetAllCategories();
    }
}
