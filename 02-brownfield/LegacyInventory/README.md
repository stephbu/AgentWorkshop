# Legacy Inventory System

A command-line inventory management system built with .NET 8.0 and C# 10.

> **Workshop Exercise:** This project uses older C# patterns intentionally. The goal is to modernize it to C# 12 using AI agents while ensuring all tests pass.

## Features

- Add and manage products
- Track stock levels with reorder alerts
- Record sales and restocking
- Transaction history
- JSON file persistence

## Usage

```bash
dotnet run -- <command> [options]
```

### Commands

| Command | Description |
|---------|-------------|
| `list` | List all products |
| `add <name> <sku> <price> <qty> <category>` | Add a new product |
| `update-stock <id> <qty-change> <type> [notes]` | Update stock (type: Sale, Restock, Adjustment, Return) |
| `low-stock [threshold]` | Show products at or below threshold (default: 10) |
| `transactions [id]` | Show all transactions (or for specific product) |
| `remove <id>` | Remove a product |
| `help` | Show help |

### Examples

```bash
# List all products
dotnet run -- list

# Add a product
dotnet run -- add "Wireless Mouse" "SKU-001" 29.99 50 "Electronics"

# Record a sale (reduces stock by 5)
dotnet run -- update-stock 1 -5 Sale "Customer order #123"

# Restock a product
dotnet run -- update-stock 1 20 Restock "Shipment received"

# View low stock products
dotnet run -- low-stock 15

# View transaction history
dotnet run -- transactions 1
```

## Running Tests

```bash
dotnet test LegacyInventory.sln
```

## Technical Details

- **Framework:** .NET 8.0
- **Language:** C# 10 (LangVersion pinned)
- **Dependencies:** Newtonsoft.Json 13.0.1
- **Test Framework:** xUnit 2.4.2

## Modernization Opportunities

This project was intentionally created with older patterns for the workshop exercise:

1. **LangVersion pinned to 10** - Can be removed to use C# 12
2. **Newtonsoft.Json** - Can be migrated to System.Text.Json
3. **Traditional constructors** - Can use primary constructors
4. **Older collection syntax** - Can use collection expressions

See [../UPGRADE-EXERCISE.md](../UPGRADE-EXERCISE.md) for the full exercise instructions.
