using ConsoleApp24.Entities;
using Dapper;
using HW11.Configuration;
using HW11.Interface;
using HW11.Queries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11.Repository
{
    public class DapperCustomerRepo : ICustomerRepo
    {
        public void Add(Customer customer)
        {
            using (IDbConnection DataBase = new SqlConnection(DbConfig.ConnectionString))
            {
                DataBase.Execute(CustomerQ._create, new { customer._name });
            }
        }

        public Customer? Get(int id)
        {
            using (IDbConnection DataBase = new SqlConnection(DbConfig.ConnectionString))
            {
                return DataBase.QueryFirstOrDefault<Customer>(CustomerQ._GetById, new { Id = id });
            }
        }

        public List<Customer> GetAll()
        {
            using (IDbConnection DataBase = new SqlConnection(DbConfig.ConnectionString))
            {
                return DataBase.Query<Customer>(CustomerQ._GetAll).ToList();
            }
        }
    }
}
