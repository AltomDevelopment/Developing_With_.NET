using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using User_Login_IdentityExample.Areas.Identity.Data;

namespace User_Login_IdentityExample.Data;

public class User_Login_IdentityAuthDbContext : IdentityDbContext<User_Login_IdentityExampleApplicationUser>
{
    public User_Login_IdentityAuthDbContext(DbContextOptions<User_Login_IdentityAuthDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
