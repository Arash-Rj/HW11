using ConsoleApp24.Entities;
using HW11.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11.Interface
{
    public interface IProductService
    {
        Result CreatPro(string name,string Category,int price);
        List<Product> GetAllPro();
        Product GetProductById(int id);
        Result EditPro(Product product);
        Result DeletePro(int id);
    }

}
