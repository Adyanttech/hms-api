using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagementSystem.Core.Entities;

namespace HospitalManagementSystem.Application.Interfaces
{
    public interface ILoginService
    {
        Task<string> LoginAsync(LoginModel model);
    }
}
