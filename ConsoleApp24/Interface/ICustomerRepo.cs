using ConsoleApp24.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11.Interface
{
    public interface ICustomerRepo
    {
        void Add(Customer customer);
        Customer Get(int id);
        List<Customer> GetAll();
    }
}
