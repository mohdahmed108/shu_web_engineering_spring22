using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebEnggBackendApp.Models.RequestModels
{
    public class AuthenticateRequestModel
    {
        [Required(ErrorMessage = "Please provide username")]
        public string username { get; set; }
        
        [Required]
        public string password { get; set; }
    }
}