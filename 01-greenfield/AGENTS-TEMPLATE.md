# AGENTS.md Template (Greenfield Project)

Use this template to create an `AGENTS.md` file for a new C# project.

---

# AGENTS.md

## Project Overview

**What:** [Brief description of what this application does]

**Why:** [The problem it solves or value it provides]

**Users:** [Who will use this]

---

## Tech Stack

- **Language:** C# 12
- **Framework:** .NET 8.0
- **Key Libraries:** [e.g., System.CommandLine, Entity Framework, etc.]
- **Testing:** xUnit
- **Data Storage:** [e.g., JSON files, SQLite, PostgreSQL, etc.]

---

## Project Structure

```
/ProjectName
  /src
    /ProjectName
      /Commands      - [Describe what goes here]
      /Models        - [Describe what goes here]
      /Services      - [Describe what goes here]
      /Infrastructure - [Describe what goes here]
      Program.cs
  /tests
    /ProjectName.Tests
      /[Mirror src structure]
  AGENTS.md
  README.md
  .gitignore
```

---

## Coding Conventions

### Language Features
- Use C# 12 features (primary constructors, file-scoped namespaces, etc.)
- Prefer `async`/`await` for I/O operations
- Use pattern matching where appropriate
- Leverage nullable reference types

### Code Organization
- One class per file
- File name matches class name
- Use file-scoped namespaces
- Order members: fields, properties, constructors, methods

### Dependency Injection
- Use constructor injection
- Register services in `Program.cs`
- Avoid service locator pattern

---

## Naming Conventions

- **Classes, Interfaces, Methods, Properties:** PascalCase
  - Interfaces: prefix with `I` (e.g., `ITaskRepository`)
  - Async methods: suffix with `Async` (e.g., `SaveAsync`)

- **Parameters, Local Variables:** camelCase

- **Private Fields:** `_camelCase` with underscore prefix

- **Constants:** UPPER_SNAKE_CASE or PascalCase (be consistent)

---

## Namespace Conventions

```csharp
namespace ProjectName.FolderName;

// Example:
namespace MyTaskManager.Services;
namespace MyTaskManager.Models;
```

---

## Documentation Standards

### XML Documentation Comments
Required on:
- All public classes, interfaces, enums
- All public methods and properties
- Complex internal methods

**Example:**
```csharp
/// <summary>
/// Manages task creation, retrieval, and persistence.
/// </summary>
public class TaskService
{
    /// <summary>
    /// Adds a new task to the system.
    /// </summary>
    /// <param name="title">The task title.</param>
    /// <param name="description">Optional task description.</param>
    /// <returns>The created task with generated ID.</returns>
    public async Task<TaskItem> AddTaskAsync(string title, string? description = null)
    {
        // ...
    }
}
```

---

## Error Handling Pattern

### Exceptions
- Use for truly exceptional situations (file not found, network error, etc.)
- Create custom exceptions when appropriate: `TaskNotFoundException`
- Never swallow exceptions silently

### Result Pattern (Optional)
For expected failures (validation, not found), consider:
```csharp
public class Result<T>
{
    public bool IsSuccess { get; init; }
    public T? Value { get; init; }
    public string? Error { get; init; }
}
```

### Logging
- Log errors with context (what operation failed, relevant IDs)
- Use structured logging if applicable
- Don't log sensitive data (passwords, tokens, etc.)

---

## Testing Standards

### Test Organization
- One test class per production class
- Test class name: `[ClassUnderTest]Tests`
- Test file location: mirrors source structure in `/tests`

### Test Naming
```csharp
[Method]_[Scenario]_[ExpectedResult]

// Examples:
public void AddTask_WithValidData_ReturnsNewTask()
public void CompleteTask_WithInvalidId_ThrowsTaskNotFoundException()
public async Task SaveTasks_WithEmptyList_CreatesEmptyJsonFile()
```

### Test Structure (AAA Pattern)
```csharp
[Fact]
public async Task AddTask_WithValidData_ReturnsNewTask()
{
    // Arrange
    var service = new TaskService();
    var title = "Test task";

    // Act
    var result = await service.AddTaskAsync(title);

    // Assert
    Assert.NotNull(result);
    Assert.Equal(title, result.Title);
    Assert.NotEqual(Guid.Empty, result.Id);
}
```

### Mocking
- Mock external dependencies (file I/O, databases, APIs)
- Use a mocking framework (e.g., Moq, NSubstitute) if needed
- Don't mock the class under test

---

## Instructions for AI Agents

When working in this codebase:

1. **Always read AGENTS.md first** to understand conventions

2. **Follow existing patterns**
   - Look at similar classes before creating new ones
   - Match the style of surrounding code

3. **Create tests alongside implementation**
   - Write test class when creating production class
   - Cover happy path and error cases

4. **Use dependency injection**
   - Constructor injection for dependencies
   - Register in `Program.cs` or DI container

5. **Async all the way**
   - Use `async`/`await` for I/O operations
   - Suffix async methods with `Async`
   - Return `Task` or `Task<T>`

6. **Never hardcode**
   - File paths → configuration or environment variables
   - Magic numbers → named constants
   - Connection strings → configuration

7. **Handle errors appropriately**
   - Validate input early
   - Throw meaningful exceptions
   - Log failures with context

8. **XML comments on public APIs**
   - Brief `<summary>` required
   - Document parameters and return values
   - Include examples if behavior is complex

---

## Example Code Style

### Models
```csharp
namespace MyTaskManager.Models;

/// <summary>
/// Represents the status of a task.
/// </summary>
public enum TaskStatus
{
    Pending,
    Complete
}

/// <summary>
/// Represents a task item in the system.
/// </summary>
public class TaskItem
{
    /// <summary>
    /// Gets the unique identifier for the task.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Gets the task title.
    /// </summary>
    public required string Title { get; init; }

    /// <summary>
    /// Gets the optional task description.
    /// </summary>
    public string? Description { get; init; }

    /// <summary>
    /// Gets or sets the task status.
    /// </summary>
    public TaskStatus Status { get; set; } = TaskStatus.Pending;

    /// <summary>
    /// Gets the creation timestamp.
    /// </summary>
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}
```

### Services
```csharp
namespace MyTaskManager.Services;

/// <summary>
/// Service for managing tasks.
/// </summary>
public class TaskService(ITaskRepository repository)
{
    private readonly ITaskRepository _repository = repository;

    /// <summary>
    /// Adds a new task.
    /// </summary>
    public async Task<TaskItem> AddTaskAsync(string title, string? description = null)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(title);

        var task = new TaskItem
        {
            Id = Guid.NewGuid(),
            Title = title,
            Description = description
        };

        await _repository.SaveTaskAsync(task);
        return task;
    }
}
```

---

## Work Unit Guidelines

**Human-Reviewable Work Size:**
- **Maximum:** 1 feature or ~300 lines of changed code per PR
- **Rationale:** Beyond this, quality of review drops significantly
- **For AI-generated code:** Even more important—easier to verify correctness

**Breaking Down Work:**
- Split large features into logical phases
- Each phase should be independently testable
- Each phase should be deployable (even if feature-flagged)
- Prioritize phases: Core → Nice-to-have → Polish

**Examples:**
```markdown
❌ Too Large:
"Complete task management system" (1000+ lines, many files)

✅ Right Size:
Phase 1: "Add and list tasks" (~200 lines, 3-4 files)
Phase 2: "Complete and delete tasks" (~150 lines, 2-3 files)
Phase 3: "Search and filter" (~200 lines, 3-4 files)
```

**Benefits:**
- Faster, higher-quality code reviews
- Easier to track progress
- Simpler to roll back if issues arise
- Agents can focus on one coherent unit
- Team can prioritize and parallelize work

---

## Common Pitfalls to Avoid

❌ **Don't:**
- Mix business logic into command handlers
- Use `Console.WriteLine` in services (use logging or return values)
- Hardcode file paths or configuration values
- Catch exceptions without handling or rethrowing
- Forget to await async methods

✅ **Do:**
- Keep commands thin—delegate to services
- Return values from services; command handlers format output
- Use configuration for environment-specific values
- Let exceptions bubble up or handle them meaningfully
- Await all async operations

---

## Evolution & Maintenance

This `AGENTS.md` should evolve as the project grows:

- **Add patterns** as they emerge
- **Document gotchas** when discovered
- **Update examples** to reflect current codebase
- **Refine conventions** based on what works

Treat this as living documentation—not set in stone!

---

## Questions?

If this document is unclear or doesn't cover a scenario, ask the agent:

*"How should I handle [scenario] given the conventions in AGENTS.md?"*

The agent can infer from patterns and make reasonable suggestions.
