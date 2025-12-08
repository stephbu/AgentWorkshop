using LegacyInventory.Services;
using LegacyInventory.Models;

namespace LegacyInventory;

class Program
{
    private static InventoryService _inventoryService = new InventoryService();

    static void Main(string[] args)
    {
        Console.WriteLine("=== Legacy Inventory System ===\n");

        if (args.Length == 0)
        {
            ShowHelp();
            return;
        }

        var command = args[0].ToLower();

        try
        {
            switch (command)
            {
                case "list":
                    HandleList(args);
                    break;
                case "add":
                    HandleAdd(args);
                    break;
                case "search":
                    HandleSearch(args);
                    break;
                case "restock":
                    HandleRestock(args);
                    break;
                case "sale":
                    HandleSale(args);
                    break;
                case "reorder":
                    HandleReorderReport();
                    break;
                case "history":
                    HandleHistory(args);
                    break;
                case "summary":
                    HandleSummary();
                    break;
                case "export":
                    HandleExport();
                    break;
                case "help":
                    ShowHelp();
                    break;
                default:
                    Console.WriteLine($"Unknown command: {command}");
                    ShowHelp();
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Environment.Exit(1);
        }
    }

    static void ShowHelp()
    {
        Console.WriteLine("Usage: inventory <command> [options]\n");
        Console.WriteLine("Commands:");
        Console.WriteLine("  list [category]              - List all products (optionally by category)");
        Console.WriteLine("  add <name> <sku> <category> <price> <qty> <reorder>");
        Console.WriteLine("                               - Add a new product");
        Console.WriteLine("  search <term>                - Search products");
        Console.WriteLine("  restock <sku> <quantity>     - Restock a product");
        Console.WriteLine("  sale <sku> <quantity>        - Record a sale");
        Console.WriteLine("  reorder                      - Show products needing reorder");
        Console.WriteLine("  history <sku>                - Show transaction history");
        Console.WriteLine("  summary                      - Show inventory summary");
        Console.WriteLine("  export                       - Export inventory to JSON");
        Console.WriteLine("  help                         - Show this help");
    }

    static void HandleList(string[] args)
    {
        IEnumerable<Product> products;

        if (args.Length > 1)
        {
            var category = args[1];
            products = _inventoryService.GetProductsByCategory(category);
            Console.WriteLine($"Products in category '{category}':\n");
        }
        else
        {
            products = _inventoryService.GetAllProducts();
            Console.WriteLine("All products:\n");
        }

        DisplayProducts(products);
    }

    static void HandleAdd(string[] args)
    {
        if (args.Length < 7)
        {
            Console.WriteLine("Usage: inventory add <name> <sku> <category> <price> <quantity> <reorder-level>");
            return;
        }

        var name = args[1];
        var sku = args[2];
        var category = args[3];
        var price = decimal.Parse(args[4]);
        var quantity = int.Parse(args[5]);
        var reorderLevel = int.Parse(args[6]);

        var product = _inventoryService.AddProduct(name, sku, category, price, quantity, reorderLevel);
        Console.WriteLine($"Added product: {product.Name} (SKU: {product.Sku})");
    }

    static void HandleSearch(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: inventory search <term>");
            return;
        }

        var searchTerm = args[1];
        var products = _inventoryService.SearchProducts(searchTerm);

        Console.WriteLine($"Search results for '{searchTerm}':\n");
        DisplayProducts(products);
    }

    static void HandleRestock(string[] args)
    {
        if (args.Length < 3)
        {
            Console.WriteLine("Usage: inventory restock <sku> <quantity>");
            return;
        }

        var sku = args[1];
        var quantity = int.Parse(args[2]);

        var product = _inventoryService.FindProductBySku(sku);
        if (product == null)
        {
            Console.WriteLine($"Product with SKU '{sku}' not found");
            return;
        }

        _inventoryService.RestockProduct(product.Id, quantity, "CLI User");
        Console.WriteLine($"Restocked {quantity} units of {product.Name}. New stock: {product.QuantityInStock}");
    }

    static void HandleSale(string[] args)
    {
        if (args.Length < 3)
        {
            Console.WriteLine("Usage: inventory sale <sku> <quantity>");
            return;
        }

        var sku = args[1];
        var quantity = int.Parse(args[2]);

        var product = _inventoryService.FindProductBySku(sku);
        if (product == null)
        {
            Console.WriteLine($"Product with SKU '{sku}' not found");
            return;
        }

        _inventoryService.RecordSale(product.Id, quantity, "CLI User");
        Console.WriteLine($"Recorded sale of {quantity} units of {product.Name}. Remaining stock: {product.QuantityInStock}");
    }

    static void HandleReorderReport()
    {
        var products = _inventoryService.GetProductsNeedingReorder();

        Console.WriteLine("Products needing reorder:\n");
        DisplayProducts(products);

        if (!products.Any())
        {
            Console.WriteLine("  No products need reordering.");
        }
    }

    static void HandleHistory(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: inventory history <sku>");
            return;
        }

        var sku = args[1];
        var product = _inventoryService.FindProductBySku(sku);
        
        if (product == null)
        {
            Console.WriteLine($"Product with SKU '{sku}' not found");
            return;
        }

        var transactions = _inventoryService.GetTransactionHistory(product.Id);

        Console.WriteLine($"Transaction history for {product.Name} (SKU: {sku}):\n");

        foreach (var tx in transactions)
        {
            var sign = tx.Quantity >= 0 ? "+" : "";
            Console.WriteLine($"  {tx.TransactionDate:yyyy-MM-dd HH:mm} | {tx.Type,-12} | {sign}{tx.Quantity,6} | {tx.Reason} | by {tx.PerformedBy}");
        }

        if (!transactions.Any())
        {
            Console.WriteLine("  No transactions recorded.");
        }
    }

    static void HandleSummary()
    {
        var summary = _inventoryService.GetSummary();

        Console.WriteLine("Inventory Summary:");
        Console.WriteLine($"  Total Products:          {summary.TotalProducts}");
        Console.WriteLine($"  Total Inventory Value:   ${summary.TotalValue:N2}");
        Console.WriteLine($"  Products Needing Reorder: {summary.ProductsNeedingReorder}");
        Console.WriteLine($"  Discontinued Products:   {summary.DiscontinuedProducts}");
        Console.WriteLine($"  Total Transactions:      {summary.TotalTransactions}");
    }

    static void HandleExport()
    {
        var json = _inventoryService.ExportToJson();
        Console.WriteLine(json);
    }

    static void DisplayProducts(IEnumerable<Product> products)
    {
        foreach (var p in products)
        {
            var status = p.IsDiscontinued ? "[DISCONTINUED]" : (p.NeedsReorder ? "[REORDER]" : "");
            Console.WriteLine($"  {p.Sku,-12} | {p.Name,-25} | {p.Category,-15} | ${p.Price,8:N2} | Stock: {p.QuantityInStock,4} {status}");
        }
    }
}
