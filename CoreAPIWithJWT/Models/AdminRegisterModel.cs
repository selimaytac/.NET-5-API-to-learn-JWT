using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPIWithJWT.Models
{
    public class AdminRegisterModel : RegisterModel
    {
        [Required(ErrorMessage = "Registered User Id is required")]
        public string recorderId { get; set; }
    }
}
