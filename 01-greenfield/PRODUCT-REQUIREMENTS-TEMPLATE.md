# Product Requirements Template

Use this template to define WHAT needs to be built and WHY, from a product perspective.

---

# Feature: [Feature Name]

## Product Vision

**What:** [1-2 sentence description of what this feature does]

**Why:** [The problem it solves or value it provides]

**Who:** [Target users who will benefit from this feature]

**Success Criteria:** [How we'll measure if this feature succeeds]

**Example:**
> **What:** A command-line card guessing game where players predict higher or lower  
> **Why:** Fun, quick game that demonstrates C# programming concepts  
> **Who:** Developers learning C#, casual gamers, workshop participants  
> **Success Criteria:** Players can complete a full game in under 3 minutes with clear scoring feedback

---

## User Stories

Describe the feature from the user's perspective:

**As a** [type of user]  
**I want** [goal/desire]  
**So that** [benefit/value]

**Example:**
> **As a** player  
> **I want** to see the current card clearly displayed  
> **So that** I can make an informed guess about the next card

> **As a** player  
> **I want** to see my score update after each guess  
> **So that** I can track my progress and stay motivated

> **As a** player  
> **I want** to see my final statistics when the game ends  
> **So that** I can measure my performance and try to improve

---

## Functional Requirements

List concrete, testable requirements organized by capability:

### Core Capabilities

#### Game Setup
- [ ] **REQ-001:** Game uses a standard 52-card deck (4 suits × 13 values)
- [ ] **REQ-002:** Deck is shuffled randomly at the start of each game
- [ ] **REQ-003:** First card is drawn and displayed to start the game

#### Gameplay
- [ ] **REQ-004:** Player sees current card with value and suit symbol
- [ ] **REQ-005:** Player can guess "higher" (h/H) or "lower" (l/L)
- [ ] **REQ-006:** Player can quit anytime (q/Q)
- [ ] **REQ-007:** Next card is revealed after each guess
- [ ] **REQ-008:** Game indicates if guess was correct, incorrect, or tie
- [ ] **REQ-009:** Game continues until deck is exhausted (51 guesses)

#### Scoring
- [ ] **REQ-010:** Correct guess awards base points (10)
- [ ] **REQ-011:** Speed bonus awards up to 5 additional points
- [ ] **REQ-012:** Streak multiplier increases score for consecutive correct guesses
- [ ] **REQ-013:** Ties award zero points but don't break streak
- [ ] **REQ-014:** Running score displayed during gameplay

#### End Game
- [ ] **REQ-015:** Game over screen shows when deck is exhausted
- [ ] **REQ-016:** Final statistics displayed (accuracy, longest streak, average time)
- [ ] **REQ-017:** Player can choose to play again or exit

---

## Acceptance Criteria

Use **Given-When-Then** format for testable scenarios:

### AC1: Card Display
- **Given** the game is running
- **When** a card is displayed
- **Then** I see the value (A, 2-10, J, Q, K) and suit symbol (♠ ♥ ♦ ♣)
- **And** the card is rendered in an ASCII art box

### AC2: Valid Higher Guess
- **Given** the current card is 7♠
- **When** I press 'h' for higher
- **And** the next card is J♥ (value 11)
- **Then** I see "Correct!" with the revealed card
- **And** my score increases by base + speed bonus × streak multiplier
- **And** my streak increases by 1

### AC3: Valid Lower Guess
- **Given** the current card is Q♦ (value 12)
- **When** I press 'l' for lower
- **And** the next card is 5♣ (value 5)
- **Then** I see "Correct!" with the revealed card
- **And** my score increases appropriately

### AC4: Incorrect Guess
- **Given** the current card is 7♠
- **When** I press 'h' for higher
- **And** the next card is 3♦ (value 3)
- **Then** I see "Wrong!" with the revealed card
- **And** my score does not increase
- **And** my streak resets to 0

### AC5: Tie Handling
- **Given** the current card is 7♠
- **When** the next card is 7♦ (same value)
- **Then** I see "Tie! Same value."
- **And** I receive 0 points
- **And** my streak is NOT reset

### AC6: Game End
- **Given** I've made 51 guesses (deck exhausted)
- **When** the last card is revealed
- **Then** I see the Game Over screen
- **And** my final statistics are displayed

### AC7: Quit Mid-Game
- **Given** I'm in the middle of a game
- **When** I press 'q' to quit
- **Then** I see my current statistics
- **And** the game ends

---

## Detailed Functional Behavior

### Card Values

| Card | Value |
|------|-------|
| Ace (A) | 1 |
| 2-10 | Face value |
| Jack (J) | 11 |
| Queen (Q) | 12 |
| King (K) | 13 |

**Note:** Aces are always low (value 1). There is no "ace high" option.

### Suit Symbols

| Suit | Symbol |
|------|--------|
| Spades | ♠ |
| Hearts | ♥ |
| Diamonds | ♦ |
| Clubs | ♣ |

---

### Scoring Formula

```
base_points = 10 (for correct guess)
speed_bonus = max(0, 5 - floor(elapsed_seconds - 3))
streak_multiplier = 1.0 + (current_streak × 0.5)

total_points = floor((base_points + speed_bonus) × streak_multiplier)
```

**Scoring Examples:**

| Scenario | Elapsed Time | Streak | Calculation | Points |
|----------|--------------|--------|-------------|--------|
| Correct, fast | 2.0 sec | 0 | (10 + 5) × 1.0 | 15 |
| Correct, slow | 5.0 sec | 0 | (10 + 0) × 1.0 | 10 |
| Correct, fast, streak 3 | 2.0 sec | 3 | (10 + 5) × 2.5 | 37 |
| Correct, slow, streak 5 | 6.0 sec | 5 | (10 + 0) × 3.5 | 35 |
| Incorrect | any | any | 0 | 0 |
| Tie | any | any | 0 (streak preserved) | 0 |

---

### Display Formats

#### Game Start Screen
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

#### Gameplay Screen
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

#### Correct Guess
```
  ┌─────────┐      ┌─────────┐
  │ 7       │  →   │ J       │
  │         │      │         │
  │    ♠    │      │    ♥    │
  │       7 │      │       J │
  └─────────┘      └─────────┘

✓ Correct! Jack of Hearts (11) is HIGHER than 7 of Spades (7)
  +10 base  +4 speed bonus  ×2.0 streak = 28 points!

Press any key to continue...
```

#### Incorrect Guess
```
  ┌─────────┐      ┌─────────┐
  │ 7       │  →   │ 3       │
  │         │      │         │
  │    ♠    │      │    ♦    │
  │       7 │      │       3 │
  └─────────┘      └─────────┘

✗ Wrong! 3 of Diamonds (3) is LOWER than 7 of Spades (7)
  Streak reset!

Press any key to continue...
```

#### Tie
```
  ┌─────────┐      ┌─────────┐
  │ 7       │  →   │ 7       │
  │         │      │         │
  │    ♠    │      │    ♦    │
  │       7 │      │       7 │
  └─────────┘      └─────────┘

≈ Tie! Both cards are 7. No points, but streak continues!

Press any key to continue...
```

#### Game Over Screen
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

---

## Usage Examples

### Example 1: Happy Path - Complete Game
```
[Game starts, player presses ENTER]

Cards remaining: 51    Score: 0    Streak: 0

  ┌─────────┐
  │ 5       │
  │    ♣    │
  │       5 │
  └─────────┘

[H]igher or [L]ower? (Q to quit): h

✓ Correct! 9 of Diamonds is HIGHER than 5 of Clubs
  +10 base  +5 speed bonus  ×1.0 streak = 15 points!

[... 50 more guesses ...]

╔════════════════════════════════════════╗
║            GAME OVER!                  ║
╠════════════════════════════════════════╣
║  Final Score: 523                      ║
║  Correct guesses: 35/51 (68.6%)        ║
╚════════════════════════════════════════╝

Play again? (Y/N): n

Thanks for playing!
```

### Example 2: Early Quit
```
Cards remaining: 30    Score: 200    Streak: 5 🔥

  ┌─────────┐
  │ K       │
  │    ♠    │
  │       K │
  └─────────┘

[H]igher or [L]ower? (Q to quit): q

╔════════════════════════════════════════╗
║           GAME ENDED EARLY             ║
╠════════════════════════════════════════╣
║  Final Score: 200                      ║
║  Guesses made: 21/51                   ║
╚════════════════════════════════════════╝
```

### Example 3: Invalid Input
```
[H]igher or [L]ower? (Q to quit): x

Invalid input. Please press H, L, or Q.

[H]igher or [L]ower? (Q to quit): _
```

---

## Edge Cases & Error Scenarios

### Input Validation
1. **Invalid key pressed:**
   - Behavior: Display error message, re-prompt
   - Do NOT count as a guess

2. **Very fast response (< 0.1 seconds):**
   - Behavior: Accept normally, award maximum speed bonus
   - No penalty for being fast

3. **Very slow response (> 30 seconds):**
   - Behavior: Accept normally, no speed bonus
   - No timeout enforcement

### Game State
4. **Last card in deck:**
   - Behavior: After 51st guess, show game over immediately
   - No "continue" prompt on last card

5. **All cards same value (theoretically impossible):**
   - Behavior: Would be all ties, score 0
   - Not a realistic scenario with shuffled deck

6. **Player achieves perfect game (51/51 correct):**
   - Behavior: Display special congratulations message
   - "Perfect Game! You're a card shark! 🦈"

### Terminal Compatibility
7. **Terminal doesn't support Unicode:**
   - Behavior: Fall back to ASCII (S, H, D, C instead of ♠♥♦♣)
   - Box characters: use +, -, | instead of box-drawing

8. **Terminal window too small:**
   - Behavior: Display simplified format
   - Minimum requirement: 40 columns

---

## Non-Functional Requirements

### Performance
- **Response time:** Game responds to input in < 50ms
- **Startup time:** < 100ms to display first card
- **Memory usage:** < 10MB (52 cards in memory)

### Reliability
- **No crashes:** Invalid input should never crash the game
- **State consistency:** Score and streak always accurate
- **Clean exit:** Ctrl+C shows final score before exiting

### Usability
- **Clear feedback:** Every action has visible feedback
- **Simple controls:** Only 3 keys needed (H, L, Q)
- **Readable display:** Cards clearly visible with contrast

### Compatibility
- **Operating Systems:** Windows 10+, macOS 12+, Ubuntu 20.04+
- **.NET Runtime:** .NET 8.0 or later
- **Terminal:** Any Unicode-supporting terminal

---

## Technical Constraints

### Must Have
- Must work on Windows, macOS, and Linux
- Must be compatible with .NET 8.0 or later
- Must handle Unicode suit symbols correctly
- Must NOT require administrator/root privileges

### Must NOT
- Must NOT require internet connectivity
- Must NOT persist game state between sessions (fresh game each time)
- Must NOT require additional runtime dependencies beyond .NET

---

## Out of Scope (v1.0)

Explicitly NOT included in this version:

❌ **High score persistence** - Consider for v2.0  
❌ **Multiple difficulty levels** - Consider for v2.0  
❌ **Joker cards** - Not planned  
❌ **Multi-player mode** - Not planned  
❌ **Card counting hints** - Consider for v2.0  
❌ **Betting/gambling mechanics** - Not appropriate  
❌ **Network play** - Not planned  
❌ **Graphical interface** - CLI only for this version  

**Rationale:** Focus on core gameplay loop before adding complexity.

---

## Success Metrics

### User Experience Metrics
- Players can start a new game in < 5 seconds
- 95% of games complete without errors
- Average game duration: 2-3 minutes

### Technical Metrics
- 100% of critical requirements implemented
- 80%+ test coverage
- < 50ms response time per guess

---

## Related Documents

- **Implementation Plan:** `IMPLEMENTATION-PLAN.md` (technical design and approach)
- **AGENTS.md:** Project coding conventions and standards
- **README.md:** User-facing documentation and getting started guide

---

## Guidelines for Using This Template

1. **Be specific:** Vague requirements ("fun game") lead to incorrect implementations
2. **Include examples:** Show concrete inputs and outputs
3. **Cover edge cases:** Think about what can go wrong
4. **Make it testable:** Every requirement should be verifiable
5. **Separate WHAT from HOW:** This doc defines product needs, not technical design

**This is a PRODUCT document:**
- Describes user needs and expected behavior
- Defines acceptance criteria
- Does NOT prescribe technical implementation details

**Technical implementation details belong in the IMPLEMENTATION-PLAN.md document.**
