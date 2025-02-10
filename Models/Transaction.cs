namespace BankApp.Models;

public enum Currency{
    SEK, EUR, USD
}
public class Transaction{

    public int Id { get; set; }

    public string ToAccount { get; set; }

    public int FromAccountId { get; set;}                                                                                                        
    public Account FromAccount { get; set;}
    public DateTime TransactionDate { get; set; }    
    public decimal OutgoingBalance { get; set; }
    public Currency currency { get; set; }
    public bool IsReserved { get; set; }
    public string? Message { get; set;}
    public string TransactionNumber { get; set; }
    
}