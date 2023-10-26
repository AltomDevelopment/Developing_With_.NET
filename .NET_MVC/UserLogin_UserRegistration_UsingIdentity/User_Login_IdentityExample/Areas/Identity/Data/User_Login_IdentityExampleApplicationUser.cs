using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace User_Login_IdentityExample.Areas.Identity.Data;

// Add profile data for application users by adding properties to the User_Login_IdentityExampleApplicationUser class
public class User_Login_IdentityExampleApplicationUser : IdentityUser //Represents a user Model and we are inheriting it so we can extend the model.
{
    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string FirstName { get; set; } //Supressed and silenced the issue 

    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string LastName { get; set; }


}

