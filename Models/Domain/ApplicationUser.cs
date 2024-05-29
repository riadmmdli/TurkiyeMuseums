using Microsoft.AspNetCore.Identity;

namespace TurkiyeMuseums.Models.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
