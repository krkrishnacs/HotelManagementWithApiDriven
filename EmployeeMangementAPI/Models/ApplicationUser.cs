using Microsoft.AspNetCore.Identity;

namespace EmployeeMangementAPI.Models
{
    public class ApplicationUser: IdentityUser
    {
        public List<Cart>? Carts { get; set; }
        public List<Product>? Products { get; set; }
    }
}
