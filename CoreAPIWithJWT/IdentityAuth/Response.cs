using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CoreAPIWithJWT.IdentityAuth
{
    public class Response
    {
        public string Status { get; set; }
        public string Message { get; set; }

        public List<IdentityError> Errors { get; set; }
    }
}
