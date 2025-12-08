# Agent Workshop: Requirements-First Development with AI

A half-day workshop teaching developers how to use AI agents effectively for software development using Product Requirements and Implementation Plans.

---

## Workshop Overview

**Duration:** 4 hours  
**Focus:** Requirements-first development with GitHub Copilot agent mode  
**Language:** C# / .NET 8.0  
**Prerequisites:** VS Code, GitHub Copilot, GitHub EMU access

---

## Workshop Structure

### Module A: Prerequisites & Setup (30 min)
- Environment verification
- VS Code + Copilot + GitHub EMU
- Quick agent mode demonstration

**Materials:** `/00-prerequisites/`

### Module B: Greenfield Development (1.5 hrs)
- The requirements-first mindset
- Creating `AGENTS.md` for project conventions
- Writing effective Product Requirements and Implementation Plans
- Building a CLI tool from scratch
- Iterating on requirements, not code

**Materials:** `/01-greenfield/`

### Module C: Brownfield Development (1.5 hrs)
- Understanding existing codebases
- Creating `AGENTS.md` for existing projects
- Requirements-driven feature additions
- Following existing patterns
- Regression testing

**Materials:** `/02-brownfield/`

### Wrap-up (30 min)
- Key takeaways
- Best practices review
- Q&A

**Materials:** `/resources/`

---

## Key Concepts

### AGENTS.md
A markdown file at the project root that provides:
- Project context and conventions
- Coding standards and patterns
- Architecture and structure
- Instructions for AI agents

**Why it matters:** Gives agents persistent context about how to work in your codebase.

### Requirements-First Development
The workflow:
1. Write clear Product Requirements and Implementation Plans BEFORE coding
2. Let agents generate implementation from requirements
3. When output is wrong, iterate on the REQUIREMENTS (not the code)
4. Verify against acceptance criteria

**Why it matters:** Ensures intent is clear and output matches expectations.

---

## Workshop Materials

```
/AgentWorkshop
  /00-prerequisites
    SETUP.md                          # Pre-workshop setup guide
    TROUBLESHOOTING.md                # Common issues and fixes
  
  /01-greenfield
    INSTRUCTIONS.md                   # Lab instructions
    AGENTS-TEMPLATE.md                # Template for new projects
    PRODUCT-REQUIREMENTS-TEMPLATE.md  # Product requirements template
    IMPLEMENTATION-PLAN-TEMPLATE.md   # Implementation plan template
  
  /02-brownfield
    INSTRUCTIONS.md                   # Lab instructions
    AGENTS-TEMPLATE-BROWNFIELD.md     # Template for existing projects
    /BookLibrary                      # Sample C# project to extend
      /Models
        Book.cs
      /Services
        BookService.cs
      Program.cs
      BookLibrary.csproj
      README.md
  
  /resources
    BEST-PRACTICES.md                 # Comprehensive best practices guide
    CHEATSHEET.md                     # Quick reference for common tasks
  
  README.md                           # This file
```

---

## For Participants

### Before the Workshop

1. **Complete setup:** Follow `/00-prerequisites/SETUP.md`
2. **Verify:** Run the setup verification script
3. **Troubleshoot:** See `/00-prerequisites/TROUBLESHOOTING.md` if issues

### During the Workshop

1. **Greenfield Lab:** Work through `/01-greenfield/INSTRUCTIONS.md`
   - Create a task manager CLI from scratch
   - Learn to write AGENTS.md and Product Requirements
   - Practice requirements-driven development

2. **Brownfield Lab:** Work through `/02-brownfield/INSTRUCTIONS.md`
   - Extend existing Book Library application
   - Create AGENTS.md for unfamiliar codebase
   - Add features following existing patterns

3. **Reference materials:** Use `/resources/` as needed
   - BEST-PRACTICES.md for detailed guidance
   - CHEATSHEET.md for quick lookups

### After the Workshop

- Apply techniques to your real projects
- Contribute improvements to workshop materials
- Share learnings with your team

---

## For Facilitators

### Pre-Workshop Prep

1. **Week before:**
   - Send SETUP.md to participants
   - Set up Slack/Teams channel for questions
   - Prepare demos

2. **Day before:**
   - Test all materials in fresh environment
   - Prepare brownfield project variations (if desired)
   - Review common troubleshooting issues

### During Workshop

#### Timing Guide

| Time | Activity | Notes |
|------|----------|-------|
| 0:00-0:10 | Welcome & agenda | Set expectations |
| 0:10-0:20 | Environment verification | Help stragglers |
| 0:20-0:30 | Quick demo | Show agent in action |
| 0:30-0:45 | Requirements-first mindset | Lecture/discussion |
| 0:45-1:30 | Greenfield lab | Circulate and help |
| 1:30-1:45 | Greenfield debrief | Discussion |
| 1:45-2:00 | **Break** | |
| 2:00-2:15 | Brownfield intro | Lecture |
| 2:15-3:00 | Brownfield lab | Circulate and help |
| 3:00-3:15 | **Break** | |
| 3:15-3:45 | Brownfield debrief | Discussion |
| 3:45-4:00 | Wrap-up & Q&A | Key takeaways |

#### Discussion Prompts

**After Greenfield Lab:**
- How much code did you write vs. the agent?
- When did you edit code directly vs. updating specs?
- What would you change about your spec?
- How did AGENTS.md help (or not)?

**After Brownfield Lab:**
- How was this different from greenfield?
- What context did the agent need?
- Did you discover patterns that weren't documented?
- Would you approach existing projects differently now?

#### Troubleshooting During Labs

Common issues:
- **Agent not following AGENTS.md:** Make AGENTS.md more explicit with examples
- **Can't build project:** Check .NET SDK version, missing using statements
- **Breaking existing features:** Emphasize regression testing
- **Stuck on specs:** Show examples, help them get specific

---

## For Organizers

### Setup Requirements

**Per Participant:**
- Laptop (Windows, macOS, or Linux)
- VS Code installed
- .NET 8.0 SDK installed
- GitHub Copilot license (via EMU)
- GitHub EMU account provisioned

**Venue:**
- WiFi with adequate bandwidth
- Power outlets for all participants
- Projector/screen for demos
- Whiteboard (helpful for discussions)

### GitHub EMU Setup

Work with your GitHub admin to:
1. Provision EMU accounts for all participants
2. Assign Copilot licenses
3. Test SSO flow before workshop
4. Have admin on standby during setup time

### Communication

**Before workshop:**
- Send SETUP.md 1 week in advance
- Reminder 2 days before
- "Day of" logistics (room, time, parking)

**During workshop:**
- Slack/Teams channel for questions
- Share screen for demos
- Recording (optional, with permission)

**After workshop:**
- Share recording link (if recorded)
- Collect feedback
- Share additional resources

---

## Learning Objectives

By the end of this workshop, participants will be able to:

1. **Set up and configure** GitHub Copilot Agent Mode for optimal development
2. **Create and maintain AGENTS.md** files to guide AI-assisted development
3. **Write effective Product Requirements** documents that produce quality code
4. **Create Implementation Plans** that translate requirements into technical designs
5. **Apply requirements-first workflows** in both greenfield and brownfield projects
6. **Use prompt engineering best practices** for effective AI collaboration
7. **Troubleshoot common issues** with agent-driven development
8. **(Optional)** Configure MCP servers for GitHub/Azure DevOps integration

---

## Customization

This workshop can be adapted:

### Different Language/Framework
- Replace C# examples with Python, TypeScript, Java, etc.
- Update AGENTS-TEMPLATE, PRODUCT-REQUIREMENTS-TEMPLATE, and IMPLEMENTATION-PLAN-TEMPLATE accordingly
- Adjust brownfield project to match

### Different Duration
- **2 hours:** Focus on one lab (greenfield OR brownfield)
- **Full day:** Add advanced topics (testing, refactoring, debugging)
- **Multi-day:** Deep dive into each topic with more exercises

### Different Focus
- **API development:** Change projects to REST APIs
- **Web apps:** Use web framework examples
- **Data science:** Focus on notebooks and analysis
- **DevOps:** Infrastructure as code examples

### Different Agent Tool
- **Cursor:** Similar patterns apply
- **Aider:** Command-line focused workflow
- **Custom agents:** Adapt for your tool

---

## Contributing

Improvements welcome! To contribute:

1. Fork this repository
2. Make your changes
3. Test with real participants if possible
4. Submit pull request with:
   - What you changed and why
   - Any new materials added
   - Feedback from testing (if applicable)

### Ideas for Contribution
- Additional lab exercises
- Alternative brownfield projects
- Language-specific variations
- Troubleshooting additions
- Best practice refinements

---

## License

[Specify license - MIT, Apache, proprietary, etc.]

---

## Contact

**Workshop Creator:** [Your name/contact]  
**Issues/Questions:** [GitHub issues, email, etc.]  
**Feedback:** [Survey link, email, etc.]

---

## Acknowledgments

Thanks to:
- GitHub Copilot team for agent mode
- Early workshop participants for feedback
- [Any other contributors]

---

## Version History

| Version | Date | Changes |
|---------|------|---------|
| 1.0 | 2025-12-07 | Initial release - C# version |

---

## Additional Resources

### Documentation
- [GitHub Copilot Documentation](https://docs.github.com/copilot)
- [.NET Documentation](https://learn.microsoft.com/dotnet/)
- [C# Language Reference](https://learn.microsoft.com/dotnet/csharp/)

### Related Reading
- Prompt engineering guides
- Test-driven development resources
- Architecture decision records (ADRs)
- Clean Code principles

### Tools
- [GitHub CLI](https://cli.github.com/)
- [.NET CLI](https://learn.microsoft.com/dotnet/core/tools/)
- [VS Code Extensions](https://marketplace.visualstudio.com/)

---

**Ready to get started?** Head to `/00-prerequisites/SETUP.md`!
