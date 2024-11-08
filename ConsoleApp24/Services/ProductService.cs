using ConsoleApp24.Entities;
using HW11.Entities;
using HW11.Interface;
using HW11.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11.Services
{
    public  class ProductService : IProductService
    {
        IProductRepo _proRepo = new DapperProductRepo();
        public Result CreatPro(string name, string Category, int price)
        {
            Product newpro = new Product() { name = name, category = Category, price = price };
            _proRepo.Add(newpro);
            return new Result(true, "Product Successfuly Added.");
        }

        public Result DeletePro(int id)
        {
          int check =  _proRepo.Delete(id);
            if (check == 0)
            {
                return new Result(false, "Product was not found!");
            }
            else
                return new Result(true, "Product Removed");
        }

        public Result EditPro(Product product)
        {
            _proRepo.Update(product);
            return new Result(true, "Product Updated successfully.");
        }

        public List<Product> GetAllPro()
        {
            List<Product> prolist = _proRepo.GetAll();
   
            if(prolist.Count == 0)
            { throw new NullReferenceException(); }
            return prolist;
        }

        public Product GetProductById(int id)
        {
            Product pro = _proRepo.Get(id);
            if(pro == null)
            {  throw new NullReferenceException(); }
            return pro;
        }
        public List<Category> GetAllCategories()
        { return _proRepo.GetAllCategories(); }
    }
}
