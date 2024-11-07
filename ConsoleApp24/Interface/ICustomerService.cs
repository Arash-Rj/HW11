using HW11.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11.Interface
{
    public interface ICustomerService
    {
        Result Login(string username);
        Result Register(string username);
        Result Logout();
    }
}
