# Brownfield Exercise: Code Modernization

**Duration:** ~45 minutes  
**Goal:** Learn to use AI agents for code modernization while ensuring all tests continue to pass.

---

## Overview

In this exercise, you will:
1. Explore a codebase with older patterns and existing unit tests
2. Create an AGENTS.md documenting the current state
3. Use AI agents to modernize the codebase
4. Upgrade dependencies and language features
5. Verify all unit tests pass after modernization

---

## The Project: Legacy Inventory System

The `LegacyInventory` project is an inventory management CLI built with older patterns:

**Current Stack:**
- .NET 8.0 with C# 10 (LangVersion pinned)
- Newtonsoft.Json 13.0.1 (legacy JSON library)
- Traditional constructors (not using primary constructors)
- xUnit 2.4.2 (older version)

**Your Task:** Modernize to C# 12 with modern patterns while maintaining all existing functionality.

---

## Part 1: Explore and Understand (10 minutes)

### Step 1.1: Review the current state

Navigate to the project:
```bash
cd /02-brownfield/LegacyInventory
```

**Check the current configuration:**
```bash
cat LegacyInventory.csproj
```

You'll see:
```xml
<TargetFramework>net8.0</TargetFramework>
<LangVersion>10</LangVersion>
```

### Step 1.2: Run existing tests

**Verify the current state works:**
```bash
dotnet test LegacyInventory.sln
```

✅ All tests should pass. **Document the test count** - you'll need all tests to pass after modernization!

### Step 1.3: Use the agent to analyze

**Prompt:**
```
Analyze the LegacyInventory project and tell me:
1. What C# language version is it currently using?
2. What NuGet packages are being used?
3. What C# language features are being used?
4. Are there any deprecated patterns or APIs?
5. What modernizations could be applied with C# 12?
```

---

## Part 2: Create AGENTS.md (10 minutes)

### Step 2.1: Document current state

Before making changes, document the current state in AGENTS.md:

**Prompt:**
```
Create an AGENTS.md for this LegacyInventory project that documents:
1. Project overview (what it does)
2. Current tech stack (.NET 8.0, C# 10 pinned, dependencies)
3. Project structure
4. Coding conventions observed
5. Testing approach
6. Known limitations

Also add a section for "Modernization Notes" that will track changes made during the C# 12 upgrade.
```

Save to: `/02-brownfield/LegacyInventory/AGENTS.md`

### Step 2.2: Document upgrade goals

Add this section to your AGENTS.md:

```markdown
## Modernization Goals

### Target State
- C# 12 (remove pinned LangVersion)
- Updated NuGet packages to latest stable versions
- Replace Newtonsoft.Json with System.Text.Json (optional)
- Use modern C# features where appropriate

### Constraints
- All existing unit tests must pass
- No breaking changes to CLI interface
- Maintain backward compatibility for commands

### Success Criteria
- [ ] Project builds with C# 12
- [ ] All unit tests pass
- [ ] CLI commands work as before
- [ ] No compiler warnings
```

---

## Part 3: Perform the Modernization (20 minutes)

### Step 3.1: Create modernization plan with agent

**Prompt:**
```
I need to modernize this project from C# 10 to C# 12. 

Create a phased modernization plan that:
1. Updates the LangVersion in .csproj files (or removes it to use latest)
2. Updates NuGet packages to latest versions
3. Uses C# 12 language features where beneficial
4. Optionally migrates from Newtonsoft.Json to System.Text.Json
5. Ensures all tests continue to pass

Break this into small, testable steps. After each step, I should be able to run tests.
```

### Step 3.2: Execute modernization - Language version first

**Prompt:**
```
Start with Phase 1: Update the language version.

Update LegacyInventory.csproj to:
- Use C# 12 (or latest)
- Remove explicit LangVersion to use the SDK default

Also update Tests/LegacyInventory.Tests.csproj to match.

Show me the exact changes needed.
```

**After changes, verify:**
```bash
dotnet build LegacyInventory.sln
dotnet test LegacyInventory.sln
```

✅ All tests must pass before proceeding!

### Step 3.3: Execute modernization - Dependencies

**Prompt:**
```
Phase 2: Update NuGet packages.

Update all NuGet packages to their latest versions:
- Newtonsoft.Json (or migrate to System.Text.Json)
- Microsoft.NET.Test.Sdk
- xunit
- xunit.runner.visualstudio
- coverlet.collector

Show me the updated package references.
```

**Verify after each change:**
```bash
dotnet restore
dotnet build LegacyInventory.sln
dotnet test LegacyInventory.sln
```

### Step 3.4: Modernize code (optional)

**Prompt:**
```
Phase 3: Modernize the code using C# 12 features.

Review the codebase and suggest improvements using modern C# features:
- Primary constructors
- Collection expressions
- Pattern matching improvements
- File-scoped namespaces (already used)
- Any other applicable features

Make changes incrementally and explain each change.
Ensure tests pass after each change.
```

**Example modernizations:**

Before (C# 10):
```csharp
private readonly List<Product> _products = new List<Product>();
```

After (C# 12):
```csharp
private readonly List<Product> _products = [];
```

Before:
```csharp
if (product == null)
    throw new InvalidOperationException($"Product with ID '{productId}' not found");
```

After:
```csharp
ArgumentNullException.ThrowIfNull(product, nameof(productId));
```

### Step 3.5: Migrate JSON library (optional advanced)

**Prompt:**
```
Phase 4 (Optional): Migrate from Newtonsoft.Json to System.Text.Json.

The serialization code in InventoryService uses Newtonsoft.Json.
Migrate it to System.Text.Json which is built into .NET.

Show me:
1. What code changes are needed
2. Any behavioral differences to be aware of
3. Updated tests if needed
```

---

## Part 4: Verify and Document (5 minutes)

### Step 4.1: Run full test suite

```bash
cd /02-brownfield/LegacyInventory
dotnet test LegacyInventory.sln --verbosity normal
```

**Verify:**
- ✅ Same number of tests as before
- ✅ All tests pass
- ✅ No warnings

### Step 4.2: Test CLI functionality

```bash
cd /02-brownfield/LegacyInventory
dotnet run -- list
dotnet run -- add "Test Product" "SKU001" 9.99 10 "Test Category"
dotnet run -- list
dotnet run -- low-stock 15
dotnet run -- help
```

**Verify:** All commands work as expected.

### Step 4.3: Update AGENTS.md

**Prompt:**
```
Update the AGENTS.md to reflect the completed modernization:
1. Update tech stack to show C# 12
2. Document what changed during modernization
3. Mark modernization goals as complete
4. Add notes about any changes made
```

---

## Reflection Questions

1. **What challenges did you encounter during the modernization?**
   - Package compatibility issues?
   - Breaking API changes?
   - Test failures?

2. **How did the agent help with the modernization?**
   - Identifying what needed to change?
   - Suggesting modern alternatives?
   - Explaining new language features?

3. **What would you do differently next time?**
   - Different phasing?
   - More/fewer tests first?
   - Different approach to modernization?

4. **How important was the test suite during this process?**
   - Did it catch any issues?
   - Did it give you confidence to make changes?

---

## Key Takeaways

✅ **Always run tests before starting** - Establish a baseline  
✅ **Modernize in phases** - Language → Dependencies → Code  
✅ **Test after each phase** - Catch issues early  
✅ **Document changes** - Update AGENTS.md as you go  
✅ **Agents are great at modernization** - They know language features and patterns  
✅ **Tests are your safety net** - They catch regressions  

---

## Bonus Challenges

If you finish early, try these:

### Challenge 1: Add More Modernizations
- Use `required` properties in models
- Add `init` setters where appropriate
- Use `record` types for DTOs

### Challenge 2: Improve Test Coverage
```
Analyze the test coverage and suggest additional test cases
for edge cases that aren't currently tested.
```

### Challenge 3: Add New C# 12 Features
- Use primary constructors throughout
- Apply collection expressions everywhere
- Use `nameof` for exception messages

---

## Resources

- [C# 12 Features](https://learn.microsoft.com/dotnet/csharp/whats-new/csharp-12)
- [Primary Constructors](https://learn.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/instance-constructors#primary-constructors)
- [Migrate from Newtonsoft.Json to System.Text.Json](https://learn.microsoft.com/dotnet/standard/serialization/system-text-json/migrate-from-newtonsoft)
- [Collection Expressions](https://learn.microsoft.com/dotnet/csharp/language-reference/operators/collection-expressions)
