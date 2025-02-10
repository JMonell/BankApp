using BankApp.Data;

namespace BankApp.Models;

public enum AccountTypes{
    Main, Savings, Salary, Portfolio 
}
public class Account{

    public int Id { get; set; }
    public string AccountNumber { get; set; }
    public string Name { get; set; }
    public decimal Balance { get; set; }
    public AccountTypes AccountType { get; set; }
    public List<Transaction> Transactions { get; set; }
    public bool IsActive { get; set; }
    public string? CardNumber { get; set; }
    
    public string UserId { get; set;}
    public ApplicationUser User { get; set;}   
}