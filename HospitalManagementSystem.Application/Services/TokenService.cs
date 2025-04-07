using HospitalManagementSystem.Application.Interfaces;
using HospitalManagementSystem.Core.Entities;
using HospitalManagementSystem.Infrastructure.Interfaces;
using HospitalManagementSystem.Infrastructure.Models;
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
                .Where(t => t.Generatedat == today &&
                           ((isMorningSession && t.Generatedat >= morningStartTime && t.Generatedat < morningEndTime) ||
                            (isEveningSession && t.Generatedat >= eveningStartTime && t.Generatedat < eveningEndTime)))
                .OrderByDescending(t => t.Tokennumber)
                .FirstOrDefault();

            // Determine the next token number for the session
            int nextTokenNumber = (lastTokenForSession != null)
                ? lastTokenForSession.Tokennumber + 1
                : 1;

            var token = new Token
            {
                Appointmentid= appointmentId,
                Tokennumber = nextTokenNumber,
                Generatedat = DateTime.Now,
                Isserved = false,
            };

            await _unitOfWork.Tokens.AddAsync(token);
            await _unitOfWork.CompleteAsync();

            return nextTokenNumber;
        }

        public async Task<LiveTokenStatus> GetLiveTokenStatus()
        {
            var currentToken = _unitOfWork.Tokens.GetAllAsync().Result.FirstOrDefault(t => t.Isserved == false);
            var upcomingTokens = _unitOfWork.Tokens.GetAllAsync().Result
                                         .Where(t => t.Isserved == false)
                                         .OrderBy(t => t.Tokennumber)
                                         .Skip(1)
                                         .Take(5)
                                         .Select(t => t.Tokennumber)
                                         .ToList();

            return new LiveTokenStatus
            {
                CurrentToken = currentToken?.Tokennumber ?? 0
            };
        }
    }
}
