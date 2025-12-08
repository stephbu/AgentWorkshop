# Greenfield Lab: Build from Scratch

**Duration:** ~60 minutes  
**Goal:** Learn spec-first development by building a new C# project from the ground up.

---

## Overview

In this lab, you will:
1. Create an `AGENTS.md` file to establish project conventions
2. Write Product Requirements and Implementation Plan for a CLI application
3. Use AI agents to implement the application from your requirements
4. Iterate by refining requirements (not code) when issues arise

---

## The Project: Task Manager CLI

You'll build a simple command-line task manager with these features:
- Add tasks
- List tasks (all, or filter by status)
- Mark tasks complete
- Delete tasks
- Persist tasks to a JSON file

---

## Part 1: Create AGENTS.md (10 minutes)

**Why start here?** `AGENTS.md` sets the foundation—it tells AI agents how to work in your project.

### Step 1.1: Create the file

In your workspace, create: `/01-greenfield/MyTaskManager/AGENTS.md`

### Step 1.2: Define your project

Use the [AGENTS-TEMPLATE.md](./AGENTS-TEMPLATE.md) as a starting point, or write from scratch.

**Key sections to include:**

**💡 Pro Tip: Ask the agent to help you!**

**Start with a question:**
```
"I'm building a C# CLI task manager application using .NET 8.0.
Help me create an AGENTS.md file. What sections should I include
and what conventions should I document?"
```

Then customize the agent's suggestions. Here's what to include:

```markdown
# AGENTS.md

## Project Overview
A command-line task manager built in C#. Users can add, list, complete, and delete tasks via CLI commands.

## Tech Stack
- Language: C# 12
- Framework: .NET 8.0
- CLI Framework: System.CommandLine
- Data Storage: JSON file
- Testing: xUnit

## Project Structure
/MyTaskManager
  /src
    /Commands      - CLI command handlers
    /Models        - Task, TaskStatus, etc.
    /Services      - Business logic (TaskService)
    /Storage       - JSON persistence (TaskRepository)
  /tests
    /MyTaskManager.Tests  - Unit tests
  AGENTS.md
  README.md

## Coding Conventions
- Use C# 12 features (primary constructors, file-scoped namespaces)
- Async/await for all I/O operations
- Dependency injection where appropriate
- XML documentation comments on public APIs
- One class per file
- Namespace: MyTaskManager.[folder]

## Naming Conventions
- PascalCase for classes, methods, properties
- camelCase for parameters, local variables
- Prefix interfaces with 'I': ITaskRepository
- Suffix async methods with 'Async': SaveTasksAsync

## Error Handling
- Use exceptions for exceptional cases
- Return Result<T> pattern for expected failures
- Log errors but don't swallow them
- Validate input at command boundaries

## Testing Standards
- Test class name: [ClassUnderTest]Tests
- Test method name: [Method]_[Scenario]_[ExpectedResult]
- Use Arrange-Act-Assert pattern
- Mock external dependencies (file I/O, etc.)

## Instructions for Agents
1. Always create tests alongside implementation
2. Follow existing patterns in the codebase
3. Use dependency injection for services
4. Keep commands thin—business logic goes in services
5. Ensure all async methods are properly awaited
6. Never hardcode file paths—use configuration

## Example Code Style

```csharp
namespace MyTaskManager.Models;

/// <summary>
/// Represents a task item.
/// </summary>
public class TaskItem
{
    public Guid Id { get; init; }
    public required string Title { get; init; }
    public string? Description { get; init; }
    public TaskStatus Status { get; set; } = TaskStatus.Pending;
    public DateTime CreatedAt { get; init; }
}
```
```

### Step 1.3: Review and refine

Read through your `AGENTS.md`:
- Is it clear?
- Would a new developer understand your conventions?
- Are there ambiguities an agent might misinterpret?

**Tip:** Ask the agent, "Review my AGENTS.md for clarity and completeness."

---

## Part 2: Write Product Requirements and Implementation Plan (10 minutes)

Now write requirements and a plan for what the application should do.cation should do.

### Step 2.1: Create requirements document

Create: `/01-greenfield/MyTaskManager/requirements/TASK-MANAGER-REQUIREMENTS.md`EQUIREMENTS.md`

### Step 2.2: Write the requirements

Use the [PRODUCT-REQUIREMENTS-TEMPLATE.md](./PRODUCT-REQUIREMENTS-TEMPLATE.md) and [IMPLEMENTATION-PLAN-TEMPLATE.md](./IMPLEMENTATION-PLAN-TEMPLATE.md) or create your own.

**Example requirements document:**

```markdown
# Feature: Task Manager CLI

## Overview
A command-line application that allows users to manage a personal todo list.
Tasks persist to a local JSON file between sessions.

## Requirements
- [ ] Add new tasks with title and optional description
- [ ] List all tasks showing: ID, title, status
- [ ] Filter tasks by status (pending, complete)
- [ ] Mark tasks as complete
- [ ] Delete tasks by ID
- [ ] Persist tasks to `~/.taskmanager/tasks.json`
- [ ] Handle errors gracefully (file doesn't exist, invalid ID, etc.)

## Commands

### add
**Usage:** `taskmanager add "Task title" [--description "Details"]`

**Behavior:**
- Creates new task with unique ID
- Sets status to Pending
- Records creation timestamp
- Saves to JSON file
- Prints: "Task added: [ID]"

**Example:**
```bash
$ taskmanager add "Buy groceries" --description "Milk, eggs, bread"
Task added: a3f2d4e1-...
```

### list
**Usage:** `taskmanager list [--status pending|complete]`

**Behavior:**
- Lists tasks in table format
- If --status provided, filters by status
- Shows: ID (first 8 chars), Title, Status, Created

**Example:**
```bash
$ taskmanager list
ID       | Title          | Status  | Created
---------|----------------|---------|----------
a3f2d4e1 | Buy groceries  | Pending | 2025-12-07
b5c7a3f2 | Write report   | Complete| 2025-12-06
```

### complete
**Usage:** `taskmanager complete <task-id>`

**Behavior:**
- Marks task as Complete
- Saves to JSON file
- Prints: "Task completed: [Title]"
- Error if ID not found

### delete
**Usage:** `taskmanager delete <task-id>`

**Behavior:**
- Removes task from list
- Saves to JSON file
- Prints: "Task deleted: [Title]"
- Error if ID not found

## Acceptance Criteria

### AC1: Task Persistence
- Given tasks exist in memory
- When the application exits
- Then tasks are saved to JSON file
- And reloaded on next run

### AC2: Valid Commands
- Given I run `taskmanager add "Test"`
- When the command executes
- Then a new task is created
- And I see confirmation with task ID

### AC3: Invalid Task ID
- Given I run `taskmanager complete invalid-id`
- When the command executes
- Then I see error: "Task not found: invalid-id"
- And application exits with code 1

### AC4: Empty List
- Given no tasks exist
- When I run `taskmanager list`
- Then I see "No tasks found."

## Non-Functional Requirements
- Commands should respond in < 100ms
- JSON file should be human-readable (pretty-printed)
- Application size should be reasonable (< 10 MB)

## Out of Scope (for this iteration)
- Task priorities or due dates
- Task categories/tags
- Sync across devices
- Recurring tasks

## Technical Constraints
- Must work on Windows, macOS, Linux
- Must be compatible with .NET 8.0
- File path should be cross-platform compatible

## Implementation Plan
1. Create Models folder with TaskItem and TaskStatus classes
2. Create Services folder with TaskService for business logic
3. Create Storage folder with TaskRepository for JSON persistence
4. Implement command handlers in Program.cs
5. Add error handling following AGENTS.md patterns
6. Write unit tests for each component
```

### Step 2.3: Review your requirementsirements

Ask yourself:
- Can I test these requirements?
- Are the behaviors unambiguous?
- Have I included examples?
- Is the implementation plan clear?
- What edge cases might break this?

---

## Part 3: Generate Implementation (20 minutes)

Now let the AI agent build your application!

### Step 3.1: Initial scaffold

**Prompt to agent:**
```
Create a new C# console application following the structure defined in AGENTS.md.
Set up the project with:
- .NET 8.0 console app
- System.CommandLine NuGet package
- xUnit testing project
- Folder structure as specified

Don't implement features yet—just create the skeleton.
```

**Expected output:**
- `.csproj` files
- Folder structure
- Empty classes/interfaces

### Step 3.2: Implement the feature

**Prompt to agent:**
```
Implement the Task Manager CLI application according to requirements/TASK-MANAGER-REQUIREMENTS.md.
Follow all conventions in AGENTS.md.
Include unit tests for:
- TaskService business logic
- TaskRepository persistence
- Command handlers

Use dependency injection to wire up services.
```

**Watch for:**
- Does the agent follow your AGENTS.md conventions?
- Are namespaces correct?
- Is code commented as specified?

### Step 3.3: Build and test

Run the project:
```bash
cd MyTaskManager/src
dotnet build
dotnet run -- add "Test task"
dotnet run -- list
```

Run tests:
```bash
cd MyTaskManager/tests/MyTaskManager.Tests
dotnet test
```

---

## Part 4: Iterate on Requirements (15 minutes)

Issues will arise. Practice fixing them by **updating requirements**, not editing code.

### Common scenarios:

#### Scenario A: Output format isn't what you wanted

**DON'T:** Edit the command handler code directly

**DO:** Update the requirements with more precise format requirements:
```markdown
## Output Format for List Command

Display tasks in a table with fixed-width columns:
- ID: 8 characters
- Title: 30 characters (truncate with ...)
- Status: 10 characters
- Created: 10 characters (yyyy-MM-dd format)

Use Unicode box-drawing characters for borders.
```

Then prompt agent: "Regenerate the list command using updated requirements."

#### Scenario B: Error handling isn't robust

**DON'T:** Add try-catch blocks manually

**DO:** Add to AGENTS.md error handling section and update implementation plan:
```markdown
## Error Handling Pattern

All commands should:
1. Validate input first
2. Wrap I/O operations in try-catch
3. Return specific error codes:
   - 0: Success
   - 1: Invalid arguments
   - 2: File I/O error
   - 3: Task not found
4. Log exceptions to ~/.taskmanager/errors.log
```

Prompt: "Update all commands to follow the error handling pattern in AGENTS.md."

#### Scenario C: JSON serialization issue

**DON'T:** Fix JSON options manually

**DO:** Add serialization guidance to AGENTS.md:
```markdown
## JSON Serialization

Use System.Text.Json with options:
- WriteIndented = true
- PropertyNamingPolicy = CamelCase
- Include all properties
- Handle null values gracefully
```

---

## Part 5: Reflect (5 minutes)

### Discussion Questions

1. **How much code did you write vs. the agent?**
   - Ideally, you wrote requirements and reviewed—agent wrote code

2. **When did you edit code directly vs. updating requirements?**
   - Small tweaks: maybe edited directly
   - Patterns/conventions: should update AGENTS.md

3. **How did AGENTS.md help?**
   - Did agent follow conventions consistently?
   - What would have been different without it?

4. **What would you change about your requirements?**
   - Too vague? Too prescriptive?
   - Was the implementation plan clear enough?
   - What edge cases did you miss?

5. **When did spec-first feel natural? When did it feel forced?**

---

## Bonus Challenges

If you finish early:

### Challenge 1: Add a new feature
Add task editing (change title/description) using requirements-first approach:
1. Write requirements with edit command details and implementation plan
2. Let agent implement
3. Verify against requirements

### Challenge 2: Add task priorities
- Update AGENTS.md with Priority enum
- Write requirements and implementation plan for priority filtering
- Implement via agent

### Challenge 3: Improve test coverage
- Write test requirements for edge cases you discovered
- Agent generates tests
- Verify coverage with `dotnet test --collect:"XPlat Code Coverage"`

---

## Key Takeaways

✅ **AGENTS.md is your project DNA** - Set it up first  
✅ **Requirements should be testable** - If you can't test it, refine it  
✅ **Include an implementation plan** - Guide the agent on how to structure the solution  
✅ **Iterate on requirements, not code** - Fix the input when output is wrong  
✅ **Examples are powerful** - Show, don't just tell  
✅ **Agents amplify clarity** - Garbage in, garbage out  

---

## What's Next?

In the **Brownfield Lab**, you'll apply these techniques to an existing codebase where you didn't write the original code.

The challenge: Understanding and extending code you're unfamiliar with—using AGENTS.md as your guide.
