using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;

namespace kattienhatt.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public virtual Profile Profile { get; set; }
    }

    public class KattienhattDbContext : IdentityDbContext<ApplicationUser>
    {
        public KattienhattDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Profile> Profiles { get; set; }

    }


}