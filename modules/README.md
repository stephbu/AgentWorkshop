# Module System

This repository uses composable, 15-minute modules that can be assembled into
role-based courses. Each module is a standalone learning unit that produces a
clear output artifact or decision that feeds subsequent modules.

## Module Goals

- Keep modules short (~15 minutes each)
- Define explicit prerequisites and outputs
- Allow reordering and reuse across roles
- Track dependencies through outputs, not just topics

## Module Types

- **PR**: Prerequisites and setup
- **CC**: Core concepts and foundations
- **GF**: Greenfield workflow modules
- **BF**: Brownfield workflow modules
- **SP**: Support modules (troubleshooting, reference)
- **WR**: Wrap-up and next steps
- **OP**: Optional/advanced topics

## Module ID Format

Use this format so modules can be referenced in course outlines:

```
[TYPE]-[NN]
```

Examples: `PR-01`, `CC-03`, `GF-04`, `BF-02`, `SP-01`, `WR-01`, `OP-01`

## Module File Layout

Each module lives under `/modules` and uses a level-based folder name. Store
module resources as individual Markdown files:

```
modules/
  {level}-{name}/
    {resource}.md
```

Example: `modules/100-IntroductionToVSCode/slides.md`

## Required Module Metadata

Include this metadata at the top of the primary module overview resource
(e.g., `overview.md` or `README.md`):

| Field | Description |
| --- | --- |
| Module ID | Short identifier (e.g., `CC-01`) |
| Title | Module name |
| Duration | Target time (15 min) |
| Audience | Roles this module targets |
| Level | Intro, Intermediate, Advanced |
| Prerequisites | Prior module IDs |
| Inputs | Artifacts required from earlier modules |
| Outputs | Artifacts produced by this module |
| Materials | Repo files, slides, or tools used |
| Owner | Facilitator or maintainer |

## Outputs and Dependencies

Modules should list explicit outputs (e.g., `AGENTS.md`, requirements doc, or
tests added). This allows course designers to chain modules by outputs rather
than by topic alone.

## Template

Use the standard module template:

`resources/templates/MODULE-TEMPLATE.md`
