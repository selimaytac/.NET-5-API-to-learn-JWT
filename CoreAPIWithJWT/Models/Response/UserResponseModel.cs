using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPIWithJWT.Models.Response
{
    public class UserResponseModel
    {
        [Description("User Id")]
        public Guid Id { get; set; }

        [Description("User Name")]
        public string UserName { get; set; }

        [Description("User Mail")]
        public string Email { get; set; }

        [Description("User Phone Number")]
        public string PhoneNumber { get; set; }
    }
}
