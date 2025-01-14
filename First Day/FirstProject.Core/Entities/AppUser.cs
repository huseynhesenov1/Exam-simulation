using Microsoft.AspNetCore.Identity;

namespace FirstProject.Core.Entities;

public class AppUser:IdentityUser
{
    public string FirstName { get; set; }   
    public string LastName { get; set; }

}
