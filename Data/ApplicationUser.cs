using BankApp.Models;
using Microsoft.AspNetCore.Identity;

namespace BankApp.Data;


// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser{
    
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string SocialSecurityNumber { get; set; }
    public List<Account> Accounts { get; set; }
    public string Address { get; set;}
}

