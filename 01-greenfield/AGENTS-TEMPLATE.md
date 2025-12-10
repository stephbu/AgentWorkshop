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
  /docs              - Documentation
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

> **Reference:** Follow the [.NET C# Coding Conventions](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions) as the baseline style guide. Project-specific conventions below extend or clarify the official guidelines.

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
  - Interfaces: prefix with `I` (e.g., `IGameService`)
  - Async methods: suffix with `Async` (e.g., `SaveAsync`)

- **Parameters, Local Variables:** camelCase

- **Private Fields:** `_camelCase` with underscore prefix

- **Constants:** UPPER_SNAKE_CASE or PascalCase (be consistent)

---

## Namespace Conventions

```csharp
namespace ProjectName.FolderName;

// Example:
namespace HighLow.Services;
namespace HighLow.Models;
```

---

## Documentation Standards

### XML Documentation Comments
Required on:
- All public classes, interfaces, enums
- All public methods and properties
- Complex internal methods

### Project Documentation

Store all project documentation in the `/docs` folder using Markdown format.

**Documentation Requirements:**
- Use Markdown (`.md`) for all documentation files
- Store documentation in `/docs` folder at project root
- Update documentation after each action or change completes
- Use proper heading hierarchy (`#`, `##`, `###`, etc.)

**Recommended `/docs` Structure:**
```
/docs
  README.md              - Documentation index/overview
  architecture.md        - System architecture and design decisions
  api.md                 - API reference (if applicable)
  setup.md               - Development environment setup
  deployment.md          - Build and deployment instructions
  changelog.md           - Version history and changes
```

**Documentation Style:**
- Start each document with a level-1 heading (`#`)
- Use level-2 headings (`##`) for major sections
- Use level-3 headings (`###`) for subsections
- Include code examples in fenced code blocks with language hints
- Keep documentation up-to-date with code changes

---

## Error Handling Pattern

### Exceptions
- Use for truly exceptional situations (file not found, network error, etc.)
- Create custom exceptions when appropriate: `InvalidGuessException`
- Never swallow exceptions silently

### Result Pattern (Optional)
For expected failures (validation, not found), consider using a Result<T> type with IsSuccess, Value, and Error properties.

### Logging
- Log errors with context (what operation failed, relevant IDs)
- Use structured logging if applicable
- Don't log sensitive data (passwords, tokens, etc.)

---

## Testing Standards

### Test Classification

Classify all unit tests as either **Fast** or **Slow**:

**Fast Tests:**
- Complete in milliseconds
- No I/O operations (file, network, database)
- No async/await delays
- No intensive computation
- Run in-memory only
- Should make up the majority of tests

**Slow Tests:**
- Involve file system, network, or database I/O
- Include async operations with real delays
- Require intensive computation
- Integration tests that cross boundaries

Use test categories/traits to mark slow tests so they can be excluded from quick test runs.

### Test Organization
- One test class per production class
- Test class name: `[ClassUnderTest]Tests`
- Test file location: mirrors source structure in `/tests`

### Test Naming
Use the pattern: `[Method]_[Scenario]_[ExpectedResult]`

Examples:
- `CompareCards_HigherCard_ReturnsPositive`
- `CalculateScore_WithStreak_AppliesMultiplier`
- `ShuffleDeck_WithSeed_ProducesDeterministicOrder`

### Test Structure (AAA Pattern)
Use Arrange-Act-Assert pattern:
- **Arrange:** Set up test data and dependencies
- **Act:** Execute the method under test
- **Assert:** Verify the expected outcome

### Mocking
- Mock external dependencies (file I/O, random number generation)
- Use a mocking framework (e.g., Moq, NSubstitute) if needed
- Don't mock the class under test
- Use seeded Random for deterministic shuffle tests

### Test After Every Change

**Run affected tests after each code change:**
- Before committing, run all tests that cover modified code
- Run Fast tests continuously during development
- Run full test suite (including Slow tests) before pull requests
- Fix broken tests immediately—don't accumulate test debt

**Verify test coverage for changes:**
- New code must have corresponding tests
- Modified code must have tests updated if behavior changed
- Deleted code should have associated tests removed

### Test Library Maintenance

**Keep the test suite healthy:**
- Remove obsolete tests when features are removed
- Update tests when requirements change
- Refactor test code to reduce duplication
- Keep tests independent—no shared mutable state between tests

**Organize tests for discoverability:**
- Group related tests in the same test class
- Use descriptive test names that explain the scenario
- Add comments for complex test setups

**Monitor test quality:**
- Tests should fail for the right reasons
- Avoid brittle tests that break on unrelated changes
- Each test should verify one specific behavior

---

## Instructions for AI Agents

When working in this codebase:

1. **Always read AGENTS.md first** to understand conventions

2. **Follow the established patterns** in existing code

3. **Create tests alongside implementation** - never add features without tests

4. **Use dependency injection** for services to enable testing

5. **Keep entry points thin** - business logic belongs in services

6. **Handle edge cases explicitly** - document any assumptions

7. **Use meaningful variable names** - code should be self-documenting

8. **Validate inputs at boundaries** - services should validate their inputs

---

## Checklist

Before finalizing your AGENTS.md, verify:

- [ ] Project overview clearly describes purpose
- [ ] Tech stack is accurate and complete
- [ ] Project structure reflects actual layout
- [ ] Coding conventions are specific and actionable
- [ ] Testing standards include Fast/Slow classification
- [ ] Instructions for agents are clear and prioritized
