# Brownfield Lab: Extending Existing Code

**Duration:** ~60 minutes  
**Goal:** Learn to apply requirements-first development to an existing codebase you didn't write.

---

## Overview

In this lab, you will:
1. Explore an unfamiliar C# codebase (Book Library)
2. Create or discover an `AGENTS.md` file to document conventions
3. Write Product Requirements and Implementation Plan for a new feature
4. Use AI agents to implement the feature following existing patterns
5. Verify the implementation doesn't break existing functionality

---

## The Project: Book Library

You've been assigned to extend an existing Book Library command-line application. The current system allows:
- Adding books
- Listing books
- Searching by title/author
- Checking out books
- Returning books
- Removing books

**Your task:** Add a new feature (you'll choose which one below).

---

## Part 1: Explore the Codebase (15 minutes)

### Step 1.1: Check for AGENTS.md

Look at the project root: `/02-brownfield/BookLibrary/`

**Is there an `AGENTS.md` file?**

❌ **No** - This is intentional! Most brownfield projects don't have one.

This is a key learning moment: **You'll need to create it.**

### Step 1.2: Understand the codebase structure

**💡 Key Success Pattern: ASK QUESTIONS!**

**Use the AI agent to help - it's your exploration partner:**

**Prompt:**
```
Analyze the BookLibrary project structure. 
Describe:
1. What folders/files exist
2. What each component does
3. What conventions are being followed (naming, patterns, etc.)
4. Any dependencies or external libraries
```

**More questions to ask:**
```
"What design patterns are used in this codebase?"

"Are there any code smells or areas that could be improved?"

"What testing strategy is currently in place?"
```

**Look for:**
- Project structure (/Models, /Services, etc.)
- Naming conventions (PascalCase? camelCase?)
- Error handling patterns
- How commands are implemented
- Where business logic lives

### Step 1.3: Run the existing application

Build and test the current functionality:

```bash
cd /02-brownfield/BookLibrary
dotnet build
dotnet run -- add "Test Book" "Test Author" "123-456"
dotnet run -- list
```

**Verify:**
- ✅ Application builds without errors
- ✅ Commands work as expected
- ✅ You understand basic usage

### Step 1.4: Ask the agent to explain key components

**Prompts to try:**
```
Explain what BookService does and how it manages books.
```

```
Show me how the checkout feature works end-to-end.
```

```
What error handling patterns are used in this codebase?
```

**Goal:** Build a mental model of the codebase before making changes.

**Remember:** Agents are great at code archaeology! Use them to understand before you build.

---

## Part 2: Create AGENTS.md (15 minutes)

Since this project doesn't have an `AGENTS.md`, you'll create one.

**\ud83d\udca1 Remember: The agent is your assistant for this too!**

### Step 2.1: Draft AGENTS.md with AI assistance

**Ask the agent to do the heavy lifting:**

**Prompt:**
```
Analyze the BookLibrary codebase and create an AGENTS.md file that documents:
1. Project overview and purpose
2. Tech stack
3. Project structure
4. Coding conventions observed
5. Patterns used (error handling, validation, etc.)
6. Instructions for agents working in this codebase

Base this on actual patterns you observe in the code, not ideal practices.
```

**Alternative approach - ask questions first:**
```
\"What conventions do you observe in the BookLibrary codebase?
What should I document in AGENTS.md?\"
```

### Step 2.2: Review and refine

The agent's draft is a starting point. Review it and ask follow-up questions:

**Verify accuracy:**
```
\"Is the BookService pattern you described consistent across all methods?\"

\"Are there any conventions in the code that you didn't include?\"
```

**Check for completeness:**
- Does it correctly describe the structure?
- Are the conventions actually followed in the code?
- Any hallucinations or assumptions?

**Add missing info:**
- Known issues or technical debt
- Areas to avoid modifying  
- Constraints for new features

**Example additions:**
```markdown
## Known Issues
- Books are only stored in memory (not persisted)
- No duplicate ISBN detection
- Search is case-insensitive but only does substring matching

## Areas to Avoid
- Don't modify the Book model without considering breaking changes
- Program.cs is monolithic but works—refactor only if necessary

## Constraints for New Features
- Keep command-line interface simple
- Follow existing command pattern (verb + arguments)
- Maintain backward compatibility with existing commands
```

### Step 2.3: Save AGENTS.md

Save your refined `AGENTS.md` to:
`/02-brownfield/BookLibrary/AGENTS.md`

Use the [AGENTS-TEMPLATE-BROWNFIELD.md](./AGENTS-TEMPLATE-BROWNFIELD.md) for reference.

---

## Part 3: Choose a Feature and Write Requirements (10 minutes)

Select ONE feature to add:

### Option A: Book Ratings
Allow users to rate books (1-5 stars) and display average ratings.

### Option B: Due Dates
Add due dates for checked-out books and show overdue books.

### Option C: Book Categories
Add categories/genres to books and filter by category.

### Option D: Export to CSV
Export the book list to a CSV file.

### Step 3.1: Write the feature requirements

Create: `/02-brownfield/BookLibrary/requirements/[FEATURE-NAME]-REQUIREMENTS.md`

**Include these sections:**
- Clear requirements
- Acceptance criteria (Given-When-Then)
- Examples showing usage
- Error cases
- Technical constraints
- Implementation plan

**Key for brownfield:**
```markdown
## Integration Points
- Existing components to modify: [list]
- New components to create: [list]
- Breaking changes: [none/describe]

## Implementation Plan
1. [Step-by-step implementation approach]
2. [What to modify vs. what to create new]
3. [Testing strategy]

## Constraints
- Must follow existing command pattern
- Must not break existing functionality
- Must match existing code style (from AGENTS.md)
```

### Step 3.2: Reference AGENTS.md in your requirements

Example:
```markdown
## Implementation Plan
1. Add properties to Book model (Models/Book.cs)
2. Add methods to BookService (Services/BookService.cs)
3. Add command handler in Program.cs following existing pattern
4. Update help text in ShowHelp()
5. Follow error handling patterns from AGENTS.md
6. Test with existing commands to ensure no breakage
```

---

## Part 4: Implement with AI Agent (12 minutes)

Now use the agent to implement your feature.

### Step 4.1: Provide context

**Prompt:**
```
I want to add [FEATURE NAME] to the BookLibrary project.

Context:
- Review AGENTS.md for project conventions
- Review requirements/[FEATURE-NAME]-REQUIREMENTS.md for requirements and implementation plan
- Follow existing patterns in the codebase
- Don't break existing functionality

Please implement this feature.
```

### Step 4.2: Verify agent follows conventions

As the agent generates code, check:
- ✅ Does it match naming conventions?
- ✅ Does it follow existing patterns?
- ✅ Are error messages consistent with existing ones?
- ✅ Is the command structure similar to existing commands?

### Step 4.3: Iterate if needed

If the output doesn't match expectations:

**DON'T:** Edit code directly

**DO:** Update your requirements or AGENTS.md with more clarity:

```markdown
## Command Output Format
All list commands should use this format:
```
ID: [guid]
Title: [title]
Author: [author]
[other fields]
[blank line]
```

Match the format used by the existing 'list' command.
```

Then: "Regenerate the list command using the format specified in AGENTS.md."

---

## Part 5: Test & Verify (8 minutes)

### Step 5.1: Build the updated project

```bash
cd /02-brownfield/BookLibrary
dotnet build
```

**Fix any compilation errors** by asking agent:
```
There's a compilation error in [file]. Please fix it following AGENTS.md conventions.
```

### Step 5.2: Test new functionality

Test your new feature:
```bash
# Test the new feature
dotnet run -- [your-new-command] [args]
```

### Step 5.3: Regression test existing features

**Critical:** Make sure you didn't break anything!

```bash
# Test existing commands still work
dotnet run -- add "Regression Test" "Test Author" "999"
dotnet run -- list
dotnet run -- search title "Regression"
```

**If anything breaks:**
- Note what broke
- Was it because your requirements were unclear?
- Was the implementation plan missing steps?
- Or because the agent didn't follow existing patterns?
- Fix by refining AGENTS.md or requirements, then regenerate

---

## Part 6: Reflect (5 minutes)

### Discussion Questions

1. **How was this different from greenfield?**
   - More constraints? More context needed?

2. **Did having AGENTS.md help?**
   - Would it have been harder without it?
   - What should have been in AGENTS.md but wasn't?

3. **How much time did you spend understanding vs. implementing?**
   - Is this realistic for real brownfield work?

4. **What patterns did you discover?**
   - Were they obvious?
   - Should they be documented?

5. **Did the implementation plan help?**
   - Did it guide the agent effectively?
   - What was missing?

6. **Did the agent follow existing patterns automatically?**
   - When did it diverge?
   - How did you correct it?

---

## Bonus Challenges

If you finish early:

### Challenge 1: Add unit tests
- The project doesn't have tests yet
- Write requirements and implementation plan for test coverage
- Have agent generate xUnit tests
- Update AGENTS.md with testing conventions

### Challenge 2: Add a second feature
- Pick another feature from the list
- Update AGENTS.md with patterns you established
- Write requirements and implementation plan
- Implement the feature
- See if it's easier the second time

### Challenge 3: Refactor for persistence
- Currently books only exist in memory
- Write requirements and implementation plan for JSON file persistence
- Implement without breaking existing functionality
- (Hint: This tests your ability to modify core functionality carefully)

---

## Common Pitfalls

### ❌ Pitfall 1: Diverging from existing patterns
**Symptom:** Your new code looks different from the rest

**Fix:** Update AGENTS.md with specific examples from existing code, then regenerate

### ❌ Pitfall 2: Breaking existing functionality
**Symptom:** Old commands stop working

**Fix:** Add to your requirements: "Verify all existing commands still work" as an acceptance criterion

### ❌ Pitfall 3: Over-engineering
**Symptom:** Adding dependency injection, abstractions, etc. when the rest doesn't use them

**Fix:** AGENTS.md should say: "Keep consistency with existing code even if not ideal"

### ❌ Pitfall 4: Incomplete implementation plan
**Symptom:** Code compiles but doesn't work correctly

**Fix:** Include more detailed steps in implementation plan and more examples in requirements

---

## Key Takeaways

✅ **AGENTS.md is even more important in brownfield** - Documents tribal knowledge  
✅ **Exploration comes first** - Understand before modifying  
✅ **Follow existing patterns** - Consistency > perfection  
✅ **Requirements describe the delta** - Describe changes, not the whole system  
✅ **Implementation plan bridges old and new** - Guide how to integrate the feature  
✅ **Test existing functionality** - Regression testing is critical  
✅ **Iterate on context** - Improve AGENTS.md as you learn  

---

## What's Next?

You've now practiced spec-first development in both:
- ✅ **Greenfield** - Starting from nothing
- ✅ **Brownfield** - Extending existing code

### Bonus Exercise: Code Modernization

If you have extra time or want additional practice, try the **Legacy Inventory Modernization Exercise**:

📁 **Project:** [LegacyInventory/](./LegacyInventory/)  
📋 **Instructions:** [UPGRADE-EXERCISE.md](./UPGRADE-EXERCISE.md)

This exercise teaches you how to use AI agents to:
- Upgrade from C# 10 to C# 12 language features
- Migrate from Newtonsoft.Json to System.Text.Json
- Apply modern patterns like primary constructors
- Ensure all 32 unit tests pass after modernization

The next step is applying this to your real projects!

**Resources:** See [../resources/](../resources/) for best practices, cheat sheets, and further reading.
