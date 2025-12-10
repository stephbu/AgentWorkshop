# Implementation Plan Template (Brownfield)

Use this template to define HOW a feature will be technically implemented in an **existing codebase**.

**Prerequisites:** Complete Product Requirements document first. This plan translates product requirements into technical design while respecting existing patterns.

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

**Key Constraints:**
- [Existing pattern or system to integrate with]
- [Technology limitations]
- [Backward compatibility requirements]

---

## Impact Analysis

### Files to Modify

List all existing files that need changes:

| File | Type of Change | Risk Level |
|------|----------------|------------|
| [path/to/file.cs] | [Add method / Modify class / Update interface] | [Low/Medium/High] |
| [path/to/file.cs] | [Add property / Change signature] | [Low/Medium/High] |

### New Files to Create

| File | Purpose |
|------|---------|
| [path/to/newfile.cs] | [Brief description] |

### Files NOT to Modify

List any files that should be left alone and why:

| File | Reason to Avoid |
|------|-----------------|
| [path/to/file.cs] | [Stability concern / Out of scope / etc.] |

---

## Integration Points

### Existing Components Affected

For each existing component this feature touches:

**[Component Name]**
- **Current Behavior:** [What it does now]
- **Required Changes:** [What needs to change]
- **Integration Approach:** [How new code will integrate]
- **Risk:** [What could break]

### Dependencies

**This feature depends on:**
- [Existing component/service 1]
- [Existing component/service 2]

**Other features that depend on components we're modifying:**
- [Feature/component that could be affected]

---

## Implementation Phases

Break the work into small, independently testable phases.

### Phase 1: [Phase Name]
**Goal:** [What this phase accomplishes]

**Tasks:**
- [ ] [Specific task 1]
- [ ] [Specific task 2]
- [ ] [Write tests for this phase]
- [ ] [Verify existing tests still pass]

**Verification:** [How to confirm this phase is complete]

---

### Phase 2: [Phase Name]
**Goal:** [What this phase accomplishes]

**Tasks:**
- [ ] [Specific task 1]
- [ ] [Specific task 2]
- [ ] [Write tests for this phase]
- [ ] [Verify existing tests still pass]

**Verification:** [How to confirm this phase is complete]

---

### Phase 3: [Phase Name]
**Goal:** [What this phase accomplishes]

**Tasks:**
- [ ] [Specific task 1]
- [ ] [Specific task 2]
- [ ] [Write tests for this phase]
- [ ] [Verify existing tests still pass]

**Verification:** [How to confirm this phase is complete]

---

## Testing Strategy

### Existing Tests

**Tests that must continue to pass:**
- [ ] [Test class/method 1]
- [ ] [Test class/method 2]

**Existing tests that need updates:**
- [ ] [Test to update] - Reason: [why it needs to change]

### New Tests Required

**Fast Tests (no I/O, run in milliseconds):**
- [ ] [New test 1 - what it validates]
- [ ] [New test 2 - what it validates]

**Slow Tests (I/O, integration, computation):**
- [ ] [Integration test 1 - what it validates]

### Regression Testing

**Manual verification steps:**
1. [Existing feature 1] - Verify still works
2. [Existing feature 2] - Verify still works
3. [New feature] - Verify works as specified

---

## Error Handling

### New Error Scenarios

| Scenario | Error Type | User Message | Recovery |
|----------|------------|--------------|----------|
| [When X happens] | [Exception type] | [What user sees] | [How to recover] |

### Integration with Existing Error Handling

- Follow existing pattern: [describe existing error handling approach]
- New errors should [match existing style / use existing base class / etc.]

---

## Rollback Plan

If the feature needs to be reverted:

1. [Step to revert change 1]
2. [Step to revert change 2]
3. [How to verify rollback worked]

**Data migration considerations:** [Any data changes that would need reverting?]

---

## Risks & Mitigation

| Risk | Impact | Likelihood | Mitigation |
|------|--------|------------|------------|
| [Breaking existing feature X] | High | Medium | [Run full test suite, manual testing] |
| [Performance degradation] | Medium | Low | [Benchmark before/after] |
| [Data compatibility] | High | Low | [Test with existing data files] |

---

## Open Questions

| # | Question | Options | Decision | Decided By | Date |
|---|----------|---------|----------|------------|------|
| 1 | [Question about approach] | A) [Option 1] B) [Option 2] | [TBD or decision] | [Role] | [Date] |

---

## Definition of Done

Feature is complete when:

- [ ] All code follows existing conventions (per AGENTS.md)
- [ ] All new code has corresponding tests
- [ ] All existing tests still pass
- [ ] New tests pass
- [ ] Manual regression testing completed
- [ ] Documentation updated (if applicable)
- [ ] Code reviewed
- [ ] No critical bugs

---

## Notes for Implementation

**Before starting:**
1. Review AGENTS.md for existing conventions
2. Understand the components you'll be modifying
3. Run existing tests to establish baseline
4. Create feature branch

**During implementation:**
1. Follow phases in order
2. Run affected tests after each change
3. Commit frequently with clear messages
4. Update this plan if approach changes

**If you encounter issues:**
1. Check if existing patterns are documented
2. Look at similar existing code for examples
3. Update this plan with new learnings
4. Discuss with team if design needs revision

---

## Related Documents

- **Product Requirements:** [Link to requirements document]
- **AGENTS.md:** Project coding conventions
- **Existing Documentation:** [Links to relevant existing docs]
