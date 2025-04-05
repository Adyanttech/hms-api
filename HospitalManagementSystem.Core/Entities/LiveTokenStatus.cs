using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Core.Entities
{
    public class LiveTokenStatus
    {
        public int CurrentToken { get; set; }
        public List<int>? UpcomingTokens { get; set; }
        public string ExpectedTime { get; set; }
    }
}
