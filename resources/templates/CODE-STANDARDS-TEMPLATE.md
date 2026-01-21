# Code Standards Template

Use this template to capture coding conventions, naming rules, error handling,
and testing standards for a project. Keep it generic and focused on how code
should be written and verified.

---

# Code Standards

## Coding Conventions

> **Reference:** [Link to your language or org coding conventions]

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
