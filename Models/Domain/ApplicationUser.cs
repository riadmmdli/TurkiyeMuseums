using Microsoft.AspNetCore.Identity;

namespace turkey_museum.Models.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
