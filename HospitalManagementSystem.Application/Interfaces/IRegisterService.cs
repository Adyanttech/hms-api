using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagementSystem.Core.Entities;

namespace HospitalManagementSystem.Application.Interfaces
{
    public interface IRegisterService
    {
        Task<string> RegisterAsync(RegisterModel request);
    }
}
