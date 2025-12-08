# Contributing to Agent Workshop

Thank you for your interest in contributing to this workshop! We welcome contributions that improve the learning experience for developers learning AI-assisted development.

## Table of Contents

- [Code of Conduct](#code-of-conduct)
- [How to Contribute](#how-to-contribute)
- [Types of Contributions](#types-of-contributions)
- [Getting Started](#getting-started)
- [Contribution Guidelines](#contribution-guidelines)
- [Style Guide](#style-guide)
- [Pull Request Process](#pull-request-process)
- [Questions](#questions)

---

## Code of Conduct

This project follows standard open source community guidelines. Please be respectful, inclusive, and constructive in all interactions.

---

## How to Contribute

### Reporting Issues

If you find a problem with the workshop materials:

1. **Check existing issues** to see if it's already reported
2. **Create a new issue** with:
   - Clear, descriptive title
   - Which file(s) are affected
   - What you expected vs. what you found
   - Screenshots if relevant (especially for formatting issues)

### Suggesting Enhancements

Have an idea to improve the workshop?

1. **Open an issue** with the "enhancement" label
2. Describe:
   - The improvement you're suggesting
   - Why it would benefit learners
   - Any examples or references

---

## Types of Contributions

We welcome these types of contributions:

### Content Improvements
- Fixing typos, grammar, or unclear wording
- Improving code examples
- Adding missing explanations
- Updating outdated information

### New Content
- Additional prompt examples
- New code patterns for the cheatsheet
- Extended exercises or challenges
- Translations (see [Translation Guidelines](#translations))

### Technical Fixes
- Fixing broken links
- Correcting code syntax errors
- Updating dependencies in sample projects
- Fixing markdown formatting issues

### Structural Improvements
- Better organization of content
- Improved navigation (table of contents, cross-references)
- Accessibility improvements

---

## Getting Started

### Prerequisites

- Git
- A markdown editor (VS Code recommended)
- .NET 8.0 SDK (to verify code examples)
- Basic familiarity with the workshop content

### Setup

1. **Fork the repository**
   ```bash
   # Click "Fork" on GitHub, then clone your fork
   git clone https://github.com/YOUR-USERNAME/AgentWorkshop.git
   cd AgentWorkshop
   ```

2. **Create a branch**
   ```bash
   git checkout -b fix/typo-in-cheatsheet
   # or
   git checkout -b feature/add-python-examples
   ```

3. **Make your changes**
   - Edit files as needed
   - Test any code examples
   - Preview markdown rendering

4. **Commit and push**
   ```bash
   git add .
   git commit -m "Fix typo in CHEATSHEET.md"
   git push origin fix/typo-in-cheatsheet
   ```

5. **Open a Pull Request**
   - Go to your fork on GitHub
   - Click "Compare & pull request"
   - Fill in the PR template

---

## Contribution Guidelines

### General Principles

1. **Keep the learner in mind** - All content should help someone learning AI-assisted development
2. **Be consistent** - Follow existing patterns and terminology
3. **Be concise** - Workshop time is limited; every word should add value
4. **Test everything** - Code examples must work; instructions must be followable

### Terminology Consistency

Use these terms consistently throughout:

| Use This | Not This |
|----------|----------|
| Greenfield | Green field, green-field |
| Brownfield | Brown field, brown-field |
| AGENTS.md | agents.md, Agents.md |
| Product Requirements | PRD, spec, specification |
| Implementation Plan | design doc, technical spec |
| GitHub Copilot | Copilot, copilot |

### Code Examples

- Use C# 12 / .NET 8.0 syntax
- Follow the conventions documented in `AGENTS-TEMPLATE.md`
- Include comments for non-obvious code
- Test all code examples before submitting

### File Naming

- Use UPPER-CASE for documentation: `README.md`, `CONTRIBUTING.md`
- Use kebab-case for template files: `AGENTS-TEMPLATE.md`
- Use PascalCase for C# files: `BookService.cs`

---

## Style Guide

### Markdown Formatting

```markdown
# Document Title (H1 - one per file)

## Major Section (H2)

### Subsection (H3)

#### Minor Subsection (H4 - use sparingly)

**Bold** for emphasis
`code` for inline code, file names, commands
```code blocks``` for multi-line code

- Bullet lists for unordered items
1. Numbered lists for sequential steps

| Tables | For | Structured Data |
|--------|-----|-----------------|

> Blockquotes for callouts or quotes

---  (horizontal rules between major sections)
```

### Code Blocks

Always specify the language:

~~~markdown
```csharp
// C# code here
```

```bash
# Shell commands here
```

```markdown
# Markdown examples here
```
~~~

### Prompts and Examples

Format AI prompts consistently:

```markdown
**Prompt:**
```
Your prompt text here.
Include context and be specific.
```
```

### Callouts

Use bold text for callout types:

```markdown
**💡 Pro Tip:** Helpful advice here.

**⚠️ Warning:** Important caution here.

**📝 Note:** Additional information here.
```

---

## Pull Request Process

### Before Submitting

- [ ] Spell-check your changes
- [ ] Preview markdown rendering (VS Code preview or GitHub)
- [ ] Test any code examples
- [ ] Check for broken links
- [ ] Ensure consistent terminology
- [ ] Update Table of Contents if adding new sections

### PR Title Format

Use descriptive titles:

- `Fix: Typo in CHEATSHEET.md`
- `Add: Python code examples to cheatsheet`
- `Update: .NET version references to 8.0`
- `Improve: Brownfield lab instructions clarity`

### PR Description

Include:

1. **What** - What changes are you making?
2. **Why** - Why are these changes needed?
3. **Testing** - How did you verify the changes work?
4. **Screenshots** - If applicable (formatting changes, etc.)

### Review Process

1. Maintainer reviews the PR
2. Feedback may be requested
3. Once approved, PR is merged
4. Your contribution is acknowledged! 🎉

---

## Translations

We welcome translations of the workshop materials!

### Translation Guidelines

1. **Create a language folder**: `translations/es/`, `translations/ja/`, etc.
2. **Translate content files** - Keep the same structure
3. **Keep code examples in English** - Code should remain universal
4. **Translate comments** in code examples
5. **Update links** to point to translated versions where available

### Translation Checklist

- [ ] All markdown files translated
- [ ] Code comments translated
- [ ] Links updated or noted as English-only
- [ ] README.md in translation folder explains the translation

---

## Questions?

- **Open an issue** for questions about contributing
- **Check existing issues** for answered questions
- **Review the workshop materials** for context

---

## Recognition

Contributors are valued! Significant contributions will be acknowledged in:

- The repository's README
- Release notes for major updates

Thank you for helping make this workshop better for everyone! 🚀
