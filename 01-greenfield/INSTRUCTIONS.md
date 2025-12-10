# Greenfield Lab: Build from Scratch

**Duration:** ~60 minutes  
**Goal:** Learn spec-first development by building a new C# project from the ground up.

---

## Overview

In this lab, you will:
1. Create an `AGENTS.md` file to establish project conventions
2. Write Product Requirements and Implementation Plan for a CLI application
3. Use AI agents to implement the application from your requirements
4. Iterate by refining requirements (not code) when issues arise

---

## The Project: HighLow Card Game CLI

You'll build a command-line card guessing game with these features:
- Play through a standard 52-card deck
- Guess if the next card is higher or lower than the current card
- Score based on accuracy, speed, and streak multipliers
- Ties (same value) score zero points
- Game ends when the deck is exhausted
- Display final score with statistics

---

## Part 1: Create AGENTS.md (10 minutes)

**Why start here?** `AGENTS.md` sets the foundation—it tells AI agents how to work in your project.

### Step 1.1: Create the file

In your workspace, create: `/01-greenfield/HighLow/AGENTS.md`

### Step 1.2: Define your project

Use the [AGENTS-TEMPLATE.md](./AGENTS-TEMPLATE.md) as a starting point, or write from scratch.

**Key sections to include:**

**💡 Pro Tip: Ask the agent to help you!**

**Start with a question:**
```
I'm building a C# CLI card game called HighLow using .NET 8.0.
The game uses a standard 52-card deck. Players guess if the next 
card is higher or lower. Help me create an AGENTS.md file. 
What sections should I include and what conventions should I document?
```

Then customize the agent's suggestions. Here's what to include:

```markdown
# AGENTS.md

## Project Overview
A command-line high/low card guessing game built in C#. Players see a card 
and guess whether the next card will be higher or lower in value.

## Tech Stack
- Language: C# 12
- Framework: .NET 8.0
- Testing: xUnit
- No external dependencies required

## Project Structure
/HighLow
  /src
    /HighLow
      /Models        - Card, Deck, GameState, Score
      /Services      - GameService, ScoringService
      /Display       - ConsoleRenderer for card display
      Program.cs
  /tests
    /HighLow.Tests   - Unit tests
  AGENTS.md
  README.md

## Coding Conventions

> Follow [.NET C# Coding Conventions](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)

- Use C# 12 features (primary constructors, file-scoped namespaces)
- Immutable models where possible (records for Card)
- Dependency injection where appropriate
- XML documentation comments on public APIs
- One class per file
- Namespace: HighLow.[folder]

## Naming Conventions
- PascalCase for classes, methods, properties
- camelCase for parameters, local variables
- Prefix interfaces with 'I': IGameService
- Suffix async methods with 'Async': SaveScoreAsync

## Card Representation
- Use Unicode suit symbols: ♠ ♥ ♦ ♣
- Card values: A=1, 2-10, J=11, Q=12, K=13
- Aces are always low (value 1)

## Scoring System
- Base points per correct guess: 10
- Time bonus: max 5 points, decreases 1 point per second after 3 seconds
- Streak multiplier: 1x base, +0.5x for each consecutive correct guess
- Ties (same value): 0 points, streak continues

## Testing Standards
- Test class name: [ClassUnderTest]Tests
- Test method name: [Method]_[Scenario]_[ExpectedResult]
- Use Arrange-Act-Assert pattern
- Mock random card shuffling for deterministic tests

## Instructions for Agents
1. Always create tests alongside implementation
2. Follow existing patterns in the codebase
3. Use dependency injection for services
4. Keep Program.cs thin—game logic goes in services
5. Display cards using Unicode symbols
6. Handle Ctrl+C gracefully (show final score)

## Example Code Style

```csharp
namespace HighLow.Models;

/// <summary>
/// Represents a playing card.
/// </summary>
public record Card(Suit Suit, int Value)
{
    public string Display => $"{ValueSymbol}{SuitSymbol}";
    
    private string ValueSymbol => Value switch
    {
        1 => "A", 11 => "J", 12 => "Q", 13 => "K",
        _ => Value.ToString()
    };
    
    private char SuitSymbol => Suit switch
    {
        Suit.Spades => '♠',
        Suit.Hearts => '♥',
        Suit.Diamonds => '♦',
        Suit.Clubs => '♣',
        _ => '?'
    };
}
```
```

### Step 1.3: Review and refine

Read through your `AGENTS.md`:
- Is it clear?
- Would a new developer understand your conventions?
- Are there ambiguities an agent might misinterpret?

**Tip:** Ask the agent, "Review my AGENTS.md for clarity and completeness."

---

## Part 2: Write Product Requirements and Implementation Plan (10 minutes)

Now write requirements and a plan for what the application should do.

### Step 2.1: Create requirements document

Create: `/01-greenfield/HighLow/requirements/HIGHLOW-REQUIREMENTS.md`

### Step 2.2: Write the requirements

Use the [PRODUCT-REQUIREMENTS-TEMPLATE.md](./PRODUCT-REQUIREMENTS-TEMPLATE.md) and [IMPLEMENTATION-PLAN-TEMPLATE.md](./IMPLEMENTATION-PLAN-TEMPLATE.md) or create your own.

**Example requirements document:**

```markdown
# Feature: HighLow Card Game

## Overview
A command-line card guessing game where players predict whether the next
card will be higher or lower than the current card. Players earn points
based on accuracy, speed, and building streaks.

## Requirements
- [ ] Display current card using Unicode suit symbols (♠ ♥ ♦ ♣)
- [ ] Accept player input: 'h' for higher, 'l' for lower, 'q' to quit
- [ ] Reveal next card and show if guess was correct
- [ ] Calculate score with time, accuracy, and streak factors
- [ ] Ties (same value) award zero points but don't break streak
- [ ] Continue until deck is exhausted (51 guesses from 52 cards)
- [ ] Display final score with statistics

## Game Flow

### Start
**Display:**
```
╔════════════════════════════════════════╗
║         HIGH/LOW CARD GAME             ║
╠════════════════════════════════════════╣
║  Guess if the next card is higher      ║
║  or lower than the current card.       ║
║                                        ║
║  Scoring:                              ║
║  • Correct guess: 10 points            ║
║  • Speed bonus: up to 5 points         ║
║  • Streak multiplier: +50% per streak  ║
║  • Tie (same value): 0 points          ║
╚════════════════════════════════════════╝

Press ENTER to start...
```

### Gameplay
**Display:**
```
Cards remaining: 45    Score: 125    Streak: 3 🔥

  ┌─────────┐
  │ 7       │
  │         │
  │    ♠    │
  │         │
  │       7 │
  └─────────┘

[H]igher or [L]ower? (Q to quit): _
```

### Result
**Display (correct):**
```
  ┌─────────┐      ┌─────────┐
  │ 7       │  →   │ J       │
  │         │      │         │
  │    ♠    │      │    ♥    │
  │         │      │       J │
  │       7 │      └─────────┘
  └─────────┘

✓ Correct! Jack of Hearts (11) is HIGHER than 7 of Spades (7)
  +10 base  +4 speed bonus  x2.0 streak = 28 points!
```

### Game Over
**Display:**
```
╔════════════════════════════════════════╗
║            GAME OVER!                  ║
╠════════════════════════════════════════╣
║  Final Score: 847                      ║
║                                        ║
║  Statistics:                           ║
║  • Correct guesses: 38/51 (74.5%)      ║
║  • Longest streak: 12                  ║
║  • Average response: 2.3 seconds       ║
║  • Ties: 3                             ║
╚════════════════════════════════════════╝

Play again? (Y/N): _
```

## Acceptance Criteria

### AC1: Card Display
- Given the game is running
- When a card is displayed
- Then it shows the value and Unicode suit symbol
- And the card is rendered in ASCII art box

### AC2: Valid Input
- Given a card is displayed
- When I press 'h' or 'H'
- Then my guess is recorded as "higher"
- And the next card is revealed

### AC3: Correct Guess Scoring
- Given the current card is 7♠
- When I guess "higher"
- And the next card is J♥ (value 11)
- Then I receive base points + speed bonus
- And my streak increases by 1

### AC4: Tie Handling
- Given the current card is 7♠
- When the next card is 7♦ (same value)
- Then I receive 0 points
- And my streak is NOT reset
- And I see "Tie! Same value."

### AC5: Game End
- Given I've made 51 guesses (deck exhausted)
- When the last card is revealed
- Then I see the Game Over screen
- And my final statistics are displayed

## Non-Functional Requirements
- Game should respond instantly to input (< 50ms)
- Card display should work in any terminal supporting Unicode
- Game state should not persist between sessions (fresh game each time)

## Out of Scope (for this iteration)
- High score persistence
- Multiple difficulty levels
- Joker cards
- Multi-player mode
- Card counting hints

## Implementation Plan
1. Create Models folder with Card, Deck, Suit, GameState classes
2. Create Services folder with GameService (game loop) and ScoringService
3. Create Display folder with ConsoleRenderer for ASCII card art
4. Implement main game loop in Program.cs
5. Add unit tests for scoring logic and deck shuffling
6. Add error handling for invalid input
```

### Step 2.3: Review your requirements

Ask yourself:
- Can I test these requirements?
- Are the behaviors unambiguous?
- Have I included examples?
- Is the implementation plan clear?
- What edge cases might break this?

---

## Part 3: Generate Implementation (20 minutes)

Now let the AI agent build your application!

### Step 3.1: Initial scaffold

**Prompt to agent:**
```
Create a new C# console application following the structure defined in AGENTS.md.
Set up the project with:
- .NET 8.0 console app
- xUnit testing project
- Folder structure as specified (Models, Services, Display)

Don't implement features yet—just create the skeleton.
```

**Expected output:**
- `.csproj` files
- Folder structure
- Empty classes/interfaces

### Step 3.2: Implement the feature

**Prompt to agent:**
```
Implement the HighLow card game according to requirements/HIGHLOW-REQUIREMENTS.md.
Follow all conventions in AGENTS.md.
Include unit tests for:
- Card comparison logic
- Scoring calculations (base, speed, streak)
- Deck shuffling (use seeded random for tests)

Start with the core game loop, then add the fancy display.
```

**Watch for:**
- Does the agent follow your AGENTS.md conventions?
- Are card symbols displaying correctly?
- Is the scoring formula implemented correctly?

### Step 3.3: Build and test

Run the project:
```bash
cd HighLow/src/HighLow
dotnet build
dotnet run
```

Play a few rounds to verify:
- Cards display with Unicode symbols
- Higher/Lower logic works correctly
- Scoring appears reasonable
- Game ends after 51 guesses

Run tests:
```bash
cd HighLow/tests/HighLow.Tests
dotnet test
```

---

## Part 4: Iterate on Requirements (15 minutes)

Issues will arise. Practice fixing them by **updating requirements**, not editing code.

### Common scenarios:

#### Scenario A: Card display doesn't look right

**DON'T:** Edit the ConsoleRenderer code directly

**DO:** Update the requirements with more precise display requirements:
```markdown
## Card Display Format

Display cards in a 9x11 character box:
```
┌─────────┐
│ A       │
│         │
│    ♠    │
│         │
│       A │
└─────────┘
```
- Value in top-left (left-aligned)
- Value in bottom-right (right-aligned)  
- Suit symbol centered
- Use box-drawing characters (─ │ ┌ ┐ └ ┘)
```

Then prompt agent: "Update the card display using the format in requirements."

#### Scenario B: Scoring feels wrong

**DON'T:** Tweak the scoring numbers in code

**DO:** Add precise scoring rules to requirements:
```markdown
## Scoring Formula

base_points = 10
speed_bonus = max(0, 5 - seconds_elapsed) where seconds_elapsed > 3
streak_multiplier = 1 + (streak_count * 0.5)

total_points = (base_points + speed_bonus) * streak_multiplier

Examples:
- Correct in 2 seconds, streak of 3: (10 + 5) * 2.5 = 37.5 → 38 points
- Correct in 5 seconds, streak of 0: (10 + 0) * 1.0 = 10 points
- Tie: 0 points regardless of streak
```

Prompt: "Update ScoringService to match the exact formula in requirements."

#### Scenario C: Edge case with Aces

**DON'T:** Add a special case in the comparison code

**DO:** Clarify in requirements:
```markdown
## Card Values

- Ace = 1 (always low)
- 2-10 = face value
- Jack = 11
- Queen = 12
- King = 13

Comparison is strictly by numeric value.
Ace (1) is lower than all other cards.
```

---

## Part 5: Reflect (5 minutes)

### Discussion Questions

1. **How much code did you write vs. the agent?**
   - Ideally, you wrote requirements and reviewed—agent wrote code

2. **When did you edit code directly vs. updating requirements?**
   - Small tweaks: maybe edited directly
   - Patterns/conventions: should update AGENTS.md

3. **How did AGENTS.md help?**
   - Did agent follow conventions consistently?
   - What would have been different without it?

4. **What would you change about your requirements?**
   - Too vague? Too prescriptive?
   - Was the implementation plan clear enough?
   - What edge cases did you miss?

5. **Was the game fun to build?**
   - Did the interactive nature make testing more engaging?

---

## Bonus Challenges

If you finish early:

### Challenge 1: Add a High Score System
Add persistent high scores using requirements-first approach:
1. Write requirements for saving/loading top 10 scores to JSON
2. Include player name input
3. Let agent implement
4. Verify against requirements

### Challenge 2: Add Card Counting Hints
- Update AGENTS.md with hint display conventions
- Write requirements showing remaining cards probabilities
- Implement via agent

### Challenge 3: Improve Visual Polish
- Write requirements for colored output (red hearts/diamonds)
- Add card flip animation (optional)
- Verify terminal compatibility

---

## Key Takeaways

✅ **AGENTS.md is your project DNA** - Set it up first  
✅ **Requirements should be testable** - If you can't test it, refine it  
✅ **Include an implementation plan** - Guide the agent on how to structure the solution  
✅ **Iterate on requirements, not code** - Fix the input when output is wrong  
✅ **Examples are powerful** - Show the exact output format you want  
✅ **Games are fun to test** - Interactive apps give immediate feedback  

---

## What's Next?

In the **Brownfield Lab**, you'll apply these techniques to an existing codebase where you didn't write the original code.

The challenge: Understanding and extending code you're unfamiliar with—using AGENTS.md as your guide.
