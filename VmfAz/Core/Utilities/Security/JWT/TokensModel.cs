using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public class TokensModel
    {
        public AccessToken AccessToken { get; set; }
        public AccessToken RefreshToken { get; set; }

    }
}
