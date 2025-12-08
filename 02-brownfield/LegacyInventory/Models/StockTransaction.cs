namespace LegacyInventory.Models;

/// <summary>
/// Represents a stock adjustment transaction.
/// </summary>
public class StockTransaction
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public TransactionType Type { get; set; }
    public int Quantity { get; set; }
    public string Reason { get; set; } = string.Empty;
    public DateTime TransactionDate { get; set; }
    public string PerformedBy { get; set; } = string.Empty;
}

public enum TransactionType
{
    Restock,
    Sale,
    Adjustment,
    Return,
    Damage
}
