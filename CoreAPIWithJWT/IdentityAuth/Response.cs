using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace CoreAPIWithJWT.IdentityAuth
{
    public class Response<T> where T : class
    {
        public T Data { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public List<T> Errors { get; set; }

    }
}
