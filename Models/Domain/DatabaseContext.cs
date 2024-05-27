using Humanizer.Localisation;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace turkey_museum.Models.Domain
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {
            

        }
        public DbSet<Location> Location { get; set; }
        public DbSet<MuseumLocation> MuseumLocation { get; set; }
        public DbSet<Museum> Museum { get; set; }



    }
}
