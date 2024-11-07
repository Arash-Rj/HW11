using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11.Entities
{
    public class Result
    {
        public bool _isDone { get; set; }
        public string? _messege { get; set; }
        public Result(bool IsDone, string? Messege = null)
        {
            _isDone = IsDone;
            _messege = Messege;
        }
    }
}
