# AGENTS.md Template (Brownfield / Existing Project)

Use this template to document an **existing codebase** that doesn't have an AGENTS.md yet.

**Tip:** Ask an AI agent to help generate the first draft by analyzing the code, then refine it.

---

# AGENTS.md

## Project Overview

**What:** [What this application/service does]

**Purpose:** [Why it exists, what problem it solves]

**History:** [Brief context: age of project, major changes, current status]

**Users:** [Who uses this system]

---

## Tech Stack

- **Language:** C# [version]
- **Framework:** .NET [version]
- **Key Libraries:** [List NuGet packages and their purposes]
- **Testing:** [Test framework if present, or "No tests currently"]
- **Data Storage:** [Database, files, in-memory, etc.]
- **External Dependencies:** [APIs, services, etc.]

---

## Project Structure

```
/ProjectName
  /[Folder1]      - [What lives here]
  /[Folder2]      - [What lives here]
  /[Folder3]      - [What lives here]
  [Key files]
```

**Example:**
```
/BookLibrary
  /Models         - Domain entities (Book, BookStatus, etc.)
  /Services       - Business logic (BookService)
  Program.cs      - CLI entry point and command handlers
  BookLibrary.csproj
  README.md
```

---

## Observed Conventions

*These are patterns discovered in the existing codebase, not necessarily ideal.*

### Code Style
- **Namespace style:** [file-scoped / traditional]
- **Using statements:** [inside namespace / outside namespace / implicit]
- **Null handling:** [nullable reference types enabled / disabled]
- **Async/await:** [used consistently / not used / mixed]

### Naming Conventions
- **Classes/Interfaces:**
- **Methods:**
- **Properties:**
- **Fields:**
- **Parameters:**

**Example:**
- Classes: PascalCase (`BookService`, `Book`)
- Methods: PascalCase (`AddBook`, `GetAllBooks`)
- Parameters: camelCase (`title`, `author`)
- Private fields: Plain camelCase, no underscore prefix

### Organization
- **One class per file:** [Yes / No / Mostly]
- **File naming:** [Matches class name / other pattern]
- **Folder structure:** [Organized by type / by feature / flat]

---

## Key Components

Document the main pieces of the system:

### [Component Name 1]
**Purpose:** [What it does]  
**Location:** [File/folder path]  
**Responsibilities:** [List key responsibilities]  
**Dependencies:** [What it depends on]

**Example:**

### BookService
**Purpose:** Core business logic for managing books  
**Location:** `/Services/BookService.cs`  
**Responsibilities:**
- Add/remove books
- Search functionality
- Checkout/return operations
- Validation logic

**Dependencies:** None (in-memory list)

### Program.cs
**Purpose:** CLI entry point and command routing  
**Location:** `/Program.cs`  
**Responsibilities:**
- Parse command-line arguments
- Route to appropriate handler
- Format output
- Error handling

**Dependencies:** BookService

---

## Patterns & Practices

### Error Handling
[Describe how errors are handled in the existing code]

**Example:**
- Exceptions thrown for validation failures
- `ArgumentException` for invalid input
- `InvalidOperationException` for state violations
- Errors printed to console with `Console.WriteLine($"Error: {ex.Message}")`
- Application exits with code 1 on error

### Validation
[Where and how validation happens]

**Example:**
- Input validation at service layer (BookService)
- Uses `string.IsNullOrWhiteSpace()` for string checks
- Throws exceptions with descriptive messages

### Data Access
[How data is retrieved/stored]

**Example:**
- In-memory `List<Book>` - no persistence
- No repository pattern
- Direct access to list in service

### Dependency Management
[How dependencies are handled]

**Example:**
- No dependency injection framework
- Direct instantiation: `new BookService()`
- Services are stateful (maintain in-memory list)

---

## Known Issues & Technical Debt

Document problems or limitations in the existing code:

- [ ] **Issue 1:** [Description and impact]
- [ ] **Issue 2:** [Description and impact]

**Example:**
- ❗ **No persistence:** Books only exist in memory, lost on exit
- ❗ **No duplicate detection:** Can add same book multiple times
- ❗ **No tests:** Zero test coverage
- ⚠️ **Monolithic Program.cs:** All command handling in one file
- ⚠️ **Global state:** BookService holds state, not thread-safe

---

## Areas to Avoid or Be Careful With

List parts of the codebase that are fragile or shouldn't be changed lightly:

- ⚠️ [Component/file]: [Why to be careful]

**Example:**
- ⚠️ **Book model:** Changing properties will affect serialization if added later
- ⚠️ **Command syntax:** Users expect current command format, breaking changes will cause issues
- ⚠️ **BookService state:** Other code may depend on in-memory list behavior

---

## Conventions for New Code

*Now that you understand what exists, define how NEW code should be written.*

### Follow Existing Patterns
When adding new features:
1. **Match existing style** - Even if not ideal, consistency matters
2. **Use similar naming** - Follow established conventions
3. **Replicate error handling** - Same exception types, same messages format
4. **Mirror structure** - If adding a command, follow existing command pattern

### Acceptable Improvements
You CAN improve in these ways without breaking consistency:
- ✅ Add XML documentation (existing code lacks it, but it's additive)
- ✅ Add validation where missing (doesn't break existing behavior)
- ✅ Add null checks (makes code more robust)
- ✅ Extract magic strings to constants

### Avoid These Changes
Don't make these changes unless specifically required:
- ❌ Refactoring existing working code "just because"
- ❌ Introducing new patterns (DI, repository) to only one part
- ❌ Changing existing public interfaces (breaks compatibility)
- ❌ Reformatting all existing code to your preference

---

## Integration Guidelines

### Adding a New Command
If adding a CLI command:

1. Add handler method in `Program.cs`
2. Add case to switch statement in `Main()`
3. Add help text to `ShowHelp()`
4. Follow pattern: parse args → validate → call service → format output
5. Use existing error handling style

### Adding to BookService
If adding service methods:

1. Add public method to `BookService` class
2. Validate parameters (throw `ArgumentException` if invalid)
3. Use existing collection (`_books`)
4. Return appropriate type or throw exception on failure

### Adding Properties to Book
If modifying the Book model:

1. Add properties to `Book` class in `/Models/Book.cs`
2. Update existing service methods if needed
3. Update `PrintBook()` in `Program.cs` to display new properties
4. Consider backward compatibility (nullable for optional properties)

---

## Testing Strategy

*Since tests don't exist yet, define the strategy for adding them:*

### When Tests Should Be Added
- For any new feature with complex logic
- For any bug fixes (test the bug first)
- For validation logic

### Proposed Testing Approach
- Use xUnit (common for .NET)
- Create `/tests/BookLibrary.Tests/` folder
- Test class per production class: `BookServiceTests`, etc.
- Use AAA pattern (Arrange-Act-Assert)

### Test Naming
```
[Method]_[Scenario]_[ExpectedResult]

Examples:
AddBook_WithValidData_ReturnsBook
AddBook_WithEmptyTitle_ThrowsArgumentException
```

---

## Future Improvements

Document desired improvements (don't implement unless tasked):

- [ ] Add persistence (JSON file or database)
- [ ] Add unit tests
- [ ] Extract command handlers to separate classes
- [ ] Add configuration file for settings
- [ ] Implement repository pattern
- [ ] Add logging framework

---

## Instructions for AI Agents

When working in this codebase:

### First Time Working Here
1. **Read this AGENTS.md completely** to understand the project
2. **Review existing code** before suggesting changes
3. **Ask clarifying questions** if conventions are unclear

### Making Changes
1. **Follow existing patterns first** - Consistency > "best practices"
2. **Match the existing style** - Naming, formatting, structure
3. **Don't refactor unrelated code** - Stay focused on the task
4. **Test existing functionality** - Don't break what works

### Error Handling
- Throw `ArgumentException` for validation failures
- Throw `InvalidOperationException` for state violations
- Use descriptive messages
- Let exceptions propagate to `Main()` for handling

### When Unsure
- Look for similar existing code as an example
- Follow the most recent pattern if there's inconsistency
- Ask for clarification rather than guessing

---

## Documentation Standards

### XML Documentation
Existing code lacks XML docs, but ADD them to new code:

```csharp
/// <summary>
/// [What this does]
/// </summary>
/// <param name="paramName">[Parameter description]</param>
/// <returns>[What is returned]</returns>
```

### Comments
- Comment WHY, not WHAT (code should be self-explanatory)
- Add comments for non-obvious logic
- Don't comment every line

---

## Work Unit Guidelines

**Human-Reviewable Work Size:**
- **Maximum:** 1 feature or ~300 lines of changed code per PR
- **Rationale:** Beyond this, quality of review drops significantly
- **For AI-generated code:** Even more important—easier to verify correctness
- **For brownfield:** Consider existing complexity when sizing changes

**Breaking Down Work:**
- Split large features into logical phases
- Each phase should be independently testable
- Each phase should be deployable (even if feature-flagged)
- Prioritize phases: Core → Nice-to-have → Polish
- In brownfield, phases might align with existing modules/subsystems

**Examples:**
```markdown
❌ Too Large:
"Refactor entire authentication system" (1000+ lines, many files)

✅ Right Size:
Phase 1: "Extract auth interface" (~150 lines, 3 files)
Phase 2: "Implement JWT provider" (~200 lines, 4 files)
Phase 3: "Migrate existing code" (~250 lines, 5 files)
```

**Benefits:**
- Faster, higher-quality code reviews
- Easier to track progress
- Simpler to roll back if issues arise
- Agents can focus on one coherent unit
- Team can prioritize and parallelize work
- Lower risk when modifying existing code

---

## Example: Adding a New Feature

**Scenario:** Add book categories

### Step 1: Update the model
```csharp
// Models/Book.cs
public string? Category { get; set; }
```

### Step 2: Update service
```csharp
// Services/BookService.cs
public Book AddBook(string title, string author, string isbn, string? category = null)
{
    // ... existing validation ...
    
    var book = new Book
    {
        // ... existing properties ...
        Category = category
    };
    
    // ... rest of method ...
}

public IReadOnlyList<Book> SearchByCategory(string category)
{
    if (string.IsNullOrWhiteSpace(category))
        return new List<Book>().AsReadOnly();
        
    return _books
        .Where(b => b.Category?.Equals(category, StringComparison.OrdinalIgnoreCase) == true)
        .ToList()
        .AsReadOnly();
}
```

### Step 3: Update CLI
```csharp
// Program.cs - Add to switch statement
case "category":
    HandleSearchByCategory(bookService, args);
    break;

// Add handler
static void HandleSearchByCategory(BookService service, string[] args)
{
    if (args.Length < 2)
    {
        Console.WriteLine("Usage: booklibrary category <category-name>");
        return;
    }
    
    var category = args[1];
    var results = service.SearchByCategory(category);
    
    // ... format and display results (follow existing pattern) ...
}
```

### Step 4: Update help text
```csharp
// In ShowHelp()
Console.WriteLine("  category <name>                  - Search by category");
```

---

## Maintenance

This AGENTS.md should be updated when:
- New patterns are established
- Conventions change
- New components are added
- Technical debt is fixed
- Gotchas are discovered

**Treat this as living documentation!**

---

## Contact / Questions

For questions about this codebase:
- Original author: [if known]
- Current maintainer: [if known]
- Documentation: [link to wiki/confluence/etc. if exists]
