using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace ShopTARge22.Core.DTO.AccountsDTOs
{
    public class LoginDTO
    {
        public string Email { get; set; }
        public IList<AuthenticationScheme> ExternalLogins { get; set; }
    }
}
