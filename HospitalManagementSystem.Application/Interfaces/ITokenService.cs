using HospitalManagementSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Application.Interfaces
{
    public interface ITokenService
    {
        Task<int> GenerateToken(int appointmentId);

        Task<LiveTokenStatus> GetLiveTokenStatus();
    }
}
