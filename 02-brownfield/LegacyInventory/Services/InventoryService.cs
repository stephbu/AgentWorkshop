using LegacyInventory.Models;
using Newtonsoft.Json;

namespace LegacyInventory.Services;

/// <summary>
/// Service for managing product inventory.
/// </summary>
public class InventoryService
{
    private readonly List<Product> _products = new List<Product>();
    private readonly List<StockTransaction> _transactions = new List<StockTransaction>();

    public InventoryService()
    {
        // Seed with sample data
        SeedData();
    }

    private void SeedData()
    {
        _products.AddRange(new[]
        {
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Wireless Mouse",
                Sku = "ELEC-001",
                Category = "Electronics",
                Price = 29.99m,
                QuantityInStock = 45,
                ReorderLevel = 10,
                CreatedAt = DateTime.Now.AddMonths(-6)
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "USB-C Cable",
                Sku = "ELEC-002",
                Category = "Electronics",
                Price = 12.99m,
                QuantityInStock = 5,
                ReorderLevel = 20,
                CreatedAt = DateTime.Now.AddMonths(-3)
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Office Chair",
                Sku = "FURN-001",
                Category = "Furniture",
                Price = 199.99m,
                QuantityInStock = 12,
                ReorderLevel = 5,
                CreatedAt = DateTime.Now.AddYears(-1)
            }
        });
    }

    public Product AddProduct(string name, string sku, string category, decimal price, int quantity, int reorderLevel)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Product name cannot be empty", nameof(name));

        if (string.IsNullOrWhiteSpace(sku))
            throw new ArgumentException("SKU cannot be empty", nameof(sku));

        if (price < 0)
            throw new ArgumentException("Price cannot be negative", nameof(price));

        if (quantity < 0)
            throw new ArgumentException("Quantity cannot be negative", nameof(quantity));

        // Check for duplicate SKU
        if (_products.Any(p => p.Sku.Equals(sku, StringComparison.OrdinalIgnoreCase)))
            throw new InvalidOperationException($"Product with SKU '{sku}' already exists");

        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = name,
            Sku = sku,
            Category = category,
            Price = price,
            QuantityInStock = quantity,
            ReorderLevel = reorderLevel,
            CreatedAt = DateTime.Now
        };

        _products.Add(product);

        // Log initial stock as a transaction
        if (quantity > 0)
        {
            RecordTransaction(product.Id, TransactionType.Restock, quantity, "Initial stock", "System");
        }

        return product;
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return _products.OrderBy(p => p.Name);
    }

    public IEnumerable<Product> GetProductsByCategory(string category)
    {
        if (string.IsNullOrWhiteSpace(category))
            throw new ArgumentException("Category cannot be empty", nameof(category));

        return _products
            .Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
            .OrderBy(p => p.Name);
    }

    public IEnumerable<Product> GetProductsNeedingReorder()
    {
        return _products
            .Where(p => p.NeedsReorder)
            .OrderBy(p => p.QuantityInStock);
    }

    public Product? FindProductBySku(string sku)
    {
        if (string.IsNullOrWhiteSpace(sku))
            return null;

        return _products.FirstOrDefault(p => p.Sku.Equals(sku, StringComparison.OrdinalIgnoreCase));
    }

    public Product? FindProductById(Guid id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }

    public IEnumerable<Product> SearchProducts(string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return Enumerable.Empty<Product>();

        return _products
            .Where(p => p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                        p.Sku.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                        p.Category.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
            .OrderBy(p => p.Name);
    }

    public void RestockProduct(Guid productId, int quantity, string performedBy)
    {
        if (quantity <= 0)
            throw new ArgumentException("Restock quantity must be positive", nameof(quantity));

        var product = FindProductById(productId);
        if (product == null)
            throw new InvalidOperationException($"Product with ID '{productId}' not found");

        if (product.IsDiscontinued)
            throw new InvalidOperationException("Cannot restock a discontinued product");

        product.QuantityInStock += quantity;
        product.LastRestockedAt = DateTime.Now;

        RecordTransaction(productId, TransactionType.Restock, quantity, "Restock", performedBy);
    }

    public void RecordSale(Guid productId, int quantity, string performedBy)
    {
        if (quantity <= 0)
            throw new ArgumentException("Sale quantity must be positive", nameof(quantity));

        var product = FindProductById(productId);
        if (product == null)
            throw new InvalidOperationException($"Product with ID '{productId}' not found");

        if (product.QuantityInStock < quantity)
            throw new InvalidOperationException($"Insufficient stock. Available: {product.QuantityInStock}");

        product.QuantityInStock -= quantity;

        RecordTransaction(productId, TransactionType.Sale, -quantity, "Sale", performedBy);
    }

    public void AdjustStock(Guid productId, int adjustment, string reason, string performedBy)
    {
        var product = FindProductById(productId);
        if (product == null)
            throw new InvalidOperationException($"Product with ID '{productId}' not found");

        var newQuantity = product.QuantityInStock + adjustment;
        if (newQuantity < 0)
            throw new InvalidOperationException($"Adjustment would result in negative stock");

        product.QuantityInStock = newQuantity;

        RecordTransaction(productId, TransactionType.Adjustment, adjustment, reason, performedBy);
    }

    public void DiscontinueProduct(Guid productId)
    {
        var product = FindProductById(productId);
        if (product == null)
            throw new InvalidOperationException($"Product with ID '{productId}' not found");

        product.IsDiscontinued = true;
    }

    public IEnumerable<StockTransaction> GetTransactionHistory(Guid productId)
    {
        return _transactions
            .Where(t => t.ProductId == productId)
            .OrderByDescending(t => t.TransactionDate);
    }

    public IEnumerable<StockTransaction> GetRecentTransactions(int count = 10)
    {
        return _transactions
            .OrderByDescending(t => t.TransactionDate)
            .Take(count);
    }

    public string ExportToJson()
    {
        var data = new
        {
            Products = _products,
            Transactions = _transactions,
            ExportedAt = DateTime.Now
        };

        return JsonConvert.SerializeObject(data, Formatting.Indented);
    }

    public InventorySummary GetSummary()
    {
        return new InventorySummary
        {
            TotalProducts = _products.Count,
            TotalValue = _products.Sum(p => p.Price * p.QuantityInStock),
            ProductsNeedingReorder = _products.Count(p => p.NeedsReorder),
            DiscontinuedProducts = _products.Count(p => p.IsDiscontinued),
            TotalTransactions = _transactions.Count
        };
    }

    private void RecordTransaction(Guid productId, TransactionType type, int quantity, string reason, string performedBy)
    {
        _transactions.Add(new StockTransaction
        {
            Id = Guid.NewGuid(),
            ProductId = productId,
            Type = type,
            Quantity = quantity,
            Reason = reason,
            TransactionDate = DateTime.Now,
            PerformedBy = performedBy
        });
    }
}

public class InventorySummary
{
    public int TotalProducts { get; set; }
    public decimal TotalValue { get; set; }
    public int ProductsNeedingReorder { get; set; }
    public int DiscontinuedProducts { get; set; }
    public int TotalTransactions { get; set; }
}
