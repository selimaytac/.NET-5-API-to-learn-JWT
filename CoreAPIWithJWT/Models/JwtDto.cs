using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPIWithJWT.Models
{
    public class JwtDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public List<string> UserRoles { get; set; }
    }
}
