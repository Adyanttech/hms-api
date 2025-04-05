using HospitalManagementSystem.Application.Interfaces;
using HospitalManagementSystem.Core.Entities;
using HospitalManagementSystem.Infrastructure.Context;
using HospitalManagementSystem.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TokenService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> GenerateToken(int appointmentId)
        {
            DateTime today = DateTime.Today;
            DateTime now = DateTime.Now;
           
            /* Morning Session */
            DateTime morningStartTime = today.AddHours(8); // 8:00 AM
            DateTime morningEndTime = today.AddHours(13).AddMinutes(00); // 1:00 PM

            /* Evening Session */
            DateTime eveningStartTime = today.AddHours(16); // 5:00 PM
            DateTime eveningEndTime = today.AddHours(21).AddMinutes(00); // 9:00 PM

            // Determine current session
            bool isMorningSession = now >= morningStartTime && now < morningEndTime;
            bool isEveningSession = now >= eveningStartTime && now < eveningEndTime;

            // Filter tokens based on the session
            var lastTokenForSession = _unitOfWork.Tokens.GetAllAsync().Result
                .Where(t => t.GeneratedAt.Date == today &&
                           ((isMorningSession && t.GeneratedAt >= morningStartTime && t.GeneratedAt < morningEndTime) ||
                            (isEveningSession && t.GeneratedAt >= eveningStartTime && t.GeneratedAt < eveningEndTime)))
                .OrderByDescending(t => t.TokenNumber)
                .FirstOrDefault();

            // Determine the next token number for the session
            int nextTokenNumber = (lastTokenForSession != null)
                ? lastTokenForSession.TokenNumber + 1
                : 1;

            var token = new Token
            {
                AppointmentId = appointmentId,
                TokenNumber = nextTokenNumber,
                GeneratedAt = DateTime.Now,
                IsServed = false,
            };

            await _unitOfWork.Tokens.AddAsync(token);
            await _unitOfWork.CompleteAsync();

            return nextTokenNumber;
        }

        public async Task<LiveTokenStatus> GetLiveTokenStatus()
        {
            var currentToken = _unitOfWork.Tokens.GetAllAsync().Result.FirstOrDefault(t => t.IsServed == false);
            var upcomingTokens = _unitOfWork.Tokens.GetAllAsync().Result
                                         .Where(t => t.IsServed == false)
                                         .OrderBy(t => t.TokenNumber)
                                         .Skip(1)
                                         .Take(5)
                                         .Select(t => t.TokenNumber)
                                         .ToList();

            return new LiveTokenStatus
            {
                CurrentToken = currentToken?.TokenNumber ?? 0
            };
        }
    }
}
