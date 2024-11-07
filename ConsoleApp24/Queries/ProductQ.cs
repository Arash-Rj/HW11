using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11.Queries
{
    public static class ProductQ
    {
        public static string _create = "INSERT INTO Products (Name,CategoryId,Price) values (@Name,@CategoryId,@Price);";
        public static string _GetById = "SELECT * FROM Products WHERE Id = @Id";
        public static string _GetAll = "SELECT * FROM Products";
        public static string _GetCategory = "SELECT * FROM Categories  WHERE Name = @NAME ";
        public static string _Update = "UPDATE Products SET Name=@Name ,CategoryId=@CategoryId , Price = @Price  WHERE Id = @Id";
        public static string _delete = "delete Products WHERE Id = @Id";
        public static string _getAllCat = "SELECT * FROM Categoreis";
    }
}
