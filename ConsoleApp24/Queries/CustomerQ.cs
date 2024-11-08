using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11.Queries
{
    public static class CustomerQ
    {
        public static string _create = "INSERT INTO Customers (Name) values (@Name);";
        public static string _GetById = "SELECT * FROM Customers WHERE Id = @Id";
        public static string _GetAll = "SELECT * FROM dbo.Customers";
    }
}
