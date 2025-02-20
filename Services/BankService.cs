
using BankApp.Data;
using BankApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace BankApp.Services;

public class BankService{
    private readonly ApplicationDbContext _context;
    private Account account;
    private List<Account> accounts = new List<Account>();
    private ApplicationUser user;
    



    public BankService(ApplicationDbContext context){
        _context = context;
    }

    public async Task AddAccount(Account account)
    {
        _context.Accounts.Add(account);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Account>> GetAccountsByUserAsync(ApplicationUser user)
    {
        return await _context.Accounts.Where(a => a.User.Id == user.Id).ToListAsync();
    }

    // Method to create and save 'Main Account' for each new user
    public async Task CreateMainAccountAsync(ApplicationUser user){
          // Default properties (for Register.razor as well)
        if(user.Accounts.Any() == false){
        var mainAccount = new Account
        {
            AccountNumber = await GetAccountnumber(), // Create a method to generate an Account Number!
            Name = "Main Account",
            Balance = 100000.00m,
            AccountType = AccountTypes.Main, // Bringing this from the enum in AccountType (Account.cs)
            IsActive = true,
            UserId = user.Id,
            CardNumber = "1234 5678 9010 1112"
        };
        // Adding the new account to the database
        _context.Accounts.Add(mainAccount);
        // Saving changes asynchronously in the database
        await _context.SaveChangesAsync();
        }
    }

    // public async Task DeleteAccountAsync(int accountId){
    //     var account = await _context.Accounts.FindAsync(accountId);
    //     if (account != null){
    //         await _context.Accounts.DeleteAsync(account);
            
    //     }
    // }

    // public async Task DeleteAccountAsync(int accountId){
    //     await _context.Accounts
    //           //FirstOrDefaultAsync checks the first matching account and if it doesn't exist return default(NULL)
    //         .FirstOrDefaultAsync(a => a.Id == account.Id && a.UserId == user.Id);

    //     if (account != null){
    //         _context.Accounts.Remove(account);
    //         await _context.SaveChangesAsync();
    //     }
    // }
    
/*

private async Task DeleteUser(string userId)
    {
        var user = await userManager.FindByIdAsync(userId);
        if (user != null){
            var roles = await userManager.GetRolesAsync(user); // Get user roles
            if (roles.Contains("User")){
                await userManager.DeleteAsync(user);
                await ShowUsers(); // Refresh user list
            }
            else{
                Console.WriteLine("can not delete Admin");
                await ShowUsers(); // Refresh user list
            }
        }

        
    }

*/
        public async Task DeleteAccountAsync(ApplicationUser user, int accountId)
        {
            var account = await _context.Accounts
                .FirstOrDefaultAsync(a => a.Id == accountId && a.UserId == user.Id);

            if (account != null)
            {
                _context.Accounts.Remove(account);
                await _context.SaveChangesAsync();
            }
        }

    // private async Task SaveAccount(ApplicationUser user)
    // {
    //     if (user is null) return;

    //         account.UserId = user.Id;
    //         account.AccountNumber = await getAccountnumber();
    //         account.IsActive = true;

    //         _context.Accounts.Add(account); //add to the local context
    //         await _context.SaveChangesAsync(); 

    //         accounts.Add(account); //add to the local list
    //         account = new Account(); //reset the form
    // }

    private async Task<String> GetAccountnumber(){
        Random random = new Random();
        string clearingNum = "8008-5";

     
        int firstPart = random.Next(1000, 10000); 
        int secondPart = random.Next(1000, 10000); 

        string result = $"{clearingNum}, {firstPart} {secondPart}";
        return result;
    }
}