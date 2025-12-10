# Implementation Plan Template

Use this template to define HOW the feature will be technically implemented.

**Prerequisites:** Complete Product Requirements document first. This plan translates product requirements into technical design.

---

# Implementation Plan: [Feature Name]

## Overview

**Feature:** [Feature name - link to Product Requirements]  
**Priority:** [High/Medium/Low]  
**Estimated Effort:** [Story points or time estimate]  
**Target Completion:** [Date or sprint]  
**Assigned To:** [Developer/Team]

---

## Technical Summary

**Approach:** [1-2 sentences describing the technical approach]

**Key Technologies:**
- [Technology/framework 1]
- [Technology/framework 2]
- [Library/package 3]

---

## Architecture & Design

### High-Level Architecture

Describe the layers or components of the system:

1. **[Layer/Component 1]:** [Purpose and responsibility]
2. **[Layer/Component 2]:** [Purpose and responsibility]
3. **[Layer/Component 3]:** [Purpose and responsibility]
4. **[Layer/Component 4]:** [Purpose and responsibility]

### Component Interactions

Describe how components communicate:

- [Component A] → [Component B]: [What data/calls flow between them]
- [Component B] → [Component C]: [What data/calls flow between them]

---

## Project Structure

```
/[ProjectName]
  /src
    /[ProjectName]
      /[Folder1]           - [Purpose]
      /[Folder2]           - [Purpose]
      /[Folder3]           - [Purpose]
      Program.cs           - [Purpose]
      [ProjectName].csproj
  /tests
    /[ProjectName].Tests
      /[Folder1]           - [Test purpose]
      /[Folder2]           - [Test purpose]
      [ProjectName].Tests.csproj
  AGENTS.md
  PRODUCT-REQUIREMENTS.md
  IMPLEMENTATION-PLAN.md
  README.md
```

---

## Component Design

### 1. [Component Name]

**Purpose:** [What this component does]

**Responsibilities:**
- [Responsibility 1]
- [Responsibility 2]
- [Responsibility 3]

**Key Design Decisions:**
- [Decision 1 and rationale]
- [Decision 2 and rationale]

**Interfaces/Contracts:**
- [Interface name]: [Methods/properties it exposes]

---

### 2. [Component Name]

**Purpose:** [What this component does]

**Responsibilities:**
- [Responsibility 1]
- [Responsibility 2]

**Key Implementation Details:**
- [Detail 1]
- [Detail 2]

---

### 3. [Component Name]

**Purpose:** [What this component does]

**Responsibilities:**
- [Responsibility 1]
- [Responsibility 2]

---

## Data Model

### Entities

| Entity | Properties | Purpose |
|--------|------------|---------|
| [Entity 1] | [Key properties] | [What it represents] |
| [Entity 2] | [Key properties] | [What it represents] |

### Data Storage

**Format:** [JSON, SQLite, in-memory, etc.]  
**Location:** [Where data is stored]  
**Access Pattern:** [Read-heavy, write-heavy, etc.]

---

## Error Handling Strategy

### Error Categories

| Category | Description | Handling Approach |
|----------|-------------|-------------------|
| [Category 1] | [When this occurs] | [How to handle] |
| [Category 2] | [When this occurs] | [How to handle] |
| [Category 3] | [When this occurs] | [How to handle] |

### Error Message Principles
- [Principle 1]
- [Principle 2]
- [Principle 3]

---

## Implementation Phases

### Phase 1: [Phase Name]
**Goal:** [What this phase accomplishes]
**Duration:** [Estimated time]

- [ ] [Task 1]
- [ ] [Task 2]
- [ ] [Task 3]
- [ ] Write unit tests for above

**Deliverable:** [What's complete at end of phase]

---

### Phase 2: [Phase Name]
**Goal:** [What this phase accomplishes]
**Duration:** [Estimated time]

- [ ] [Task 1]
- [ ] [Task 2]
- [ ] Write unit tests for above

**Deliverable:** [What's complete at end of phase]

---

### Phase 3: [Phase Name]
**Goal:** [What this phase accomplishes]
**Duration:** [Estimated time]

- [ ] [Task 1]
- [ ] [Task 2]
- [ ] Write unit tests for above

**Deliverable:** [What's complete at end of phase]

---

### Phase 4: [Phase Name]
**Goal:** [What this phase accomplishes]
**Duration:** [Estimated time]

- [ ] [Task 1]
- [ ] [Task 2]
- [ ] Final testing and polish

**Deliverable:** [What's complete at end of phase]

---

## Testing Strategy

### Unit Tests

**Coverage Target:** [Percentage]

**Test Organization:**
- One test class per production class
- Test naming: `[Method]_[Scenario]_[ExpectedResult]`
- Use Arrange-Act-Assert pattern

**Key Test Areas:**
- [Area 1]: [What to test]
- [Area 2]: [What to test]
- [Area 3]: [What to test]

### Fast vs Slow Tests

**Fast Tests (majority):**
- No I/O operations
- No async delays
- Complete in milliseconds

**Slow Tests:**
- Integration tests
- File system operations
- Mark with trait for selective execution

---

## Dependencies & Libraries

### NuGet Packages

| Package | Version | Purpose |
|---------|---------|---------|
| [Package 1] | >= [version] | [Purpose] |
| [Package 2] | >= [version] | [Purpose] |
| [Package 3] | >= [version] | [Purpose] |

### Framework Requirements
- **.NET SDK:** [Version]
- **C# Language:** [Version]
- **Target Platforms:** [Windows, macOS, Linux]

---

## Performance Considerations

### Expected Performance

| Operation | Target | Notes |
|-----------|--------|-------|
| [Operation 1] | [Time/Resource] | [Explanation] |
| [Operation 2] | [Time/Resource] | [Explanation] |

### Optimization Approach
- [When to optimize]
- [What to measure]
- [Acceptable tradeoffs]

---

## Risks & Mitigation

| Risk | Impact | Likelihood | Mitigation |
|------|--------|------------|------------|
| [Risk 1] | [High/Medium/Low] | [High/Medium/Low] | [How to address] |
| [Risk 2] | [High/Medium/Low] | [High/Medium/Low] | [How to address] |

---

## Open Questions

| # | Question | Options | Decision | Decided By | Date |
|---|----------|---------|----------|------------|------|
| 1 | [Question] | A) [Option 1] B) [Option 2] | [TBD or decision] | [Role] | [Date] |

---

## Definition of Done

Feature is complete when:

- [ ] All code follows AGENTS.md conventions
- [ ] All unit tests pass with >= [target]% coverage
- [ ] All acceptance criteria from Product Requirements verified
- [ ] Works on all target platforms
- [ ] README.md has clear usage instructions
- [ ] Documentation comments on public APIs
- [ ] Code reviewed

---

## Related Documents

- **Product Requirements:** `PRODUCT-REQUIREMENTS.md` (what to build)
- **AGENTS.md:** Project coding conventions
- **README.md:** User documentation

---

## Notes for Implementation

**Before starting:**
1. Review Product Requirements document
2. Review AGENTS.md conventions
3. Set up project structure

**During implementation:**
1. Follow phases in order
2. Write tests alongside code
3. Run affected tests after each change
4. Commit frequently with clear messages

**Key reminders:**
- [Domain-specific reminder 1]
- [Domain-specific reminder 2]
- [Domain-specific reminder 3]
