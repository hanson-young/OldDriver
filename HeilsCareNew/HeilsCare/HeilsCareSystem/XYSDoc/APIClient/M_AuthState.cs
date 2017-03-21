using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYS.Remp.Screening.APIClient
{
    public class M_AuthState
    {
        public string access_token { get; set; }

        public string token_type { get; set; }

        public string scope { get; set; }

        public string expires_in { get; set; }
    }
}
