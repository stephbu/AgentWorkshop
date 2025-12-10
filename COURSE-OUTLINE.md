# Agent-Driven Software Development Workshop
## Half-Day Course Outline

**Duration:** 4 hours  
**Target Audience:** Software developers with C# experience  
**Prerequisites:** VS Code, GitHub Copilot, .NET 8.0 SDK installed

---

## Learning Objectives

By the end of this workshop, participants will be able to:

1. Set up and configure GitHub Copilot Agent Mode for optimal development
2. Create and maintain AGENTS.md files to guide AI-assisted development
3. Write effective Product Requirements documents
4. Create Implementation Plans that translate requirements into technical designs
5. Use requirements-first workflows for both greenfield and brownfield projects
6. Apply best practices for prompt engineering and AI collaboration
7. Troubleshoot common issues with agent-driven development
8. **(Optional)** Configure and use MCP servers for GitHub/Azure DevOps integration

---

## Course Schedule

### Module A: Prerequisites & Setup (30 minutes)
**9:00 - 9:30 AM**

#### Topics Covered:
- Workshop overview and learning objectives
- Verify installations (VS Code, .NET SDK, GitHub Copilot)
- GitHub Enterprise Managed Users (EMU) authentication
- **The AI Development Progression:**
  - Level 1: Single-shot prompts ("create a function")
  - Level 2: Multi-step iterations (refining results)
  - Level 3: Context-aware development (using AGENTS.md)
  - Level 4: Spec-first development (requirements → implementation)
- GitHub Copilot Agent Mode introduction
- Workspace setup

#### Activities:
- Environment verification (5 min)
- **Live Demo: The Progression** (10 min)
  - Demo 1: Single-shot prompt → basic result
  - Demo 2: Same task with context → better result
  - Demo 3: Same task with requirements → production-ready result
- Quick tour of GitHub Copilot features (5 min)
- Q&A and troubleshooting (10 min)

#### Success Criteria:
- ✅ All participants authenticated to GitHub EMU
- ✅ GitHub Copilot responding in Agent Mode
- ✅ .NET SDK verified (`dotnet --version`)
- ✅ Sample workspace opened in VS Code
- ✅ Understanding of why spec-first is more effective

---

### Module B: Greenfield Development (90 minutes)
**9:30 - 11:00 AM**

#### Part 1: Introduction to Requirements-First Development (20 min)
- What is requirements-first development?
- The role of AGENTS.md in guiding AI
- Separating Product Requirements from Implementation Plans
- Demo: Building a simple feature with agents

#### Part 2: Hands-On Lab - Build from Scratch (60 min)

**Lab Exercise: HighLow Card Game CLI Application**

Participants will build a complete C# CLI application using agents:

1. **Create AGENTS.md** (10 min)
   - Define project conventions
   - Specify C# 12/.NET 8.0 standards
   - Set coding patterns

2. **Write Product Requirements** (10 min)
   - Define the WHAT and WHY
   - User stories and acceptance criteria
   - Edge cases and validation rules

3. **Create Implementation Plan** (10 min)
   - Technical architecture
   - Component design
   - Testing strategy

4. **Generate Code with Agents** (20 min)
   - Implement models, services, repositories
   - Build CLI interface
   - Generate tests

5. **Iterate and Refine** (10 min)
   - Test the application
   - Fix issues with agent assistance
   - Add missing functionality

#### Part 3: Discussion & Best Practices (10 min)
- What worked well?
- Common pitfalls
- Tips for effective prompting
- Q&A

#### Deliverables:
- Working HighLow Card Game CLI application
- Complete AGENTS.md
- Product Requirements document
- Implementation Plan document

---

### Break (15 minutes)
**11:00 - 11:15 AM**

---

### Module C: Brownfield Development (90 minutes)
**11:15 AM - 12:45 PM**

#### Part 1: Working with Existing Codebases (15 min)
- Challenges of brownfield development
- Understanding existing patterns
- Creating AGENTS.md for legacy projects
- Demo: Exploring an existing C# project

#### Part 2: Hands-On Lab - Extend Existing Code (75 min)

**Lab Exercise: Extend the Book Library**

Participants will extend an existing C# CLI application:

1. **Explore the Codebase** (15 min)
   - Understand BookLibrary structure
   - Identify existing patterns
   - Run and test current functionality

2. **Create AGENTS.md** (15 min)
   - Document observed conventions
   - Note existing patterns (naming, structure, error handling)
   - Identify areas to preserve vs. improve

3. **Retroactively Document Product Requirements** (10 min)
   - Generate requirements for existing functionality
   - Ask clarifying questions to reveal edge cases
   - Establish baseline documentation

4. **Add Unit Tests for Existing Code** (10 min)
   - Generate tests for current functionality
   - Establish safety net before changes
   - Verify tests pass

5. **Write Feature Requirements** (10 min)
   - Choose a feature to add
   - Write requirements and implementation plan
   - Reference AGENTS.md and existing requirements

6. **Implement Feature with Tests** (12 min)
   - Generate feature code AND tests together
   - Follow existing patterns
   - Verify all tests pass

7. **Build and Test** (8 min)
   - Run all tests
   - Manual verification
   - Regression testing

#### Discussion & Reflection (5 min)
- Brownfield vs. greenfield experiences
- Value of documenting existing code first
- Value of tests as safety net

#### Deliverables:
- Extended BookLibrary with new feature
- AGENTS.md documenting project conventions
- Product Requirements (existing + new feature)
- Unit tests for existing and new functionality

---

### Module D: Wrap-Up & Next Steps (30 minutes)
**12:45 - 1:00 PM**

#### Topics Covered:
- Key takeaways and lessons learned
- Best practices cheat sheet review
- Common patterns and anti-patterns
- **(Optional Bonus)** MCP server integration for GitHub/ADO
  - Automatic work item updates
  - Requirements traceability
  - Workflow automation examples
- Resources for continued learning
- Q&A and open discussion

#### Activities:
- Group discussion: Biggest insights (10 min)
- Share success stories and challenges (5 min)
- **(Optional)** Quick demo: MCP server workflow (5 min)
  - Create GitHub issue from requirements
  - Update ADO task from code changes
  - Generate traceability report
- Facilitator tips and tricks (5 min)
- Next steps for applying in real projects (5 min)

#### Resources Provided:
- BEST-PRACTICES.md - Comprehensive guide (includes MCP section)
- CHEATSHEET.md - Quick reference (includes MCP commands)
- Templates for AGENTS.md, Product Requirements, Implementation Plans
- Sample projects (HighLow, BookLibrary)
- MCP server setup instructions (optional)

---

## Materials Required

### For Facilitator:
- [ ] Projector/screen for demos
- [ ] Workshop repository cloned locally
- [ ] Backup solutions for common issues
- [ ] Timer for keeping track of segments
- [ ] GitHub EMU admin access (for auth issues)

### For Participants:
- [ ] Laptop with admin rights
- [ ] VS Code installed
- [ ] .NET 8.0 SDK installed
- [ ] GitHub Copilot license (via EMU)
- [ ] Internet connection
- [ ] Workshop repository URL

### Provided Materials:
- Pre-configured workspace with templates
- Sample projects (greenfield starter, brownfield BookLibrary)
- Documentation (setup, troubleshooting, best practices)
- Templates (AGENTS.md, Product Requirements, Implementation Plan)

---

## Assessment & Evaluation

### Participant Success Indicators:

**Basic Competency (Required):**
- ✅ Created AGENTS.md for at least one project
- ✅ Wrote Product Requirements document
- ✅ Built or extended working C# application with agent assistance
- ✅ Successfully used GitHub Copilot Agent Mode

**Proficient (Good Understanding):**
- ✅ Created both greenfield and brownfield projects
- ✅ Wrote effective prompts that generated quality code
- ✅ Debugged and fixed issues with agent help
- ✅ Applied best practices from workshop materials

**Advanced (Mastery):**
- ✅ Optimized agent interactions for efficiency
- ✅ Created comprehensive Implementation Plans
- ✅ Helped other participants troubleshoot
- ✅ Generated test code alongside implementation

### Post-Workshop Survey (Optional):
1. Rate your confidence using GitHub Copilot Agent Mode (1-5)
2. Rate your understanding of requirements-first development (1-5)
3. What was most valuable about this workshop?
4. What would you change or improve?
5. Will you use these techniques in your work? Why or why not?

---

## Facilitator Notes

### Pacing Guidelines:
- **Move quickly through setup** - Most should have this done pre-workshop
- **Allow extra time for first lab** - Participants learning the workflow
- **Be flexible with breaks** - Adjust based on energy levels
- **Save 10 minutes at end** - Always have buffer for Q&A

### Common Challenges:

**Technical Issues:**
- Copilot not responding → Check authentication, restart VS Code
- .NET SDK issues → Use troubleshooting guide
- EMU authentication fails → Have backup instructions ready

**Conceptual Confusion:**
- "Why separate requirements and implementation?" → Emphasize WHAT vs HOW
- "When to use AGENTS.md?" → Every project, update as conventions emerge
- "Too much documentation?" → Show how it speeds up agent interactions
- "I don't know what to put in AGENTS.md" → Remind them: **Ask the agent for help!**

### Key Success Pattern to Emphasize:

**🎯 ASK QUESTIONS - Don't assume, inquire!**

Throughout the workshop, model this behavior:
- "What do you need to know to implement this?"
- "Help me create AGENTS.md - what sections should I include?"
- "What edge cases should I consider?"
- "Can you explain why you chose this approach?"

**Reinforce:** The agent is a consultant and pair programmer, not just a code generator.

### Backup Plans:
- If Wi-Fi fails: Have offline VS Code setup with cached responses
- If Copilot outage: Switch to manual coding with templates
- If participants fall behind: Provide checkpoint code snapshots

### Engagement Strategies:
- **Pair programming**: Partner struggling participants with advanced ones
- **Live demos**: Show your own workflow between labs (include asking questions!)
- **Share screen**: Let participants demo their solutions
- **Celebrate wins**: Highlight when agents generate great code
- **Encourage questions**: Both to you AND to the agent

---

## Pre-Workshop Checklist

### One Week Before:
- [ ] Send setup instructions to participants (SETUP.md)
- [ ] Verify all participants have GitHub EMU access
- [ ] Test workshop materials on fresh machine
- [ ] Prepare backup solutions for common issues
- [ ] Review latest GitHub Copilot features

### One Day Before:
- [ ] Clone workshop repository to presentation machine
- [ ] Test all sample projects build and run
- [ ] Verify internet connectivity at venue
- [ ] Print troubleshooting guide (backup)
- [ ] Prepare timer/agenda visible to participants

### Day Of:
- [ ] Arrive 30 minutes early
- [ ] Test projector and screen sharing
- [ ] Set up demo workspace
- [ ] Test GitHub Copilot connection
- [ ] Have TROUBLESHOOTING.md readily accessible

---

## Post-Workshop Follow-Up

### Immediate (Day Of):
- Share workshop repository link with all participants
- Provide contact info for follow-up questions
- Collect feedback surveys

### Within One Week:
- Send summary email with key resources
- Share any updated materials or fixes
- Offer optional office hours for questions

### Within One Month:
- Check in on adoption and usage
- Collect success stories
- Update workshop materials based on feedback

---

## Customization Options

### For Different Audiences:

**Senior Developers:**
- Add advanced topics: Architecture patterns, testing strategies
- Deeper dive into prompt engineering
- Discussion of AI limitations and best practices

**Team Leads:**
- Emphasize AGENTS.md as team documentation
- Add section on code review with AI assistance
- Discuss team adoption strategies

**Shorter Workshop (2 hours):**
- Skip brownfield module
- Reduce lab time to 30 minutes
- Provide pre-written requirements

**Full Day Workshop (6-8 hours):**
- Add testing module (TDD with agents)
- Add debugging/troubleshooting deep dive
- Include architecture patterns discussion
- Add competitive coding challenge

### For Different Languages:

This workshop is designed for C#, but can be adapted:

**Python:**
- Replace .NET SDK with Python 3.11+
- Use pytest instead of xUnit
- Adjust AGENTS.md template for Python conventions

**JavaScript/TypeScript:**
- Use Node.js and npm
- TypeScript project configuration
- Jest for testing

**Java:**
- Use Java 17+ and Maven/Gradle
- JUnit for testing
- Adjust conventions for Java patterns

---

## Success Metrics

### Workshop Goals:

**Attendance & Completion:**
- Target: 90%+ complete all modules
- Track: Completion of both lab exercises

**Knowledge Gain:**
- Pre/post survey on confidence levels
- Target: 30%+ increase in confidence scores

**Practical Application:**
- Track: # of participants using agents in real projects (1 month follow-up)
- Target: 60%+ adoption rate

**Satisfaction:**
- Target: 4.0+ out of 5.0 average rating
- Track: Would recommend to colleague (Yes/No)

---

## Version History

| Version | Date | Changes | Author |
|---------|------|---------|--------|
| 1.0 | 2025-12-07 | Initial course outline | Workshop Team |

---

## License & Usage

This workshop material is provided for educational purposes. Feel free to adapt and customize for your organization's needs.

**Attribution:** Please credit original authors when sharing or adapting materials.

**Contributions:** Suggestions and improvements welcome via pull request or email.
