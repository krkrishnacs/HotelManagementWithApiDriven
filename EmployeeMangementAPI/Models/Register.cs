using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EmployeeMangementAPI.Models
{
    public class Register: IdentityUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

    }
    

}
