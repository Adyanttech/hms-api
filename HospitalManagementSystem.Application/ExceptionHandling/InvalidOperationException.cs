using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Application.ExceptionHandling
{
    public class InvalidOperationException : BusinessException
    {
        public InvalidOperationException(string message) : base(message) { }
    }
}
