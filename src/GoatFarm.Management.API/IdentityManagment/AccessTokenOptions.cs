using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoatFarm.Management.API.IdentityManagement
{
    public class AccessTokenOptions
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpiresInHours { get; set; }
    }
}
