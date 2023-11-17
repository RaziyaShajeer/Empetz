

using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ApplicationDbContext : DbContext
    {


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
		public virtual DbSet<Location> Location { get; set; }
		public virtual DbSet<SystemUser> SystemUser { get; set; }
        public virtual DbSet<Breed>Breed {get;set;}
	  public virtual DbSet<Pet> Pet { get; set; }

       public virtual DbSet<PetsCategory> PetsCategory { get; set; }
        public virtual DbSet<Post> Post { get; set; }

        public virtual DbSet<Profile> Profile { get; set; }

		public virtual DbSet<PublicUser> PublicUser { get; set; }

		public virtual DbSet<ReportedPost> ReportedPost { get; set; }

        public virtual DbSet<WishList> WishList { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

	//		modelBuilder.Entity<ReportedPost>()
	//.HasOne(rp => rp.User).OnDelete(DeleteBehavior.NoAction);

			// Disable cascade delete
			modelBuilder.Entity<ReportedPost>()
			 .HasOne(js => js.User)
			 .WithMany()
			 .HasForeignKey(js => js.UserId)
			 .OnDelete(DeleteBehavior.Restrict); // Disable cascade delete
		}
    }
}
