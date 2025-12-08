# AI Agent Development Cheat Sheet

Quick reference for common tasks and patterns.

## Table of Contents

- [Essential Files](#essential-files)
- [AGENTS.md Quick Template](#agentsmd-quick-template)
- [Requirements Quick Template](#requirements-quick-template)
- [Common Prompts](#common-prompts)
- [Example Prompt Instructions](#example-prompt-instructions)
- [CLI Command Pattern (C#)](#cli-command-pattern-c)
- [Test Pattern (xUnit)](#test-pattern-xunit)
- [Error Handling Patterns](#error-handling-patterns)
- [Git Commands for Workshop](#git-commands-for-workshop)
- [.NET CLI Quick Reference](#net-cli-quick-reference)
- [VS Code Shortcuts](#vs-code-shortcuts)
- [GitHub Copilot Tips](#github-copilot-tips)
- [Debugging Checklist](#debugging-checklist)
- [Common Gotchas](#common-gotchas)
- [MCP Server Commands (Optional)](#mcp-server-commands-optional)
- [Workshop Workflow Summary](#workshop-workflow-summary)
- [When You're Stuck](#when-youre-stuck)
- [Key Principles](#key-principles)
- [Resources](#resources)

---

## Essential Files

| File | Purpose | When to Create | Auto-Read by Copilot |
|------|---------|----------------|---------------------|
| `/AGENTS.md` | Project conventions, patterns, instructions | First thing in greenfield; ASAP in brownfield | ✅ Yes - automatically loaded |
| `requirements/FEATURE.md` | Feature requirements, implementation plan | Before implementing each feature | ❌ Reference manually |
| `README.md` | User-facing documentation | Day 1 of project | ❌ Not auto-loaded |
| `.gitignore` | Excluded files | Day 1 of project | ❌ Not auto-loaded |

**Key:** AGENTS.md at project root (`/AGENTS.md`) is automatically read by GitHub Copilot. You don't need to reference it in prompts!

---

## AGENTS.md Quick Template

**Location:** `/AGENTS.md` (project root - important for auto-loading!)

```markdown
# AGENTS.md

## Project Overview
[1-2 sentences: what and why]

## Tech Stack
- Language: C# 12
- Framework: .NET 8.0
- Key Libraries: [list]

## Project Structure
/src/[Project]
  /Folder1  - [purpose]
  /Folder2  - [purpose]

## Coding Conventions
- Namespaces: file-scoped
- Async: suffix with Async
- Naming: PascalCase for public, camelCase for parameters

## Instructions for Agents
1. Follow existing patterns
2. Add tests with implementations
3. [Key rule 3]
```

**Remember:** Once created at `/AGENTS.md`, Copilot reads it automatically for every interaction!

---

## Requirements Quick Template

```markdown
# Feature: [Name]

## Overview
[What this does in 1-2 sentences]

## Requirements
- [ ] Requirement 1
- [ ] Requirement 2

## Acceptance Criteria
Given [context]
When [action]
Then [result]

## Examples
```bash
$ command example
[expected output]
```

## Edge Cases
- [Case 1]: [How to handle]
- [Case 2]: [How to handle]

## Implementation Plan
1. [Step 1: components to create/modify]
2. [Step 2: integration approach]
3. [Step 3: testing strategy]
```

---

## Common Prompts

### Ask Questions First!

**Before implementing anything, ask the agent for help:**

- `"What information do you need to implement this feature?"`
- `"What should I include in AGENTS.md for this type of project?"`
- `"What edge cases should I consider?"`
- `"Are there any security or performance concerns?"`
- `"Can you suggest a good structure for this feature?"`

**The agent is your pair programmer - have a conversation!**

### Advanced Prompt Patterns

**Few-Shot (Show examples):**
```
"Add error handling like this example: [paste code]
Apply this pattern to all service methods."
```

**Chain of Thought (Step by step):**
```
"Let's solve this step by step. First explain your approach,
then implement each step with explanations."
```

**Role Assignment:**
```
"Act as a security expert and review this authentication code."
"As a C# architect, suggest the best pattern for this scenario."
```

**Constrained Generation:**
```
"Generate ONLY the interface, not the implementation."
"List edge cases without implementing solutions."
```

**Self-Critique:**
```
"Implement X, then critique your solution for edge cases
and potential improvements."
```

### Starting a New Project

**Step 1: Ask for guidance**
```
Help me create an AGENTS.md for a C# .NET 8.0 console application.
What sections should I include?
```

**Step 2: Create structure**
```
Create a new C# .NET 8.0 console application with this structure:
[describe structure]
```

**Step 3: Generate foundation**
```
Generate AGENTS.md documenting the conventions based on our discussion.
Don't implement features yet—just scaffold.
```

### Implementing a Feature

```
Implement the feature described in requirements/[FEATURE]-REQUIREMENTS.md.
Follow all conventions in AGENTS.md.
Include unit tests.
```

### Understanding Existing Code

```
Analyze this codebase and explain:
1. Project structure and organization
2. Key components and their responsibilities  
3. Coding conventions observed
4. Any patterns or architectural choices
```

### Creating AGENTS.md for Existing Code

```
Analyze this codebase and create an AGENTS.md that documents:
1. Project overview and tech stack
2. Project structure
3. Observed coding conventions
4. Patterns for error handling, validation, etc.
5. Instructions for agents working here

Base this on actual patterns in the code.
```

### Fixing Issues by Refining Requirements

```
The generated [component] doesn't match the requirements.

Expected: [describe what requirements say]
Actual: [describe what was generated]

Please regenerate following the requirements exactly.
```

### Adding to Existing Feature

```
Add [new capability] to the existing [feature].

Requirements:
- Follow the existing pattern in [file/component]
- Don't break existing functionality
- Match the style in AGENTS.md

Existing code is in [path].
```

### Asking for Impact Analysis

```
Before implementing, analyze:
1. What files will need to change?
2. What existing functionality might be affected?
3. Any risks or breaking changes?
```

---

## CLI Command Pattern (C#)

### In Program.cs

```csharp
// Main switch statement
switch (command)
{
    case "commandname":
        HandleCommandName(service, args);
        break;
}

// Handler method
static void HandleCommandName(Service service, string[] args)
{
    // 1. Validate arguments
    if (args.Length < 2)
    {
        Console.WriteLine("Usage: app commandname <arg>");
        return;
    }

    // 2. Parse/extract arguments
    var arg = args[1];

    // 3. Validate input
    if (string.IsNullOrWhiteSpace(arg))
    {
        Console.WriteLine("Error: Argument cannot be empty");
        Environment.Exit(1);
        return;
    }

    // 4. Call service
    var result = service.DoSomething(arg);

    // 5. Format and display output
    Console.WriteLine($"Success: {result}");
}
```

---

## Test Pattern (xUnit)

```csharp
namespace ProjectName.Tests;

public class ClassNameTests
{
    [Fact]
    public void MethodName_Scenario_ExpectedResult()
    {
        // Arrange
        var sut = new ClassName();
        var input = "test";

        // Act
        var result = sut.MethodName(input);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("input1", "expected1")]
    [InlineData("input2", "expected2")]
    public void MethodName_MultipleInputs_ReturnsExpected(
        string input, 
        string expected)
    {
        // Arrange
        var sut = new ClassName();

        // Act
        var result = sut.MethodName(input);

        // Assert
        Assert.Equal(expected, result);
    }
}
```

---

## Error Handling Patterns

### Pattern 1: Exceptions

```csharp
public void DoSomething(string input)
{
    // Validate early
    ArgumentException.ThrowIfNullOrWhiteSpace(input);

    // Do work
    if (someConditionFails)
        throw new InvalidOperationException("Descriptive message");
}
```

### Pattern 2: Result Type

```csharp
public class Result<T>
{
    public bool IsSuccess { get; init; }
    public T? Value { get; init; }
    public string? Error { get; init; }

    public static Result<T> Success(T value) => 
        new() { IsSuccess = true, Value = value };

    public static Result<T> Failure(string error) => 
        new() { IsSuccess = false, Error = error };
}

// Usage
public Result<Book> FindBook(Guid id)
{
    var book = _books.FirstOrDefault(b => b.Id == id);
    return book != null 
        ? Result<Book>.Success(book)
        : Result<Book>.Failure("Book not found");
}
```

---

## Git Commands for Workshop

```bash
# Initialize repo
git init
git add .
git commit -m "Initial commit"

# Check status
git status
git diff

# Commit changes
git add .
git commit -m "Add feature X per requirements"

# View history
git log --oneline
git show [commit-hash]

# Create branch for experimentation
git checkout -b experiment
# Return to main
git checkout main
```

---

## .NET CLI Quick Reference

```bash
# Create new project
dotnet new console -n ProjectName
dotnet new classlib -n ProjectName
dotnet new xunit -n ProjectName.Tests

# Add reference
dotnet add reference ../OtherProject/OtherProject.csproj

# Add package
dotnet add package PackageName
dotnet add package Newtonsoft.Json

# Build and run
dotnet build
dotnet run
dotnet run -- arg1 arg2

# Test
dotnet test
dotnet test --verbosity normal
dotnet test --collect:"XPlat Code Coverage"

# Clean
dotnet clean

# List SDKs/runtimes
dotnet --list-sdks
dotnet --list-runtimes
```

---

## VS Code Shortcuts

### macOS

| Action | Shortcut |
|--------|----------|
| Command Palette | `Cmd+Shift+P` |
| Quick Open File | `Cmd+P` |
| Toggle Terminal | `` Ctrl+` `` |
| Copilot Chat | `Cmd+Shift+I` |
| Format Document | `Shift+Option+F` |
| Go to Definition | `F12` |
| Find References | `Shift+F12` |
| Rename Symbol | `F2` |
| Toggle Comment | `Cmd+/` |

### Windows/Linux

| Action | Shortcut |
|--------|----------|
| Command Palette | `Ctrl+Shift+P` |
| Quick Open File | `Ctrl+P` |
| Toggle Terminal | `` Ctrl+` `` |
| Copilot Chat | `Ctrl+Shift+I` |
| Format Document | `Shift+Alt+F` |
| Go to Definition | `F12` |
| Find References | `Shift+F12` |
| Rename Symbol | `F2` |
| Toggle Comment | `Ctrl+/` |

---

## GitHub Copilot Tips

### Inline Completions

- Start typing—Copilot suggests completions
- `Tab` to accept
- `Esc` to dismiss
- `Alt+[` / `Alt+]` to see alternative suggestions

### Chat Commands

```
@workspace [question]     - Ask about entire workspace
/explain                  - Explain selected code
/fix                      - Suggest fixes for problems
/tests                    - Generate tests for code
/doc                      - Generate documentation
```

### Effective Prompts

✅ **Good:**
```
Create a BookService class with methods to add, remove, and search books.
Books should have title, author, ISBN, and status properties.
Use a List<Book> for storage.
```

❌ **Too vague:**
```
Make a book thing
```

### Context Matters

Copilot sees:
- Currently open file(s)
- `AGENTS.md` if present
- Nearby code
- Your prompt

It doesn't automatically see:
- Entire codebase (unless you use `@workspace`)
- Files you haven't opened
- External documentation

---

## Debugging Checklist

### Build Errors

1. Read error message carefully
2. Note file and line number
3. Check for:
   - Missing using statements
   - Typos in names
   - Missing semicolons
   - Type mismatches

### Runtime Errors

1. Note exception type and message
2. Check stack trace for origin
3. Add breakpoints or logging
4. Verify inputs are valid

### Agent Output Issues

1. Does generated code compile?
2. Does it match the requirements?
3. Does it follow AGENTS.md conventions?
4. Did you provide enough context?

**Fix by:**
- Clarifying requirements
- Adding more detailed implementation plan
- Adding examples
- Updating AGENTS.md
- Providing more context in prompt

---

## Common Gotchas

### Cross-Platform Paths

❌ **Wrong:**
```csharp
var path = "C:\\Users\\name\\file.txt";  // Windows only
var path = "/home/name/file.txt";        // Unix only
```

✅ **Right:**
```csharp
var path = Path.Combine(
    Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
    ".myapp",
    "file.txt"
);
```

### Async/Await

❌ **Wrong:**
```csharp
public void DoSomething()
{
    var result = DoSomethingAsync();  // Returns Task, not result!
}
```

✅ **Right:**
```csharp
public async Task DoSomething()
{
    var result = await DoSomethingAsync();
}
```

### String Comparison

❌ **Wrong:**
```csharp
if (input == "search")  // Case-sensitive
```

✅ **Right:**
```csharp
if (input.Equals("search", StringComparison.OrdinalIgnoreCase))
```

---

## MCP Server Commands (Optional)

### GitHub Integration

**Query Issues:**
```
@workspace Show me all open issues with label "enhancement"
@workspace Find issues assigned to me
@workspace List issues in milestone "v1.0"
```

**Create Issues:**
```
Create a GitHub issue titled "[Bug] Login fails" with:
- Description from error log
- Label: bug, priority-high
- Assign to: @username
```

**Update Issues:**
```
Close GitHub issue #123 and add comment "Fixed in commit abc123"
Update issue #456 with label "in-progress"
```

**Link Code to Issues:**
```
Link this file to GitHub issue #789
Find all issues mentioning "authentication" and show their status
```

### Azure DevOps Integration

**Query Work Items:**
```
@workspace Show me all active work items in current sprint
@workspace Find bugs assigned to me with priority 1
@workspace List user stories in iteration "Sprint 23"
```

**Create Work Items:**
```
Create ADO task:
- Title: "Implement user authentication"
- Type: Task
- Assigned to: me
- Description: [from requirements/auth.md]
- Area Path: MyProject\Backend
```

**Update Work Items:**
```
Update ADO task #12345:
- Status: In Progress
- Add comment: "Completed service implementation"
- Update remaining work: 4 hours

Move task #67890 to "Done" and link to this pull request
```

**Link Code to Work Items:**
```
Associate this commit with ADO task #12345
Find all work items related to "payment processing"
Show work item #99999 details and related code changes
```

### Workflow Integration

**Requirements to Tasks:**
```
Read requirements/payment-feature.md and create ADO work items
for each requirement with appropriate task breakdown
```

**Code Changes to Updates:**
```
I just implemented the authentication service. Update the related
ADO task #12345 to "Code Complete" and create a new task for
writing integration tests.
```

**Traceability:**
```
Show me all GitHub issues and ADO tasks related to files in /Services
Generate a traceability report linking requirements → work items → code
```

---

## Example Prompt Instructions

### Creating AGENTS.md

**For New Project (Greenfield):**
```
I'm starting a new C# 12 / .NET 8.0 CLI application for task management.
Help me create an AGENTS.md file that documents:
- Project purpose and goals
- Technology stack and key dependencies
- Project structure we should follow
- C# coding conventions (naming, async patterns, error handling)
- Testing approach
- Common patterns to use

Ask me questions about conventions I prefer before generating.
```

**For Existing Project (Brownfield):**
```
I need to create an AGENTS.md for this existing C# project. 
Please analyze the codebase and help me document:
- Current project structure and organization
- Existing naming conventions and patterns
- Error handling approach being used
- Any inconsistencies you notice
- Recommended conventions going forward

Ask questions if you find conflicting patterns in the code.
```

### Creating Product Requirements Document

**New Feature:**
```
I need to write a Product Requirements Document (PRD) for adding
user authentication to our task management app.

Target users: Small teams (5-10 people)
Key needs: Login, role-based access (Admin/User), session management

Help me create a comprehensive PRD with:
- User stories with acceptance criteria
- Functional requirements with REQ-IDs
- Non-functional requirements (security, performance)
- Edge cases and error scenarios
- Success metrics

Ask clarifying questions about authentication approach, security 
requirements, and user experience before generating.
```

**Enhancement to Existing Feature:**
```
I want to enhance the book checkout feature to track borrower history.

Current state: Books can be checked out, but we don't track who or when
Desired state: Full borrower tracking with history and due dates

Help me write a PRD that includes:
- User stories for librarians and borrowers
- Functional requirements (data model, operations)
- Integration with existing checkout logic
- Reports needed (overdue books, borrower history)
- Data migration considerations

Ask about retention policies, privacy concerns, and reporting needs.
```

### Creating All-Up Implementation Plan

**Large Feature Implementation:**
```
Based on the Product Requirements in requirements/auth-feature.md,
help me create a complete implementation plan that includes:

- High-level architecture (components, data flow)
- Project structure (folders, namespaces)
- Data models and their relationships
- Interface definitions
- Implementation phases (broken into reviewable chunks ~300 lines each)
- Testing strategy for each phase
- Rollback plan

Prioritize phases: Core authentication → Session management → 
Role-based access → Admin UI

Each phase should be independently deployable and testable.
Ask questions about technical constraints and dependencies.
```

**New Application:**
```
I have requirements in requirements/task-manager-prd.md for a complete
task management CLI application.

Create an all-up implementation plan with:
- Complete project structure
- All required classes and interfaces
- Phase breakdown (6-8 phases, each ~200-300 lines)
- Dependencies between phases
- Testing approach for each phase
- Performance considerations

Phase 1 should be a minimal viable product (add + list tasks).
Ask about prioritization if requirements conflict.
```

### Creating Single-Feature Phased Plan

**Breaking Down One Feature:**
```
I need to implement the "Advanced Search" feature from 
requirements/search-feature.md, but it's too large for one PR.

Help me break this into 3-4 phases, each ~200-300 lines:

Phase 1: Basic text search (title/description)
Phase 2: Filter by status/priority
Phase 3: Date range filtering
Phase 4: Saved search queries

For each phase, specify:
- Exact classes/methods to create or modify
- Test cases to add
- What gets exposed in CLI
- What's stubbed for future phases

Each phase should be mergeable and testable independently.
```

**Refactoring Existing Code:**
```
The BookService class has grown to 800 lines and needs refactoring.

Create a phased plan to extract responsibilities:

Phase 1: Extract validation logic to BookValidator (~150 lines)
Phase 2: Extract search logic to BookSearchService (~200 lines)  
Phase 3: Extract checkout logic to CheckoutService (~200 lines)
Phase 4: Update tests for new structure (~150 lines)

For each phase:
- Show which methods move where
- Identify breaking changes (should be none)
- Specify tests to update
- Ensure existing functionality preserved

Each phase should pass all existing tests.
```

---

## Workshop Workflow Summary

### Greenfield
1. Create `AGENTS.md`
2. Write requirements and implementation plan
3. Generate code via agent
4. Review and test
5. Iterate on requirements if needed

### Brownfield
1. Explore codebase
2. Create `AGENTS.md` from existing patterns
3. Generate product requirements for existing functionality
4. Add unit tests for existing code (safety net)
5. Write feature requirements and implementation plan
6. Generate code AND tests via agent
7. Run ALL tests (regression testing)
8. Iterate on requirements if needed

---

## When You're Stuck

1. **Read the error message** - It's usually helpful
2. **Check AGENTS.md** - Are conventions clear?
3. **Review the requirements** - Is it specific enough? Is implementation plan clear?
4. **Ask the agent** - "Why isn't this working?"
5. **Start simpler** - Break down into smaller pieces
6. **Look at existing code** - How is similar functionality done?
7. **Ask facilitator** - Don't stay stuck!

---

## Key Principles

1. **Requirements first, code second**
2. **Context is everything**
3. **Iterate on requirements, not code**
4. **Consistency over perfection**
5. **Test don't guess**
6. **Update docs after every change** - Answered a question? Clarified a requirement? Implemented code? Update AGENTS.md, requirements, and README immediately!

---

## Resources

- **Workshop Materials:** `/00-prerequisites`, `/01-greenfield`, `/02-brownfield`
- **Best Practices:** `resources/BEST-PRACTICES.md`
- **.NET Docs:** https://learn.microsoft.com/dotnet/
- **GitHub Copilot Docs:** https://docs.github.com/copilot
- **C# Reference:** https://learn.microsoft.com/dotnet/csharp/

---

Good luck! 🚀
