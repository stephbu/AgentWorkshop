# Brownfield Lab: Extending Existing Code

**Duration:** ~75 minutes  
**Goal:** Learn to apply requirements-first development to an existing codebase you didn't write.

---

## Overview

In this lab, you will:
1. Explore an unfamiliar C# codebase (Book Library)
2. Create an `AGENTS.md` file to document conventions
3. Retroactively write Product Requirements for existing functionality
4. Add unit tests for existing code (establish baseline)
5. Write Feature Requirements and Implementation Plan for a new feature
6. Implement the feature with AI agents, including new tests
7. Verify all tests pass and no regressions occurred

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
What design patterns are used in this codebase?
```

```
Are there any code smells or areas that could be improved?
```

```
What testing strategy is currently in place?
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

💡 **Remember: The agent is your assistant for this too!**

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
What conventions do you observe in the BookLibrary codebase?
What should I document in AGENTS.md?
```

### Step 2.2: Review and refine

The agent's draft is a starting point. Review it and ask follow-up questions:

**Verify accuracy:**
```
Is the BookService pattern you described consistent across all methods?
```

```
Are there any conventions in the code that you didn't include?
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

## Part 3: Retroactively Document Product Requirements (10 minutes)

Before adding new features, document what the system currently does. This creates a baseline and helps you understand the existing behavior.

### Step 3.1: Generate Product Requirements with AI

**Prompt:**
```
Analyze the BookLibrary codebase and generate a Product Requirements Document that describes the CURRENT functionality:

1. Purpose - What problem does this system solve?
2. Users - Who uses this system?
3. Features - What can users do with it today?
4. Functional Requirements - List each existing capability
5. Non-Functional Requirements - Performance, reliability, etc.
6. Data Model - What entities exist and how do they relate?
7. CLI Interface - Document all current commands and their parameters

Before generating, ask me clarifying questions about:
- The intended use cases
- Any undocumented business rules
- Edge cases you're unsure about
```

💡 **Answer the agent's questions thoughtfully** - they often reveal edge cases or assumptions in the code!

### Step 3.2: Review and validate

Check the generated requirements against the actual code:

```
Does the checkout command actually enforce any limits on how many books a user can check out?
```

```
What happens if someone tries to add a book with a duplicate ISBN?
```

Save to: `/02-brownfield/BookLibrary/requirements/PRODUCT-REQUIREMENTS.md`

---

## Part 4: Add Unit Tests for Existing Code (10 minutes)

Before adding new features, establish a test baseline for existing functionality.

### Step 4.1: Generate unit tests for current functionality

**Prompt:**
```
Based on the Product Requirements document and the existing BookService code, generate unit tests that verify the current behavior:

1. Create a test project structure
2. Write tests for each existing method in BookService
3. Include edge cases and error conditions
4. Follow xUnit conventions

Ask me questions if any expected behavior is unclear.
```

### Step 4.2: Build and run tests

```bash
cd /02-brownfield/BookLibrary
dotnet build
dotnet test
```

✅ All tests should pass - they verify the *existing* behavior

💡 **If tests fail**, it means either:
- The tests don't match the actual behavior (fix the tests)
- There's a bug in the existing code (document it)

---

## Part 5: Choose a Feature and Write Requirements (10 minutes)

Now you're ready to add a new feature. Select ONE:

### Option A: Book Ratings
Allow users to rate books (1-5 stars) and display average ratings.

### Option B: Due Dates
Add due dates for checked-out books and show overdue books.

### Option C: Book Categories
Add categories/genres to books and filter by category.

### Option D: Export to CSV
Export the book list to a CSV file.

### Step 5.1: Write feature requirements

**Prompt:**
```
I want to add [FEATURE NAME] to the BookLibrary project.

Write a Feature Requirements document that includes:
1. Feature overview and user value
2. Functional requirements (what it should do)
3. Acceptance criteria (Given-When-Then format)
4. CLI commands (new or modified)
5. Error handling requirements
6. Integration with existing code

Reference AGENTS.md for coding conventions.
Reference PRODUCT-REQUIREMENTS.md for existing behavior context.

Before writing, ask me clarifying questions about the feature.
```

### Step 5.2: Write implementation plan

**Prompt:**
```
Based on the feature requirements, create an Implementation Plan:

1. Files to modify (list each with what changes)
2. New files to create
3. Step-by-step implementation order
4. New unit tests needed
5. Existing tests that might need updates
6. Verification steps

Keep each step small enough to verify independently.
```

Save to: `/02-brownfield/BookLibrary/requirements/[FEATURE-NAME]-REQUIREMENTS.md`

---

## Part 6: Implement Feature with Tests (12 minutes)

### Step 6.1: Generate feature code AND tests together

**Prompt:**
```
Implement [FEATURE NAME] based on:
- AGENTS.md for coding conventions
- requirements/[FEATURE-NAME]-REQUIREMENTS.md for requirements and implementation plan

Generate:
1. The feature implementation code
2. Unit tests for the new functionality
3. Any updates to existing tests if needed

Follow the implementation plan step by step.
```

### Step 6.2: Verify agent follows conventions

As the agent generates code, check:
- ✅ Does it match naming conventions from AGENTS.md?
- ✅ Does it follow existing patterns?
- ✅ Are error messages consistent?
- ✅ Are tests following the same style as existing tests?

### Step 6.3: Iterate if needed

If output doesn't match expectations:

**DON'T:** Edit code directly

**DO:** Clarify requirements or AGENTS.md, then regenerate:
```
The error messages should follow this format: "[Command] failed: [reason]"
Please regenerate the error handling to match this pattern.
```

---

## Part 7: Build and Test (8 minutes)

### Step 7.1: Build the project

```bash
cd /02-brownfield/BookLibrary
dotnet build
```

**Fix any compilation errors:**
```
There's a compilation error in [file]. Please fix it following AGENTS.md conventions.
```

### Step 7.2: Run ALL unit tests

```bash
dotnet test
```

✅ **All tests must pass** - both existing and new tests

### Step 7.3: Manual testing

Test your new feature:
```bash
dotnet run -- [your-new-command] [args]
```

### Step 7.4: Regression test existing features

**Critical:** Make sure you didn't break anything!

```bash
# Test existing commands still work
dotnet run -- add "Regression Test" "Test Author" "999"
dotnet run -- list
dotnet run -- search title "Regression"
dotnet run -- checkout [book-id]
dotnet run -- return [book-id]
```

**If anything breaks:**
- Check if existing tests caught it (they should!)
- Was the implementation plan missing steps?
- Did the agent not follow existing patterns?
- Fix by refining requirements, then regenerate

---

## Part 8: Reflect (5 minutes)

## Part 8: Reflect (5 minutes)

### Discussion Questions

1. **How did documenting existing requirements first help?**
   - Did it reveal assumptions or edge cases?
   - Did it make feature planning easier?

2. **How valuable was creating tests before adding features?**
   - Did they catch any regressions?
   - Did they give you confidence to make changes?

3. **How was this different from greenfield?**
   - More constraints? More context needed?

4. **Did having AGENTS.md help?**
   - Would it have been harder without it?
   - What should have been in AGENTS.md but wasn't?

5. **How much time did you spend understanding vs. implementing?**
   - Is this realistic for real brownfield work?

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
