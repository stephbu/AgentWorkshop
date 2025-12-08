namespace LegacyInventory.Models;

/// <summary>
/// Represents a product in the inventory system.
/// </summary>
public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Sku { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int QuantityInStock { get; set; }
    public int ReorderLevel { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastRestockedAt { get; set; }
    public bool IsDiscontinued { get; set; }

    public bool NeedsReorder => QuantityInStock <= ReorderLevel && !IsDiscontinued;
}
