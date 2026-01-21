# Role-Based Course Outlines

Draft role tracks assembled from 15-minute modules. Each outline is a suggested
sequence that can be adjusted based on audience depth and time.

## How to Read These

- Each module is ~15 minutes.
- Modules can be reordered if prerequisites and outputs are respected.
- Outputs should feed the next module (artifact chaining).

---

## Developer Track

**Goal:** Ship a working feature using requirements-first, with tests and
documented conventions.

| Sequence | Module ID | Title | Outputs |
| --- | --- | --- | --- |
| 1 | PR-01 | Install VS Code | VS Code installed |
| 2 | PR-02 | Clone Repo + Workspace Setup | Repo cloned |
| 3 | PR-03 | Install .NET SDK | .NET SDK installed |
| 4 | PR-04 | Install Copilot Extensions | Copilot installed |
| 5 | PR-05 | EMU Setup + Copilot Auth | Copilot authenticated |
| 6 | PR-06 | Enable Agent Mode + Verify | Agent mode verified |
| 7 | CC-01 | Requirements-First Mindset | Shared vocabulary |
| 8 | CC-02 | Repo-Centric Development Process | Repo-first workflow |
| 9 | CC-03 | AGENTS.md Purpose + Structure | AGENTS.md outline |
| 10 | CC-04 | Product Requirements Basics | Requirements outline |
| 11 | CC-05 | Implementation Plan Basics | Plan outline |
| 12 | CC-06 | Prompting Patterns + Pitfalls | Prompt checklist |
| 13 | CC-07 | Testing Practices (Fast vs Slow) | Test classification guide |
| 14 | GF-01 | Project Brief + Goal Setup | Project brief |
| 15 | GF-02 | Create AGENTS.md | `AGENTS.md` |
| 16 | GF-03 | Write Product Requirements | `PRODUCT-REQUIREMENTS.md` |
| 17 | GF-04 | Create Implementation Plan | `IMPLEMENTATION-PLAN.md` |
| 18 | GF-05 | Generate Implementation | Working code + tests |
| 19 | GF-06 | Build/Test + Iterate on Requirements | Updated requirements |
| 20 | WR-01 | Best Practices Recap + Next Steps | Action plan |

**Optional:** OP-01 (MCP setup), GF-07 (reflect/bonus), BF-* (brownfield track)

---

## Game Producer Track

**Goal:** Define clear requirements and guide delivery without writing code.

| Sequence | Module ID | Title | Outputs |
| --- | --- | --- | --- |
| 1 | PR-01 | Install VS Code | VS Code installed |
| 2 | PR-02 | Clone Repo + Workspace Setup | Repo cloned |
| 3 | PR-04 | Install Copilot Extensions | Copilot installed |
| 4 | PR-05 | EMU Setup + Copilot Auth | Copilot authenticated |
| 5 | PR-06 | Enable Agent Mode + Verify | Agent mode verified |
| 6 | CC-01 | Requirements-First Mindset | Shared vocabulary |
| 7 | CC-02A | What Is a Repo? | Repo basics shared |
| 8 | CC-02B | VS Code Orientation | Workspace navigation |
| 9 | CC-04 | Product Requirements Basics | Requirements outline |
| 10 | CC-06 | Prompting Patterns + Pitfalls | Prompt checklist |
| 11 | GF-01 | Project Brief + Goal Setup | Project brief |
| 12 | GF-03 | Write Product Requirements | `PRODUCT-REQUIREMENTS.md` |
| 13 | GF-04 | Create Implementation Plan | `IMPLEMENTATION-PLAN.md` |
| 14 | WR-01 | Best Practices Recap + Next Steps | Action plan |

**Optional:** CC-03 (AGENTS.md overview), CC-05 (plan depth), GF-06 (iterate)

---

## Compliance Program Manager Track

**Goal:** Establish a governed, traceable workflow with documented decisions.

| Sequence | Module ID | Title | Outputs |
| --- | --- | --- | --- |
| 1 | PR-01 | Install VS Code | VS Code installed |
| 2 | PR-02 | Clone Repo + Workspace Setup | Repo cloned |
| 3 | PR-04 | Install Copilot Extensions | Copilot installed |
| 4 | PR-05 | EMU Setup + Copilot Auth | Copilot authenticated |
| 5 | PR-06 | Enable Agent Mode + Verify | Agent mode verified |
| 6 | CC-01 | Requirements-First Mindset | Shared vocabulary |
| 7 | CC-02 | Repo-Centric Development Process | Repo-first workflow |
| 8 | CC-02A | What Is a Repo? | Repo basics shared |
| 9 | CC-04 | Product Requirements Basics | Requirements outline |
| 10 | CC-05 | Implementation Plan Basics | Plan outline |
| 11 | CC-06 | Prompting Patterns + Pitfalls | Prompt checklist |
| 12 | CC-07 | Testing Practices (Fast vs Slow) | Test classification guide |
| 13 | BF-01 | Explore Codebase + Conventions | Codebase notes |
| 14 | BF-04 | Baseline Product Requirements | Baseline requirements |
| 15 | BF-05 | Add Baseline Unit Tests | Baseline tests |
| 16 | BF-06 | Write Feature Requirements | Feature requirements |
| 17 | BF-07 | Create Implementation Plan | Plan for changes |
| 18 | BF-09 | Build/Test + Regression | Verified changes |
| 19 | WR-01 | Best Practices Recap + Next Steps | Action plan |

**Optional:** OP-01 (MCP setup), BF-03 (AGENTS.md for existing project)

---

## Composition Guidance

Use this checklist to compose a new role-based course:

1. **Define outcomes:** List the artifacts the role should produce (e.g.,
   `AGENTS.md`, requirements, plans, test evidence).
2. **Pick core concepts:** Start with CC-01, then add CC-02A/CC-02B for
   non-technical audiences.
3. **Select workflow path:** Greenfield (GF-*) for new projects, Brownfield
   (BF-*) for existing codebases.
4. **Respect prerequisites:** Ensure each module’s prerequisite outputs exist.
5. **Maintain artifact flow:** Each module should produce inputs for the next.
6. **Adjust depth:** Swap CC-05 or CC-07 in/out depending on role needs.
7. **Add support modules:** Use SP-01 for troubleshooting, OP-01 for advanced
   integrations.
8. **Wrap up:** End with WR-01 to capture decisions and next steps.
