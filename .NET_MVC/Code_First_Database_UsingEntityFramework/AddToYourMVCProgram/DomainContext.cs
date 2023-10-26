using Code_First_Database_UsingEntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace Code_First_Database_UsingEntityFramework
{
    public class DomainContext : DbContext
    {
        //Must have this constructor to communicate with the database  
        public DomainContext(DbContextOptions options) : base(options)
        {

        }

        //Include a DBSet for the Model Class
        public DbSet<Admin> Admin { get; set; }

        //Populating the Data 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(builder =>
            {
                builder.ToTable("Admin");
                builder.HasKey(e => e.AdminID);
                builder.HasData(new Admin
                {
                    AdminID = 1,
                    EmailAddress = "admin@gmail.com",
                    Password = "password",
                });

            });
        }
    }
}