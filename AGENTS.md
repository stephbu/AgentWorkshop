# AGENTS.md

## Project Overview

**What:** A half-day workshop teaching developers requirements-first development with AI agents (GitHub Copilot agent mode).

**Purpose:** Provide structured training materials, templates, and hands-on labs for learning effective AI-assisted software development.

**Users:** Workshop facilitators and participants (software developers with C# experience).

---

## Repository Type

This is a **documentation and training repository**, not a software application. It contains:
- Workshop instructions and lab guides
- Reusable templates for AGENTS.md, Product Requirements, and Implementation Plans
- Sample projects for hands-on exercises
- Presentation slides and reference materials

---

## Repository Structure

```
/AgentWorkshop
  /00-prerequisites          - Setup instructions for workshop participants
    SETUP.md                 - Environment setup guide (VS Code, .NET, Copilot)
    TROUBLESHOOTING.md       - Common issues and solutions
  
  /01-greenfield             - Lab: Building from scratch
    INSTRUCTIONS.md          - Step-by-step lab guide
    AGENTS-TEMPLATE.md       - Template for new C# projects
    PRODUCT-REQUIREMENTS-TEMPLATE.md
    IMPLEMENTATION-PLAN-TEMPLATE.md
  
  /02-brownfield             - Lab: Extending existing code
    INSTRUCTIONS.md          - Step-by-step lab guide
    AGENTS-TEMPLATE-BROWNFIELD.md  - Template for existing projects
    PRODUCT-REQUIREMENTS-TEMPLATE.md
    IMPLEMENTATION-PLAN-TEMPLATE.md
    UPGRADE-EXERCISE.md      - Bonus modernization exercise
    /BookLibrary             - Sample C# project for hands-on work
  
  /resources                 - Reference materials
    BEST-PRACTICES.md        - AI development best practices
    CHEATSHEET.md            - Quick reference for prompts
  
  COURSE-OUTLINE.md          - Detailed facilitator guide
  SLIDES.md                  - Presentation content
  README.md                  - Workshop overview
  AGENTS.md                  - This file
```

---

## Content Conventions

### Markdown Style

- Use ATX-style headers (`#`, `##`, `###`)
- Use fenced code blocks with language hints (```bash, ```markdown, ```csharp)
- Use tables for structured data
- Use emoji sparingly for visual emphasis (✅ ❌ 💡 ⚠️)
- Use blockquotes (`>`) for examples and tips

### Document Structure

**Lab Instructions (INSTRUCTIONS.md):**
- Start with title, duration, and goal
- Include Overview section with numbered steps
- Organize into Parts with Steps (Part 1 > Step 1.1, 1.2, etc.)
- Include "💡 Pro Tip" sections with copy-pasteable prompts
- End with Key Takeaways

**Templates (*-TEMPLATE.md):**
- Start with brief description of template purpose
- Use placeholder text in brackets: `[Feature Name]`, `[Description]`
- Provide section headings with descriptions of what content belongs there
- Keep templates generic—avoid project-specific code samples
- Include guidance comments about what to fill in

### Prompt Examples

When including example prompts for participants to copy:
- Use fenced code blocks (```) for copy-paste friendliness
- Keep prompts self-contained (don't require external context)
- Show the expected interaction pattern (what to ask, what agent will do)

---

## Platform-Specific Instructions

When providing setup or terminal instructions:

**Always provide both Windows and macOS versions:**

```markdown
**Windows (PowerShell):**
```powershell
cd $HOME\workshop
```

**macOS (Terminal):**
```bash
cd ~/workshop
```
```

---

## Template Guidelines

### What Templates Should Include

- Clear section headings describing content purpose
- Placeholder text showing what to fill in
- Guidance on what makes good content for each section
- References to related documents

### What Templates Should NOT Include

- Project-specific code samples (e.g., HighLow game, Task Manager code)
- Filled-in examples that are too specific to one use case
- Implementation details that belong in actual project files

**Rationale:** Templates should guide structure, not provide copy-paste solutions. Participants learn more by filling in templates themselves with agent assistance.

---

## Testing Concepts

When discussing unit tests in templates or instructions:

### Test Classification

Classify tests as **Fast** or **Slow**:

**Fast Tests:**
- Complete in milliseconds
- No I/O (file, network, database)
- No async delays
- No intensive computation
- Should be the majority of tests

**Slow Tests:**
- Involve I/O operations
- Include real async delays
- Require intensive computation
- Integration tests crossing boundaries

### Test Practices

- Run affected tests after each change
- Maintain test library (remove obsolete, update when requirements change)
- Keep tests independent—no shared mutable state

---

## Instructions for AI Agents

When working in this repository:

1. **This is documentation, not code** - Focus on clarity and instructional value
2. **Keep templates generic** - Avoid project-specific examples in templates
3. **Provide both platforms** - Include Windows and macOS instructions where relevant
4. **Use consistent formatting** - Match existing markdown style in the repo
5. **Maintain the workshop flow** - Changes should support the learning progression
6. **Make prompts copy-pasteable** - Use code blocks for example prompts
7. **Update related documents** - If changing structure, check for references in other files

### When Updating Lab Instructions

- Ensure step numbers are sequential
- Verify part numbers match the overview
- Check that file paths are consistent
- Confirm duration estimates are reasonable

### When Updating Templates

- Remove project-specific code samples
- Keep section descriptions helpful but generic
- Ensure templates work for any C# project, not just workshop examples

---

## Related Resources

- [.NET C# Coding Conventions](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- [GitHub Copilot Documentation](https://docs.github.com/en/copilot)
- [Markdown Guide](https://www.markdownguide.org/)
