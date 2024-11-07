using ConsoleApp24.Entities;
using HW11.Configuration;
using HW11.Interface;
using HW11.Queries;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace HW11.Repository
{
    public class DapperProductRepo : IProductRepo
    {
        public void Add(Product pro)
        {
            using (IDbConnection DataBase = new SqlConnection(DbConfig.ConnectionString))
            {
                Category C = DataBase.QueryFirstOrDefault<Category>(ProductQ._GetCategory, new { Name = pro._category});
                DataBase.Execute(ProductQ._create, new { pro._name, C._id, pro._price });
            }
        }

        public int Delete(int id)
        {
            using (IDbConnection DataBase = new SqlConnection(DbConfig.ConnectionString))
            {
               return DataBase.Execute(ProductQ._delete, new { Id = id });
            }
        }

        public Product? Get(int id)
        {
            using (IDbConnection DataBase = new SqlConnection(DbConfig.ConnectionString))
            {
                return DataBase.QueryFirstOrDefault<Product>(ProductQ._GetById, new { Id = id });
            }
        }

        public List<Product> GetAll()
        {
            using (IDbConnection DataBase = new SqlConnection(DbConfig.ConnectionString))
            {
                return DataBase.Query<Product>(ProductQ._GetAll).ToList();
            }
        }

        public List<Category> GetAllCategories()
        {
            using (IDbConnection DataBase = new SqlConnection(DbConfig.ConnectionString))
            {
                var categories = DataBase.Query<Category>(ProductQ._getAllCat).ToList();
                return categories;
            }
        }

        public void Update(Product pro)
        {
            using (IDbConnection DataBase = new SqlConnection(DbConfig.ConnectionString))
            {
                Category? C = DataBase.QueryFirstOrDefault<Category>
                    (ProductQ._GetCategory, new { Name = pro._category });
                DataBase.Execute(ProductQ._Update,new { Id = pro._id, Name = pro._name, CategoryId = C._id, Price = pro._price });
            }
        }
    }
}
