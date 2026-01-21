# AGENTS.md Template (General)

Use this template to create an `AGENTS.md` file for any project. Keep it focused on how the agent should work in this repo.

---

# AGENTS.md

## Project Overview

**What:** [Brief description of what this project does]  
**Why:** [Problem it solves or value it provides]  
**Users:** [Who uses it]

---

## Tech Stack

- **Language:** [Language and version]
- **Framework:** [Framework/runtime]
- **Key Libraries:** [List core libraries or packages]
- **Testing:** [Test framework]
- **Data Storage:** [DB, files, in-memory, etc.]
- **Deployment/Runtime:** [Where/how it runs]

---

## Project Structure

```
/ProjectName
  /docs              - [Documentation]
  /src               - [Source code]
  /tests             - [Tests]
  [Key files]
```

Describe any important folders or conventions that agents should follow.

---

## Coding Conventions

> **Reference:** Link to your language or org coding conventions.

- [Convention 1]
- [Convention 2]
- [Convention 3]

---

## Naming Conventions

- **Types/Classes:** [Pattern]
- **Functions/Methods:** [Pattern]
- **Variables/Parameters:** [Pattern]
- **Files:** [Pattern]

---

## Error Handling

- [How errors should be handled]
- [Logging format or system]
- [What to avoid]

---

## Testing Standards

### Test Classification

Classify tests as **Fast** or **Slow**:

**Fast Tests:**
- Complete in milliseconds
- No I/O (file, network, database)
- No async delays
- No intensive computation
- Majority of tests

**Slow Tests:**
- Involve I/O operations
- Include real async delays
- Require intensive computation
- Integration tests crossing boundaries

### Test Practices

- Run affected tests after each change
- Keep tests independent (no shared mutable state)
- Maintain test library as requirements change

---

## Instructions for Agents

1. [Primary rule for changes]
2. [Where to add tests]
3. [How to update docs]
4. [Any constraints or safety rules]

---

## Known Pitfalls or Constraints

- [Pitfall 1]
- [Pitfall 2]
