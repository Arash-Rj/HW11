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
    public class CustomerService : ICustomerService
    {
        ICustomerRepo _customerRepo = new DapperCustomerRepo();
        public static Customer _OnlineCustomer;
        public Result Login(string username)
        {
            var users = _customerRepo.GetAll();
            try
            {
                foreach (var user in users)
                {
                    if (user._name == username)
                    {
                       _OnlineCustomer = user;
                        return new Result(true, "Login was successful.");
                    }
                }
                return new Result(false, "Error: User was not found! Try again.");
            }
            catch (NullReferenceException)
            {
                return new Result(false, "Error: User was not found! Try again.");
            }
        }

        public Result Logout()
        {
            string data = null;
            _OnlineCustomer = null;
            return new Result(true, "Logout successful.");
        }

        public Result Register(string username)
        {
            Customer newcustomer = new Customer() { _name= username };
            List<Customer> customers = _customerRepo.GetAll();
            if (customers is null)
            {
                _customerRepo.Add(newcustomer);
            }
            else
            {
                foreach (var customer in customers)
                {
                    if (customer._name.Equals(username))
                    {
                        return new Result(false, "Register failed. User already exists");
                    }
                }
               _customerRepo.Add(newcustomer);
            }
            return new Result(true, "Register is done successfully.");
        }
    }
}
