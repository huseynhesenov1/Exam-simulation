using Microsoft.AspNetCore.Identity;

namespace Project.Core.Entities
{
    public class AppUser  : IdentityUser
    { 
        public string FisrtName { get; set; }
        public string LastName { get; set; }
    }
}
