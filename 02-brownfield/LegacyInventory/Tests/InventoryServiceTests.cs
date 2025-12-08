using LegacyInventory.Services;
using LegacyInventory.Models;
using Xunit;

namespace LegacyInventory.Tests;

public class InventoryServiceTests
{
    private InventoryService CreateService() => new InventoryService();

    #region AddProduct Tests

    [Fact]
    public void AddProduct_WithValidData_ReturnsProduct()
    {
        // Arrange
        var service = CreateService();

        // Act
        var product = service.AddProduct("Test Product", "TEST-001", "Test Category", 19.99m, 50, 10);

        // Assert
        Assert.NotNull(product);
        Assert.Equal("Test Product", product.Name);
        Assert.Equal("TEST-001", product.Sku);
        Assert.Equal("Test Category", product.Category);
        Assert.Equal(19.99m, product.Price);
        Assert.Equal(50, product.QuantityInStock);
        Assert.Equal(10, product.ReorderLevel);
        Assert.NotEqual(Guid.Empty, product.Id);
    }

    [Fact]
    public void AddProduct_WithEmptyName_ThrowsArgumentException()
    {
        // Arrange
        var service = CreateService();

        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() =>
            service.AddProduct("", "TEST-001", "Category", 10m, 5, 2));
        Assert.Contains("name", ex.Message, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void AddProduct_WithEmptySku_ThrowsArgumentException()
    {
        // Arrange
        var service = CreateService();

        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() =>
            service.AddProduct("Product", "", "Category", 10m, 5, 2));
        Assert.Contains("SKU", ex.Message, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void AddProduct_WithNegativePrice_ThrowsArgumentException()
    {
        // Arrange
        var service = CreateService();

        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() =>
            service.AddProduct("Product", "SKU-001", "Category", -10m, 5, 2));
        Assert.Contains("price", ex.Message, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void AddProduct_WithDuplicateSku_ThrowsInvalidOperationException()
    {
        // Arrange
        var service = CreateService();
        service.AddProduct("Product 1", "DUPE-001", "Category", 10m, 5, 2);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() =>
            service.AddProduct("Product 2", "DUPE-001", "Category", 20m, 10, 5));
    }

    [Fact]
    public void AddProduct_WithZeroQuantity_Succeeds()
    {
        // Arrange
        var service = CreateService();

        // Act
        var product = service.AddProduct("Empty Stock", "EMPTY-001", "Category", 10m, 0, 5);

        // Assert
        Assert.Equal(0, product.QuantityInStock);
    }

    #endregion

    #region GetProducts Tests

    [Fact]
    public void GetAllProducts_ReturnsSeededAndAddedProducts()
    {
        // Arrange
        var service = CreateService();
        var initialCount = service.GetAllProducts().Count();
        service.AddProduct("New Product", "NEW-001", "Category", 10m, 5, 2);

        // Act
        var products = service.GetAllProducts();

        // Assert
        Assert.Equal(initialCount + 1, products.Count());
    }

    [Fact]
    public void GetProductsByCategory_ReturnsMatchingProducts()
    {
        // Arrange
        var service = CreateService();

        // Act (Electronics is seeded)
        var products = service.GetProductsByCategory("Electronics");

        // Assert
        Assert.All(products, p => Assert.Equal("Electronics", p.Category));
    }

    [Fact]
    public void GetProductsByCategory_IsCaseInsensitive()
    {
        // Arrange
        var service = CreateService();

        // Act
        var products = service.GetProductsByCategory("electronics");

        // Assert
        Assert.NotEmpty(products);
    }

    #endregion

    #region FindProduct Tests

    [Fact]
    public void FindProductBySku_WithExistingSku_ReturnsProduct()
    {
        // Arrange
        var service = CreateService();
        service.AddProduct("Find Me", "FIND-001", "Category", 10m, 5, 2);

        // Act
        var product = service.FindProductBySku("FIND-001");

        // Assert
        Assert.NotNull(product);
        Assert.Equal("Find Me", product.Name);
    }

    [Fact]
    public void FindProductBySku_WithNonExistingSku_ReturnsNull()
    {
        // Arrange
        var service = CreateService();

        // Act
        var product = service.FindProductBySku("NONEXISTENT");

        // Assert
        Assert.Null(product);
    }

    [Fact]
    public void FindProductBySku_IsCaseInsensitive()
    {
        // Arrange
        var service = CreateService();
        service.AddProduct("Case Test", "CASE-001", "Category", 10m, 5, 2);

        // Act
        var product = service.FindProductBySku("case-001");

        // Assert
        Assert.NotNull(product);
    }

    #endregion

    #region SearchProducts Tests

    [Fact]
    public void SearchProducts_ByName_ReturnsMatchingProducts()
    {
        // Arrange
        var service = CreateService();
        service.AddProduct("Unique Search Term", "SRCH-001", "Category", 10m, 5, 2);

        // Act
        var products = service.SearchProducts("Unique Search");

        // Assert
        Assert.Single(products);
    }

    [Fact]
    public void SearchProducts_BySku_ReturnsMatchingProducts()
    {
        // Arrange
        var service = CreateService();
        service.AddProduct("Product", "SEARCHME-001", "Category", 10m, 5, 2);

        // Act
        var products = service.SearchProducts("SEARCHME");

        // Assert
        Assert.Single(products);
    }

    [Fact]
    public void SearchProducts_ByCategory_ReturnsMatchingProducts()
    {
        // Arrange
        var service = CreateService();
        service.AddProduct("Product", "CAT-001", "UniqueCategory", 10m, 5, 2);

        // Act
        var products = service.SearchProducts("UniqueCategory");

        // Assert
        Assert.Single(products);
    }

    [Fact]
    public void SearchProducts_WithEmptyTerm_ReturnsEmpty()
    {
        // Arrange
        var service = CreateService();

        // Act
        var products = service.SearchProducts("");

        // Assert
        Assert.Empty(products);
    }

    #endregion

    #region Restock Tests

    [Fact]
    public void RestockProduct_IncreasesQuantity()
    {
        // Arrange
        var service = CreateService();
        var product = service.AddProduct("Restock Test", "RST-001", "Category", 10m, 10, 5);
        var originalQty = product.QuantityInStock;

        // Act
        service.RestockProduct(product.Id, 25, "Test User");

        // Assert
        Assert.Equal(originalQty + 25, product.QuantityInStock);
        Assert.NotNull(product.LastRestockedAt);
    }

    [Fact]
    public void RestockProduct_WithZeroQuantity_ThrowsArgumentException()
    {
        // Arrange
        var service = CreateService();
        var product = service.AddProduct("Test", "RST-002", "Category", 10m, 10, 5);

        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
            service.RestockProduct(product.Id, 0, "User"));
    }

    [Fact]
    public void RestockProduct_DiscontinuedProduct_ThrowsInvalidOperationException()
    {
        // Arrange
        var service = CreateService();
        var product = service.AddProduct("Discontinued", "DISC-001", "Category", 10m, 10, 5);
        service.DiscontinueProduct(product.Id);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() =>
            service.RestockProduct(product.Id, 10, "User"));
    }

    #endregion

    #region RecordSale Tests

    [Fact]
    public void RecordSale_DecreasesQuantity()
    {
        // Arrange
        var service = CreateService();
        var product = service.AddProduct("Sale Test", "SALE-001", "Category", 10m, 50, 5);

        // Act
        service.RecordSale(product.Id, 15, "Test User");

        // Assert
        Assert.Equal(35, product.QuantityInStock);
    }

    [Fact]
    public void RecordSale_ExceedingStock_ThrowsInvalidOperationException()
    {
        // Arrange
        var service = CreateService();
        var product = service.AddProduct("Low Stock", "LOW-001", "Category", 10m, 5, 2);

        // Act & Assert
        var ex = Assert.Throws<InvalidOperationException>(() =>
            service.RecordSale(product.Id, 10, "User"));
        Assert.Contains("Insufficient", ex.Message);
    }

    [Fact]
    public void RecordSale_ExactStock_Succeeds()
    {
        // Arrange
        var service = CreateService();
        var product = service.AddProduct("Exact", "EXACT-001", "Category", 10m, 10, 2);

        // Act
        service.RecordSale(product.Id, 10, "User");

        // Assert
        Assert.Equal(0, product.QuantityInStock);
    }

    #endregion

    #region AdjustStock Tests

    [Fact]
    public void AdjustStock_PositiveAdjustment_IncreasesStock()
    {
        // Arrange
        var service = CreateService();
        var product = service.AddProduct("Adjust+", "ADJ-001", "Category", 10m, 20, 5);

        // Act
        service.AdjustStock(product.Id, 10, "Found extras", "User");

        // Assert
        Assert.Equal(30, product.QuantityInStock);
    }

    [Fact]
    public void AdjustStock_NegativeAdjustment_DecreasesStock()
    {
        // Arrange
        var service = CreateService();
        var product = service.AddProduct("Adjust-", "ADJ-002", "Category", 10m, 20, 5);

        // Act
        service.AdjustStock(product.Id, -5, "Damaged goods", "User");

        // Assert
        Assert.Equal(15, product.QuantityInStock);
    }

    [Fact]
    public void AdjustStock_ResultingInNegative_ThrowsInvalidOperationException()
    {
        // Arrange
        var service = CreateService();
        var product = service.AddProduct("Negative", "NEG-001", "Category", 10m, 10, 5);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() =>
            service.AdjustStock(product.Id, -20, "Too much", "User"));
    }

    #endregion

    #region Reorder Tests

    [Fact]
    public void GetProductsNeedingReorder_ReturnsLowStockProducts()
    {
        // Arrange
        var service = CreateService();
        service.AddProduct("Low Stock", "LOW-002", "Category", 10m, 5, 10); // Below reorder level
        service.AddProduct("High Stock", "HIGH-001", "Category", 10m, 50, 10); // Above reorder level

        // Act
        var needsReorder = service.GetProductsNeedingReorder();

        // Assert
        Assert.Contains(needsReorder, p => p.Sku == "LOW-002");
        Assert.DoesNotContain(needsReorder, p => p.Sku == "HIGH-001");
    }

    [Fact]
    public void GetProductsNeedingReorder_ExcludesDiscontinued()
    {
        // Arrange
        var service = CreateService();
        var product = service.AddProduct("Discontinued Low", "DISCLOW-001", "Category", 10m, 5, 10);
        service.DiscontinueProduct(product.Id);

        // Act
        var needsReorder = service.GetProductsNeedingReorder();

        // Assert
        Assert.DoesNotContain(needsReorder, p => p.Sku == "DISCLOW-001");
    }

    #endregion

    #region Transaction History Tests

    [Fact]
    public void GetTransactionHistory_ReturnsProductTransactions()
    {
        // Arrange
        var service = CreateService();
        var product = service.AddProduct("History Test", "HIST-001", "Category", 10m, 20, 5);
        service.RestockProduct(product.Id, 10, "User1");
        service.RecordSale(product.Id, 5, "User2");

        // Act
        var transactions = service.GetTransactionHistory(product.Id);

        // Assert
        Assert.True(transactions.Count() >= 2);
    }

    [Fact]
    public void GetRecentTransactions_ReturnsLimitedResults()
    {
        // Arrange
        var service = CreateService();
        var product = service.AddProduct("Recent Test", "REC-001", "Category", 10m, 100, 5);
        
        for (int i = 0; i < 15; i++)
        {
            service.RecordSale(product.Id, 1, "User");
        }

        // Act
        var transactions = service.GetRecentTransactions(10);

        // Assert
        Assert.Equal(10, transactions.Count());
    }

    #endregion

    #region Summary Tests

    [Fact]
    public void GetSummary_ReturnsCorrectCounts()
    {
        // Arrange
        var service = CreateService();
        var initialSummary = service.GetSummary();
        service.AddProduct("Summary Test", "SUM-001", "Category", 100m, 10, 5);

        // Act
        var summary = service.GetSummary();

        // Assert
        Assert.Equal(initialSummary.TotalProducts + 1, summary.TotalProducts);
    }

    [Fact]
    public void GetSummary_CalculatesTotalValue()
    {
        // Arrange
        var service = CreateService();

        // Act
        var summary = service.GetSummary();

        // Assert
        Assert.True(summary.TotalValue > 0);
    }

    #endregion

    #region Export Tests

    [Fact]
    public void ExportToJson_ReturnsValidJson()
    {
        // Arrange
        var service = CreateService();

        // Act
        var json = service.ExportToJson();

        // Assert
        Assert.NotNull(json);
        Assert.Contains("Products", json);
        Assert.Contains("Transactions", json);
    }

    #endregion
}
