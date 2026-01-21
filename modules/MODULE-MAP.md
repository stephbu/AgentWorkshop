# Module Map (Draft)

Mapping of existing materials into composable 15-minute modules, with
dependencies and noted gaps. This map references current files and will be
refined as modules are authored under `modules/`.

## Prerequisites and Setup

| Module ID | Title | Source Materials | Prerequisites | Outputs | Gaps/Notes |
| --- | --- | --- | --- | --- | --- |
| PR-01 | Install VS Code | `00-prerequisites/SETUP.md` | None | VS Code installed | None |
| PR-02 | Clone Repo + Workspace Setup | `00-prerequisites/SETUP.md` | PR-01 | Local repo cloned | None |
| PR-03 | Install .NET SDK | `00-prerequisites/SETUP.md` | PR-01 | .NET SDK installed | None |
| PR-04 | Install Copilot Extensions | `00-prerequisites/SETUP.md` | PR-01 | Copilot + Chat installed | None |
| PR-05 | EMU Setup + Copilot Auth | `00-prerequisites/SETUP.md` | PR-04 | Copilot authenticated | None |
| PR-06 | Enable Agent Mode + Verify | `00-prerequisites/SETUP.md` | PR-05 | Agent mode verified | None |
| SP-01 | Troubleshooting Quick Fixes | `00-prerequisites/TROUBLESHOOTING.md` | PR-01 | Troubleshooting playbook | None |
| OP-01 | MCP Setup (Optional) | `00-prerequisites/SETUP.md` | PR-06 | MCP configured | Optional/advanced |

## Core Concepts

| Module ID | Title | Source Materials | Prerequisites | Outputs | Gaps/Notes |
| --- | --- | --- | --- | --- | --- |
| CC-01 | Requirements-First Mindset | `README.md`, `COURSE-OUTLINE.md`, `resources/BEST-PRACTICES.md`, `SLIDES.md` | PR-06 | Shared vocabulary + workflow | Split from prompts |
| CC-02 | Repo-Centric Development Process | `resources/BEST-PRACTICES.md`, `SLIDES.md` | CC-01 | Repo-first workflow summary | Need explicit module text |
| CC-02A | What Is a Repo? | `README.md` | PR-02 | Shared understanding of repo basics | Need explicit module text |
| CC-02B | VS Code Orientation | `00-prerequisites/SETUP.md`, `SLIDES.md` | PR-01 | Workspace navigation basics | Need explicit module text |
| CC-03 | AGENTS.md Purpose + Structure | `resources/BEST-PRACTICES.md`, `resources/CHEATSHEET.md`, `SLIDES.md` | CC-01 | Draft AGENTS.md outline | Template references |
| CC-04 | Product Requirements Basics | `resources/BEST-PRACTICES.md`, `resources/CHEATSHEET.md`, `SLIDES.md` | CC-01 | Requirements outline | None |
| CC-05 | Implementation Plan Basics | `resources/BEST-PRACTICES.md`, `resources/CHEATSHEET.md`, `SLIDES.md` | CC-04 | Plan outline | None |
| CC-06 | Prompting Patterns + Pitfalls | `resources/BEST-PRACTICES.md`, `resources/CHEATSHEET.md`, `SLIDES.md` | CC-01 | Prompt checklist | None |
| CC-07 | Testing Practices (Fast vs Slow) | `resources/BEST-PRACTICES.md` | CC-01 | Test classification guide | Needs explicit Fast/Slow section in module |

## Greenfield Workflow

| Module ID | Title | Source Materials | Prerequisites | Outputs | Gaps/Notes |
| --- | --- | --- | --- | --- | --- |
| GF-01 | Project Brief + Goal Setup | `01-greenfield/INSTRUCTIONS.md` | CC-01 | Project brief agreed | Needs module extraction |
| GF-02 | Create AGENTS.md | `01-greenfield/INSTRUCTIONS.md` | CC-03 | `AGENTS.md` | Uses template |
| GF-03 | Write Product Requirements | `01-greenfield/INSTRUCTIONS.md` | GF-02, CC-04 | `PRODUCT-REQUIREMENTS.md` | None |
| GF-04 | Create Implementation Plan | `01-greenfield/INSTRUCTIONS.md` | GF-03, CC-05 | `IMPLEMENTATION-PLAN.md` | None |
| GF-05 | Generate Implementation | `01-greenfield/INSTRUCTIONS.md` | GF-04 | Working code + tests | None |
| GF-06 | Build/Test + Iterate on Requirements | `01-greenfield/INSTRUCTIONS.md` | GF-05 | Updated requirements + fixes | None |
| GF-07 | Reflect + Bonus Challenges | `01-greenfield/INSTRUCTIONS.md` | GF-06 | Retrospective notes | Optional |

## Brownfield Workflow

| Module ID | Title | Source Materials | Prerequisites | Outputs | Gaps/Notes |
| --- | --- | --- | --- | --- | --- |
| BF-01 | Explore Codebase + Conventions | `02-brownfield/INSTRUCTIONS.md` | CC-01 | Codebase notes | None |
| BF-02 | Run Existing App | `02-brownfield/INSTRUCTIONS.md` | BF-01 | Baseline behavior observed | None |
| BF-03 | Create AGENTS.md for Existing Project | `02-brownfield/INSTRUCTIONS.md` | BF-01, CC-03 | `AGENTS.md` | None |
| BF-04 | Baseline Product Requirements | `02-brownfield/INSTRUCTIONS.md` | BF-03, CC-04 | Existing requirements doc | None |
| BF-05 | Add Baseline Unit Tests | `02-brownfield/INSTRUCTIONS.md` | BF-04, CC-07 | Test suite baseline | None |
| BF-06 | Write Feature Requirements | `02-brownfield/INSTRUCTIONS.md` | BF-04, CC-04 | Feature requirements | None |
| BF-07 | Create Implementation Plan | `02-brownfield/INSTRUCTIONS.md` | BF-06, CC-05 | Implementation plan | None |
| BF-08 | Implement Feature with Tests | `02-brownfield/INSTRUCTIONS.md` | BF-07 | Feature code + tests | None |
| BF-09 | Build/Test + Regression | `02-brownfield/INSTRUCTIONS.md` | BF-08 | Verified build + tests | None |
| BF-10 | Reflect + Bonus Exercise | `02-brownfield/INSTRUCTIONS.md` | BF-09 | Retrospective notes | Optional |

## Wrap-Up and References

| Module ID | Title | Source Materials | Prerequisites | Outputs | Gaps/Notes |
| --- | --- | --- | --- | --- | --- |
| WR-01 | Best Practices Recap + Next Steps | `README.md`, `COURSE-OUTLINE.md`, `resources/BEST-PRACTICES.md`, `resources/CHEATSHEET.md`, `SLIDES.md` | CC-01 | Action plan | None |

## Template Gaps to Resolve

- CC-02: Repo-centric process needs an explicit module draft extracted from existing guidance.
- CC-02A: Repo basics module needed (define repo, branches, files, readme, docs).
- CC-02B: VS Code orientation module needed (panels, explorer, open folder, terminal).
- CC-07: Fast vs Slow test classification should be pulled into a dedicated module section.
- Convert each workflow step into a module `README.md` under `modules/` using `resources/templates/MODULE-TEMPLATE.md`.
