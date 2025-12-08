# Requirements-First Development with AI Agents: Best Practices

Quick reference guide for effective requirements-first development patterns.

---

## The Core Principle

> **Write Product Requirements and Implementation Plans before code. Iterate on requirements, not code.**

When agents generate code that's not quite right, the instinct is to edit the code. Resist this. Instead, improve your requirements and regenerate.

---

## The Requirements-First Workflow

### 1. Greenfield (New Project)

```
1. Create AGENTS.md (conventions, patterns, structure)
   ↓
2. Write Product Requirements and Implementation Plan
   ↓
3. Agent generates implementation
   ↓
4. Review output
   ↓
5. If not right → Update AGENTS.md or requirements → Regenerate
   ↓
6. Verify against acceptance criteria
   ↓
7. Update documentation (requirements, AGENTS.md, README)
```

### 2. Brownfield (Existing Project)

```
1. Explore codebase (understand structure, patterns)
   ↓
2. Create/update AGENTS.md (document existing conventions)
   ↓
3. Write requirements for change (describe delta from current state)
   ↓
4. Write implementation plan (how to integrate)
   ↓
5. Agent generates implementation (following existing patterns)
   ↓
6. Review output
   ↓
7. If not right → Update AGENTS.md or requirements → Regenerate
   ↓
8. Test new feature AND existing features (regression)
   ↓
9. Update documentation (requirements, AGENTS.md, README, comments)
```

### 3. Critical: Keep Documentation Current

**🎯 Golden Rule: Documentation decays the moment you answer a question.**

Every time you:
- Answer a question about the code
- Clarify a requirement
- Make a design decision
- Implement code or configuration
- Discover a gotcha or edge case
- Change how something works

**→ Update the documentation immediately!**

#### What to Update and When

**After Answering Questions:**
```
Developer asks: "Why do we use file-scoped namespaces?"
You answer: "For consistency and reduced nesting."

✅ Immediately update AGENTS.md:
## Coding Conventions
- **Namespaces**: Use file-scoped namespaces for consistency
  and to reduce nesting levels
```

**After Clarifying Requirements:**
```
Stakeholder clarifies: "Search should be case-insensitive by default"

✅ Immediately update requirements/search-feature.md:
REQ-003: Text Search
- Search is case-insensitive by default
- Add --case-sensitive flag for exact matching
- Examples: "Task" matches "task", "TASK", "Task"
```

**After Implementation:**
```
You implement authentication service

✅ Update multiple docs:
1. AGENTS.md - Add section on auth patterns
2. requirements/auth-feature.md - Mark requirements as ✅ Complete
3. README.md - Add authentication setup instructions
4. Code comments - Document why you chose JWT over sessions
```

**After Discovering Gotchas:**
```
You find: "Book checkout fails if borrower name has special characters"

✅ Update AGENTS.md:
## Common Pitfalls
- **Input validation**: Always sanitize user input before storage.
  Special characters in names broke checkout feature (fixed in v1.2)
```

#### Documentation Update Checklist

After ANY code change, ask yourself:

- [ ] Does **AGENTS.md** need updating?
  - New patterns introduced?
  - Conventions changed?
  - New gotchas discovered?

- [ ] Does **requirements doc** need updating?
  - Requirements clarified?
  - Acceptance criteria changed?
  - New edge cases found?

- [ ] Does **README.md** need updating?
  - Setup instructions changed?
  - New features to document?
  - Configuration options added?

- [ ] Do **code comments** need updating?
  - Design decisions made?
  - Non-obvious logic added?
  - TODOs resolved or added?

- [ ] Does **implementation plan** need updating?
  - Phase completed?
  - Approach changed mid-stream?
  - Dependencies discovered?

#### Prompt the Agent to Help

**Don't do it alone!** Ask the agent to update documentation:

```
We just implemented the authentication service and made several
design decisions:
- Used JWT tokens instead of sessions (stateless)
- Tokens expire after 24 hours
- Refresh tokens not implemented yet (future phase)

Please update:
1. AGENTS.md - Add section on authentication patterns
2. requirements/auth-feature.md - Mark completed requirements
3. README.md - Add authentication setup instructions
4. Add TODO comments for refresh token implementation
```

#### Why This Matters

**Without updated documentation:**
- Future you forgets why decisions were made
- New team members ask the same questions repeatedly
- AI agents don't have context for future changes
- Knowledge lives only in your head
- Mistakes get repeated

**With updated documentation:**
- Questions get answered before they're asked
- AI agents automatically follow established patterns
- New developers onboard faster
- Decisions are traceable
- Code reviews go faster (context is clear)

---

## Writing Effective AGENTS.md

### Don't Write AGENTS.md Alone - Ask the Agent!

**💡 Pro Tip:** The agent can help you create AGENTS.md!

**Start with questions:**
```
"I'm building a C# .NET 8.0 CLI application for task management.
Help me create an AGENTS.md file. What sections should I include?"

"Review my project structure and suggest conventions for AGENTS.md."

"What coding standards should I document in AGENTS.md for a 
team C# project using async/await and repository pattern?"
```

**Iterate on the draft:**
```
"Generate a draft AGENTS.md for this project based on the files you see."

"Update AGENTS.md to include error handling conventions I should follow."

"Add a section about testing patterns to AGENTS.md."
```

**The agent knows best practices and can suggest conventions you might not think of!**

### How Agents Use AGENTS.md

**🌟 Automatic Loading:**
GitHub Copilot and compatible AI agents **automatically read `/AGENTS.md`** from your project root when it exists. You don't need to reference it in every prompt.

**What this means:**
- Create `/AGENTS.md` once in your repo root
- Every interaction with the agent includes this context
- No need to say "follow AGENTS.md conventions" repeatedly
- Works silently in the background for consistency

**Example:**
```
Without AGENTS.md:
You: "Add a new service method"
Agent: [generates code with random style]

With AGENTS.md at /AGENTS.md:
You: "Add a new service method"
Agent: [automatically follows your documented conventions]
```

**Location matters:** Must be at project root (`/AGENTS.md`) for automatic loading.

### Essential Sections

#### 1. Project Overview
- What the project does (1-2 sentences)
- Why it exists
- Tech stack

#### 2. Project Structure
- Folder organization
- What goes where
- Naming conventions

#### 3. Coding Conventions
- Language features to use/avoid
- Formatting rules
- Pattern preferences

#### 4. Instructions for Agents
- Do's and don'ts
- Common pitfalls
- Example code showing preferred style

### AGENTS.md Anti-Patterns

❌ **Too vague:** "Write good code"  
✅ **Specific:** "Use async/await for all I/O. Suffix async methods with 'Async'"

❌ **Too long:** 50-page document  
✅ **Concise:** Key patterns and examples. Link to detailed docs if needed.

❌ **Contradicts actual code:** "We use dependency injection" (but code doesn't)  
✅ **Reflects reality:** Document what IS, not what you wish it was

❌ **Never updated:** Written once, stale forever  
✅ **Living doc:** Update when patterns evolve

---

## Writing Effective Product Requirements

### The Requirements Template

```markdown
# Feature: [Name]

## Overview
[What and why in 2-3 sentences]

## Requirements
- [ ] Concrete, testable requirement
- [ ] Another requirement

## Acceptance Criteria
Given [context]
When [action]
Then [expected result]

## Examples
[Concrete inputs and expected outputs]

## Edge Cases
[How to handle unusual inputs/states]

## Implementation Plan
1. [Step 1: what to create/modify]
2. [Step 2: how components interact]
3. [Step 3: testing strategy]

## Technical Constraints
[Platform, compatibility, integration requirements]
```

### Requirements Quality Checklist

#### ✅ Good requirements are:

- **Testable** - You can verify each requirement
- **Concrete** - Includes real examples
- **Complete** - Covers happy path AND errors
- **Unambiguous** - One clear interpretation
- **Appropriate level** - Not too vague, not too prescriptive
- **Actionable** - Implementation plan is clear

#### ❌ Requirements smells:

- **Vague language:** "Fast" "Good" "Nice" "User-friendly"
- **Missing examples:** Only describes, doesn't show
- **No error cases:** Only happy path
- **Too technical:** Specifies implementation details
- **Untestable:** Can't verify if it works
- **No implementation plan:** Agent doesn't know how to structure solution

### Requirements Examples: Bad vs. Good

#### ❌ Bad Requirements
```markdown
# Feature: Search

Users can search for books.
It should be fast and return relevant results.
```

**Problems:** What field to search? What format? What's "fast"? What's "relevant"?

#### ✅ Good Requirements
```markdown
# Feature: Book Search

## Overview
Users can search books by title or author using substring matching (case-insensitive).

## Requirements
- [ ] Search by title returns all books where title contains search term
- [ ] Search by author returns all books where author contains search term
- [ ] Search is case-insensitive
- [ ] Empty search term returns empty list (not all books)
- [ ] No matches returns empty list with message

## Acceptance Criteria

### AC1: Search by Title
Given the library contains "The Great Gatsby" and "Great Expectations"
When I search title for "great"
Then I see both books

### AC2: Case Insensitive
Given the library contains "The Great Gatsby"
When I search title for "GATSBY"
Then I see "The Great Gatsby"

### AC3: Empty Term
Given any library state
When I search with empty string
Then I see "No books found."
And no results are returned

## Examples
```bash
$ booklibrary search title "gatsby"
Found 1 book(s):

ID: a3f2d4e1
Title: The Great Gatsby
Author: F. Scott Fitzgerald
...
```

## Performance
- Searches should complete in < 100ms for libraries with < 10,000 books

## Implementation Plan
1. Add SearchByTitle method to BookService
2. Add SearchByAuthor method to BookService  
3. Add search command handler in Program.cs
4. Follow existing list output format
5. Add unit tests for search methods
```

---

## When to Edit Requirements vs. Code

### Edit the Requirements When:
- Agent output doesn't match your intent
- You discover edge cases you didn't specify
- Error handling is unclear
- Output format is wrong
- Agent misunderstood requirements
- Implementation plan was incomplete

### Edit Code Directly When:
- Typo in a variable name
- Small formatting tweak (extra space, etc.)
- Quick fix to test something
- One-line change that's obvious

### Update AGENTS.md When:
- Agent keeps violating a convention
- You want a pattern applied consistently
- New pattern emerges that should be standard
- You discover existing code uses a pattern

**Rule of thumb:** If you'd need to make the same change in multiple places or future features, put it in AGENTS.md.

---

## Effective Prompts for Agents

### The Power of Asking Questions

**Before you write code, ask the agent for guidance:**

✅ **Ask about requirements:**
```
"What information do you need to implement user authentication?"
"What edge cases should I consider for file upload?"
"Are there security concerns I should address?"
```

✅ **Ask about design:**
```
"What's the best way to structure a C# CLI application?"
"Should I use repository pattern or direct data access?"
"What testing strategy would work best for this?"
```

✅ **Ask about conventions:**
```
"What sections should I include in AGENTS.md for this project?"
"What coding conventions are standard for .NET 8.0?"
"How should I organize my project folders?"
```

✅ **Ask for clarification:**
```
"Can you explain this error message?"
"Why did you choose this approach over alternatives?"
"What are the tradeoffs of this design?"
```

**The agent can be your consultant, not just your coder. Have a conversation!**

### Context is King

❌ **Insufficient context:**
```
Add a new feature to list books.
```

✅ **Rich context:**
```
Add a "list" command to the BookLibrary CLI following the spec in 
specs/LIST-SPEC.md. Follow all conventions in AGENTS.md, particularly
the command structure pattern and error handling style.
```

### Reference Your Docs

Include references to your requirements and AGENTS.md:

```
Review AGENTS.md and requirements/FEATURE-REQUIREMENTS.md, then implement the feature.
```

### Be Specific About Scope

```
Update BookService to add a SearchByCategory method.
Do NOT modify existing methods.
Follow the same pattern as SearchByTitle.
```

### Iterative Refinement

**First pass:**
```
Implement the feature described in requirements/RATING-REQUIREMENTS.md
```

**If output isn't right:**
```
The output doesn't match the format in the requirements. The requirements show ratings
should be displayed as "★★★★☆ (4.0)" but the code outputs "Rating: 4.0".
Please update to match the requirements exactly.
```

### Ask for Explanation First

Before implementing complex features:

```
"Explain how you would implement user authentication with JWT tokens.
What are the key components and security considerations?"
```

Then review the explanation, refine requirements, and implement.

---

## Advanced Prompt Engineering Techniques

### 1. Few-Shot Learning (Learning from Examples)

Provide 1-3 examples of what you want:

```
"Add error handling to all service methods. Here's the pattern I want:

public async Task<Result<Book>> AddBook(Book book)
{
    try
    {
        ValidateBook(book);
        return Result.Success(await repository.AddAsync(book));
    }
    catch (ValidationException ex)
    {
        return Result.Failure<Book>(ex.Message);
    }
}

Apply this pattern to all methods in BookService."
```

### 2. Chain of Thought (Step-by-Step Reasoning)

Ask the agent to think through the problem:

```
"Let's implement user authentication step by step. For each step,
explain your reasoning before writing code:
1. What should the User model contain?
2. How should passwords be hashed and stored?
3. What JWT claims should we include?
4. How should token validation work?"
```

### 3. Role/Persona Assignment

Give the agent a specific perspective:

```
"Act as a security expert reviewing this authentication code.
Identify potential vulnerabilities and suggest improvements."

"As a performance engineer, analyze this data access layer
and suggest optimizations."

"You are a senior C# developer doing a code review.
Check for best practices and potential issues."
```

### 4. Constrained Generation

Limit what the agent produces:

```
"Generate ONLY the method signatures, not implementations"
"Write unit tests only, I'll implement the code myself"
"Provide 3 different architectural approaches without code"
"List the edge cases without implementing solutions"
```

### 5. Self-Critique and Reflection

Ask the agent to evaluate its own work:

```
"Implement task filtering. After you're done, critique your solution:
- What edge cases might you have missed?
- What could fail under load?
- How would you make this more robust?"
```

### 6. Negative Constraints (What NOT to Do)

Sometimes it's clearer to specify what to avoid:

```
"Implement data caching. DO NOT use external dependencies.
DO NOT store sensitive data in cache. DO NOT use in-memory
cache for production (file-based only)."
```

### 7. Incremental Complexity

Build up gradually instead of asking for everything at once:

```
Step 1: "Create a basic Task model with Id and Title"
Step 2: "Add validation to the Task model"
Step 3: "Add audit fields (CreatedAt, UpdatedAt)"
Step 4: "Add support for task categories"
```

Each step builds on the previous, maintaining context.

### 8. Comparative Analysis

Ask for alternatives and tradeoffs:

```
"Compare three approaches for storing tasks:
1. JSON file
2. SQLite database
3. In-memory with periodic serialization

For each approach, explain pros, cons, and when to use it."
```

### 9. Temperature Control Through Language

Use language to signal how creative/conservative to be:

**Conservative (precise, by-the-book):**
```
"Implement EXACTLY as specified in the requirements.
Follow the existing pattern PRECISELY. Do not deviate."
```

**Creative (explore alternatives):**
```
"Suggest innovative approaches to solve this problem.
Think outside the box. What are some creative solutions?"
```

### 10. Meta-Prompting (Prompts About Prompts)

Ask the agent to help you prompt better:

```
"I want to implement user authentication. What information
do you need from me to generate the best solution?"

"What questions should I answer in my requirements document
before asking you to implement this feature?"
```

---

## When These Techniques Work Best

### Use Few-Shot When:
- Pattern is non-obvious
- Consistency is critical
- Agent keeps misunderstanding

### Use Chain of Thought When:
- Problem is complex
- Multiple approaches exist
- You want to understand reasoning
- Security/correctness is critical

### Use Role Assignment When:
- Need specialized perspective
- Doing code review
- Analyzing tradeoffs
- Security/performance focus

### Use Constrained Generation When:
- You want control over implementation
- Need only part of solution
- Exploring alternatives
- Avoiding unwanted complexity

### Use Self-Critique When:
- Solution seems incomplete
- Want to catch edge cases
- Learning from AI reasoning
- Building robust solutions

---

## Anti-Patterns to Avoid

❌ **Kitchen Sink Prompt:**
Asking for everything at once in one giant prompt
→ Results are often unfocused

✅ **Better:** Break into logical steps, iterate

---

❌ **Assumption Overload:**
"Build the feature" (assuming agent knows everything)
→ Generic or wrong implementation

✅ **Better:** Be explicit about requirements, context, constraints

---

❌ **Ignoring Agent Questions:**
Agent asks for clarification, you ignore and repeat prompt
→ Same unclear result

✅ **Better:** Answer questions, have a dialogue

---

❌ **Copy-Paste Without Understanding:**
Use generated code without reading it
→ Bugs, security issues, technical debt

✅ **Better:** Review, understand, test before committing

---

❌ **No Iteration:**
Accept first result even if not quite right
→ Suboptimal solution stays in codebase

✅ **Better:** Refine prompt and regenerate until correct

---

### Ask for Explanation First (Original section continues...)

For brownfield:
```
Before making any changes, explain:
1. What files will need to be modified
2. What existing patterns you'll follow
3. Any risks or breaking changes
```

---

## Common Patterns & Solutions

### Pattern: Adding a CLI Command

1. Update AGENTS.md if command pattern not documented
2. Write requirements with usage, examples, errors, and implementation plan
3. Prompt:
   ```
   Add a new CLI command following requirements/[CMD]-REQUIREMENTS.md.
   Follow the existing command pattern in Program.cs.
   Add to switch statement, create handler method, update help text.
   ```

### Pattern: Adding Optional Feature

Requirements should explicitly state:
```markdown
## Backward Compatibility
This feature is optional. Existing code must work without it.
Use nullable types or default values where appropriate.
```

### Pattern: Error Handling

In AGENTS.md:
```markdown
## Error Handling Pattern
All commands should:
1. Validate input first
2. Throw specific exception types:
   - ArgumentException for validation
   - InvalidOperationException for state errors
3. Let exceptions propagate to Main()
4. Format errors: "Error: {message}"
```

### Pattern: Testing

In requirements:
```markdown
## Test Cases Required
- [ ] Happy path: [describe]
- [ ] Invalid input: [describe]
- [ ] Edge case: [describe]

## Implementation Plan
1. Create test class: [ClassName]Tests
2. Generate xUnit tests following AAA pattern
3. Mock external dependencies (file I/O, etc.)
```

---

## Troubleshooting

### Problem: Agent ignores AGENTS.md

**Symptoms:** Generated code doesn't follow conventions

**Solutions:**
1. Make AGENTS.md more explicit with examples
2. Reference AGENTS.md directly in prompt
3. Ask agent: "Does this code follow AGENTS.md conventions?"
4. Shorten AGENTS.md (might be too long for context)

### Problem: Agent hallucinates dependencies

**Symptoms:** Uses libraries/APIs that don't exist

**Solutions:**
1. List exact dependencies in AGENTS.md
2. In spec: "Use only [specific libraries]. No external dependencies."
3. Review generated code for unknown imports

### Problem: Requirements are ambiguous

**Symptoms:** Agent makes assumptions you didn't intend

**Solutions:**
1. Add concrete examples showing exact inputs/outputs
2. Use "Given-When-Then" format for clarity
3. Add detailed implementation plan with step-by-step approach
4. Explicitly state what NOT to do
5. Ask agent: "What's unclear in these requirements?"

### Problem: Breaking existing functionality

**Symptoms:** Old features stop working

**Solutions:**
1. Add to spec: "Do NOT modify [existing component] unless required"
2. In AGENTS.md: "Areas to Avoid" section
3. Always regression test after changes
4. Spec should describe delta, not rewrite everything

### Problem: Inconsistent style

**Symptoms:** New code looks different from old code

**Solutions:**
1. Add concrete examples to AGENTS.md showing preferred style
2. In prompt: "Match the style of [existing file]"
3. Ask agent to analyze existing code before generating

---

## Measuring Success

### Good Signs ✅

- Agent output matches requirements on first try (or close)
- You spend more time on requirements than code
- Implementation plan guides agent effectively
- Changes don't break existing features
- Code is consistent with existing patterns
- You rarely edit generated code manually

### Warning Signs ⚠️

- Constantly editing generated code
- Frequent breaking changes
- Agent ignores conventions repeatedly
- Requirements are too vague or too prescriptive
- Implementation plan doesn't provide enough guidance
- Spending more time fixing than generating

---

## MCP Server Integration (Advanced)

### Using MCP for Requirements Traceability

Model Context Protocol servers enable agents to interact with external systems like GitHub Issues and Azure DevOps, maintaining traceability between requirements and implementation.

**Benefits:**
- Automatic work item updates as code progresses
- Link requirements documents to work items
- Maintain bidirectional traceability
- Reduce manual project management overhead

### Best Practices with MCP

**1. Requirements to Work Items:**

Create work items directly from requirements documents:

```
Read requirements/user-auth-requirements.md and create GitHub issues
for each requirement (REQ-001, REQ-002, etc.). Label as "feature"
and milestone "v1.0".
```

**2. Code Changes to Updates:**

Update work items as implementation progresses:

```
I just completed the authentication service (REQ-001 through REQ-003).
Update GitHub issues #45, #46, #47 to "completed" status and
reference this commit.
```

**3. Automated Task Management:**

Let the agent manage task lifecycle:

```
Create ADO tasks from IMPLEMENTATION-PLAN.md Phase 1 checklist.
As I complete each phase, update task status automatically.
```

**4. Traceability Reports:**

Generate reports linking requirements to code:

```
Generate a traceability matrix showing:
- Requirements from requirements/auth.md
- Related GitHub issues
- Files implementing each requirement
- Test coverage per requirement
```

### Integration Workflow

**Greenfield with MCP:**
```
1. Create AGENTS.md
2. Write Product Requirements
3. Agent creates GitHub issues/ADO tasks from requirements
4. Write Implementation Plan
5. Agent generates code
6. Agent automatically updates work items on completion
7. Agent links commits to work items
```

**Brownfield with MCP:**
```
1. Explore codebase
2. Create AGENTS.md
3. Query existing ADO tasks/GitHub issues related to area
4. Write requirements for new feature
5. Agent creates new work items linked to existing ones
6. Generate implementation
7. Agent updates all affected work items
8. Agent creates traceability links
```

### Example MCP Commands

**During Development:**
```
"Update ADO task #12345 status to 'In Progress' and add comment
with changes from AGENTS.md conventions section."

"Find all GitHub issues labeled 'authentication' and link them
to the new AuthService.cs file."

"Create ADO subtasks for each checklist item in Phase 2 of
IMPLEMENTATION-PLAN.md and assign to current sprint."
```

**During Review:**
```
"Generate list of all work items affected by changes in
/Services directory and verify all are marked complete."

"Show me which requirements from requirements/payment.md
don't have corresponding GitHub issues."
```

### MCP Configuration Tips

**1. Set Default Work Item Templates:**

Configure AGENTS.md with work item defaults:

```markdown
## Work Item Configuration
- Default Area Path: MyProject\Backend
- Default Iteration: Current Sprint
- Task Template: Include acceptance criteria in description
- Bug Template: Include reproduction steps
```

**2. Automate Status Transitions:**

Define when to update work items:

```markdown
## MCP Automation Rules
- When implementation complete → Move task to "Code Complete"
- When tests pass → Move to "Ready for Review"
- When PR merged → Move to "Done" and close GitHub issue
```

**3. Maintain Requirements Links:**

Always reference work items in requirements:

```markdown
## REQ-001: User Login (ADO #12345, GitHub #67)
User can log in with email and password.
```

This enables bidirectional traceability and automatic updates.

---

## Example Prompts for Common Tasks

These example prompts demonstrate how to effectively request key artifacts from AI agents. Copy, adapt, and use these as starting points.

### Example 1: Creating AGENTS.md for New Project

```
I'm starting a new C# 12 / .NET 8.0 console application that will be 
a task management CLI tool. The app should let users add, list, complete, 
and delete tasks. Target audience is developers who want a simple command-line 
task tracker.

Help me create a comprehensive AGENTS.md file that documents:

1. Project Overview
   - What: Task management CLI application
   - Why: Simple, fast command-line task tracking for developers
   - Target users: Individual developers and small teams

2. Technology Stack
   - Language and framework versions
   - Key dependencies (System.CommandLine for CLI parsing)
   - Any libraries I should use for data persistence

3. Project Structure
   - Recommended folder organization
   - Where models, services, and CLI logic should live

4. Coding Conventions
   - Naming conventions (PascalCase, camelCase rules)
   - Async method patterns
   - File-scoped namespaces
   - Error handling approach

5. Testing Strategy
   - Testing framework (xUnit)
   - What should be tested
   - Test naming conventions

6. Common Patterns
   - How to structure service classes
   - How to handle validation
   - CLI command structure

Please ask clarifying questions about any conventions I haven't specified, 
particularly around:
- Data persistence approach (JSON file, SQLite, in-memory?)
- Error handling philosophy (fail fast vs. graceful degradation)
- Logging requirements
- Any specific architectural patterns I prefer (repository, CQRS, etc.)
```

### Example 2: Creating AGENTS.md for Existing Project

```
I need to create an AGENTS.md for this existing C# BookLibrary project 
that currently lacks documentation.

Please analyze the existing code in this workspace and help me create 
an AGENTS.md that documents:

1. Current Project Structure
   - What folders/namespaces exist
   - Purpose of each major component
   - How the pieces fit together

2. Existing Patterns
   - Naming conventions used (are they consistent?)
   - How errors are currently handled
   - Current testing approach (if any)
   - Data storage mechanism

3. Observed Conventions
   - Are namespaces file-scoped or traditional?
   - Async/await usage patterns
   - Parameter validation approach
   - Access modifier conventions

4. Inconsistencies to Note
   - Any conflicting patterns in the code
   - Areas that need standardization
   - Technical debt to be aware of

5. Recommendations Going Forward
   - Suggested conventions for new code
   - Patterns to follow for consistency
   - Areas that need documentation

Please ask questions if you:
- Find conflicting patterns (e.g., some methods use exceptions, others return nulls)
- See unconventional choices that need explanation
- Identify potential issues with the current structure

Base the AGENTS.md on what already exists, not on what "should be" best practice.
```

### Example 3: Writing Product Requirements for New Feature

```
I need to write a Product Requirements Document (PRD) for adding user 
authentication and authorization to our task management CLI application.

Context:
- Current state: No authentication, single-user app
- Target users: Small development teams (5-10 people) sharing a task list
- Deployment: Tasks stored in shared network location or database

New Requirements:
- Users must log in before accessing tasks
- Two roles: Admin (full access) and User (can only edit own tasks)
- Session management for CLI (avoid re-login every command)
- Audit trail of who created/modified each task

Help me create a comprehensive PRD with these sections:

1. User Stories
   - As a team member... (login, view own tasks, etc.)
   - As an admin... (manage users, view all tasks, etc.)
   - Include acceptance criteria for each story

2. Functional Requirements
   - REQ-IDs for each requirement
   - Authentication mechanism (username/password initially)
   - Authorization rules (what each role can do)
   - Session/token management for CLI
   - User management operations (add, remove, change roles)

3. Data Model Changes
   - New User entity (fields, validation)
   - Task entity updates (created_by, modified_by)
   - Audit log structure

4. Non-Functional Requirements
   - Security: Password storage (hashing algorithm)
   - Security: Session timeout
   - Performance: Login should complete in < 1 second
   - Usability: Clear error messages

5. Edge Cases & Error Scenarios
   - Invalid credentials
   - Expired session
   - User tries to access unauthorized task
   - Admin deletes user who owns tasks

6. Success Metrics
   - How to measure if feature is successful
   - What should be logged/tracked

Please ask clarifying questions about:
- Authentication mechanism preference (local vs. external identity provider)
- Password policies (complexity, rotation)
- Session management approach (tokens, cookies, file-based)
- What happens to tasks when a user is deleted
- Multi-device support (same user on different machines)
```

### Example 4: Creating All-Up Implementation Plan

```
I have complete Product Requirements in requirements/auth-feature.md 
for adding authentication and authorization to our task management app.

Please read that file and help me create a comprehensive, phased 
implementation plan.

Requirements for the plan:

1. High-Level Architecture
   - Components needed (AuthService, SessionManager, UserRepository, etc.)
   - Data flow diagrams (text-based)
   - How authentication integrates with existing TaskService

2. Project Structure Changes
   - New folders/namespaces needed
   - Where each new class should live
   - Any restructuring of existing code

3. Data Models
   - Complete User class definition
   - Updates to Task class (add user references)
   - AuditLog class definition
   - Include properties, types, validation rules

4. Interface Definitions
   - IAuthenticationService
   - IUserRepository
   - ISessionManager
   - Any other abstractions needed

5. Implementation Phases (Critical: Break into reviewable units)
   
   Break this into 6-8 phases, each ~200-300 lines of code maximum:
   
   Suggested phasing:
   - Phase 1: User data model + basic repository (no auth yet)
   - Phase 2: Password hashing + validation logic
   - Phase 3: Authentication service (login/logout)
   - Phase 4: Session management for CLI
   - Phase 5: Authorization checks in TaskService
   - Phase 6: User management commands (admin only)
   - Phase 7: Audit logging
   - Phase 8: Update all existing commands to require auth

   For each phase, specify:
   - Exact classes/files to create or modify
   - What functionality is added
   - How to test (unit tests and manual testing)
   - Dependencies on previous phases
   - Rollback strategy if issues found

6. Testing Strategy
   - Unit tests for each component
   - Integration tests for auth flow
   - Manual testing scenarios
   - Regression tests for existing functionality

7. Migration Plan
   - How to handle existing tasks (assign to default user?)
   - Database/storage updates needed
   - Backward compatibility considerations

Priority Order:
- Core authentication (login/logout) comes first
- Authorization checks second
- User management third
- Audit logging last

Each phase must be:
- Independently testable
- Independently deployable (with feature flags if needed)
- No more than 300 lines of changes
- Completable in 1-2 hours

Ask questions about:
- Technical constraints (existing code structure)
- Testing requirements (coverage expectations)
- Deployment constraints (can we use feature flags?)
- Performance requirements for each phase
```

### Example 5: Creating Phased Plan for Single Feature

```
I need to implement the "Advanced Search" feature from 
requirements/search-feature.md, but the full feature is too large 
for a single PR (~800 lines of code total).

Current State:
- Basic task listing exists (shows all tasks)
- No search or filtering capability

Desired State:
- Text search (title + description)
- Filter by status (todo, in-progress, done)
- Filter by priority (low, medium, high)
- Filter by due date range
- Combine multiple filters (AND logic)
- Save search queries for reuse

Help me break this into 4 phases, each ~200 lines maximum:

Phase 1: Basic Text Search
- Search tasks by title (case-insensitive, partial match)
- Search tasks by description
- Command: `tasks search "keyword"`
- Return matches with highlighting (bold the matched term)

Phase 2: Status and Priority Filters  
- Filter by status: `tasks search --status todo`
- Filter by priority: `tasks search --priority high`
- Combine with text search: `tasks search "urgent" --status in-progress`

Phase 3: Date Range Filtering
- Filter by due date: `tasks search --due-before 2024-12-31`
- Filter by date range: `tasks search --due-after 2024-01-01 --due-before 2024-12-31`
- Combine with other filters

Phase 4: Saved Searches
- Save search query: `tasks search-save "my-query" --status todo --priority high`
- Run saved search: `tasks search-run "my-query"`
- List saved searches: `tasks search-list`
- Delete saved search: `tasks search-delete "my-query"`

For each phase, provide:

1. Classes/Methods to Create or Modify
   - Exact class names
   - Method signatures
   - Which existing code to update

2. Implementation Details
   - Key algorithms (e.g., text matching approach)
   - Data structures needed
   - Edge cases to handle

3. Testing Requirements
   - Unit tests to add (list specific test cases)
   - Manual testing steps
   - What to verify from previous phases (regression)

4. CLI Integration
   - Exact command syntax
   - Help text to add
   - Error messages for invalid input

5. What Gets Stubbed
   - What to prepare for future phases
   - Interface definitions for later phases
   - Placeholder logic that will be replaced

Constraints:
- Each phase must work independently (no broken states)
- Each phase must be fully tested before moving on
- Each phase should provide user value (no "infrastructure only" phases)
- Each phase must pass ALL existing tests (no regressions)

Ask questions about:
- Text search algorithm preference (contains, starts-with, regex?)
- Case sensitivity requirements
- Performance expectations (how many tasks max?)
- Saved search storage mechanism (file, database?)
```

### Example 6: Phased Refactoring Plan

```
The BookService class in Services/BookService.cs has grown to 850 lines 
and has too many responsibilities. It handles:
- Book CRUD operations
- Validation logic
- Search/filtering
- Checkout/return logic
- Overdue calculations
- Report generation

I need a phased refactoring plan that extracts these into separate services 
while maintaining all existing functionality.

Create a 4-phase plan, each phase ~150-200 lines:

Phase 1: Extract Validation Logic
- Create BookValidator class
- Move all validation methods from BookService
- Update BookService to use BookValidator
- Ensure all existing validation still works

Phase 2: Extract Search Logic
- Create BookSearchService class  
- Move search, filter, and query methods
- Keep BookService with CRUD only
- Update callers to use BookSearchService

Phase 3: Extract Checkout Logic
- Create CheckoutService class
- Move checkout, return, overdue calculation methods
- Manage checkout state separately
- Update CLI commands to use CheckoutService

Phase 4: Update Tests
- Refactor test structure to match new services
- Add tests for new service boundaries
- Ensure 100% of original tests still pass
- Add integration tests for service interactions

For each phase:

1. Show Exact Method Moves
   - List each method moving from BookService
   - Show where it goes (new class name)
   - Show new method signatures if they change

2. Identify Breaking Changes
   - What public APIs change?
   - How to maintain backward compatibility if needed
   - Migration path for callers

3. Specify Test Updates
   - Which test files to modify
   - New test files to create
   - How to verify existing behavior preserved

4. Rollback Plan
   - How to revert this phase if needed
   - What tests must pass before committing
   - Dependencies on earlier phases

Critical Requirements:
- ALL existing tests must pass after each phase
- NO change in external behavior (pure refactoring)
- Each phase is independently revertable
- No "half-moved" methods (complete extractions only)

Ask questions about:
- Dependency injection approach for new services
- Whether to introduce interfaces for each service
- How to handle cross-service dependencies
- Testing strategy (unit vs integration)
```

---

## Quick Reference: Decision Tree

```
Need to add/change something?
│
├─ Do I understand the requirements?
│  ├─ No → Research, explore, ask questions
│  └─ Yes ↓
│
├─ Is there an AGENTS.md?
│  ├─ No → Create one (or ask agent to draft)
│  └─ Yes ↓
│
├─ Does AGENTS.md cover this pattern?
│  ├─ No → Update AGENTS.md
│  └─ Yes ↓
│
├─ Write spec for the change
│  ├─ Requirements
│  ├─ Acceptance criteria
│  ├─ Examples
│  └─ Edge cases
│
├─ Agent generates implementation
│
├─ Review output
│  ├─ Matches spec? → Test and verify
│  └─ Doesn't match? → Update spec or AGENTS.md, regenerate
```

---

## Further Reading

- **Project Documentation:** Link your team's standards
- **Prompt Engineering:** OpenAI/Anthropic prompt guides
- **Test-Driven Development:** Similar "requirements-first" mindset
- **Architecture Decision Records:** Document "why" behind patterns

---

## Remember

> "The quality of the AI's output is directly proportional to the quality of your requirements and implementation plan."

Invest time in clear requirements. The code will follow.
