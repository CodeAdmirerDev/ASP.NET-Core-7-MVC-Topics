using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace LearningMVC.Areas.Identity.Data;

// Add profile data for application users by adding properties to the LearningMVCUser class
public class LearningMVCUser : IdentityUser
{
    [PersonalData]
    [Column(TypeName = "nvarchar(50)")]
    public string FirstName { get; set; }
    [PersonalData]
    [Column(TypeName = "nvarchar(50)")]
    public string LastName { get; set; }
    [PersonalData]
    [Column(TypeName = "nvarchar(50)")]
    public string PanCard { get; set; }

}

public class LearningMVCRoles : IdentityRole
{

    [PersonalData]
    [Column(TypeName = "nvarchar(50)")]
    public string RoleDesc { get; set; }
}

//If you want to create new table then create your class and 
// Add the class in Context class
//for example
public class Emp
{
    [Key]
    public int EId { get; set; }
    public string Ename { get; set; }
    public int Age { get; set; }
    public int PhoneNumber { get; set; }
}

