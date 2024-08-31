using EmployeeMangementAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMangementAPI.DataDbContext
{
    public class AccountDbContext: IdentityDbContext<ApplicationUser>
    {
        public AccountDbContext(DbContextOptions<AccountDbContext> options):base(options)
        {
        }
        public AccountDbContext():base()
        {
        }

        public DbSet<Cart> carts { set; get; }
        public DbSet<Product> products { set; get; }
        public DbSet<Employee> Employees { set; get; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<GuestMember> GuestMember { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            //modelBuilder.Entity<Login>().OwnsOne(x => x.EmailAddress);
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Product1", Price = 10, Description = "Description1" },
                new Product { Id = 2, Name = "Product2", Price = 20, Description = "Description2" }

            ); 
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
