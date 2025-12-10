# AGENTS.md Template (Greenfield Project)

Use this template to create an `AGENTS.md` file for a new C# project.

---

# AGENTS.md

## Project Overview

**What:** [Brief description of what this application does]

**Why:** [The problem it solves or value it provides]

**Users:** [Who will use this]

---

## Tech Stack

- **Language:** C# 12
- **Framework:** .NET 8.0
- **Key Libraries:** [e.g., System.CommandLine, Entity Framework, etc.]
- **Testing:** xUnit
- **Data Storage:** [e.g., JSON files, SQLite, PostgreSQL, etc.]

---

## Project Structure

```
/ProjectName
  /src
    /ProjectName
      /Commands      - [Describe what goes here]
      /Models        - [Describe what goes here]
      /Services      - [Describe what goes here]
      /Infrastructure - [Describe what goes here]
      Program.cs
  /tests
    /ProjectName.Tests
      /[Mirror src structure]
  AGENTS.md
  README.md
  .gitignore
```

---

## Coding Conventions

### Language Features
- Use C# 12 features (primary constructors, file-scoped namespaces, etc.)
- Prefer `async`/`await` for I/O operations
- Use pattern matching where appropriate
- Leverage nullable reference types

### Code Organization
- One class per file
- File name matches class name
- Use file-scoped namespaces
- Order members: fields, properties, constructors, methods

### Dependency Injection
- Use constructor injection
- Register services in `Program.cs`
- Avoid service locator pattern

---

## Naming Conventions

- **Classes, Interfaces, Methods, Properties:** PascalCase
  - Interfaces: prefix with `I` (e.g., `IGameService`)
  - Async methods: suffix with `Async` (e.g., `SaveAsync`)

- **Parameters, Local Variables:** camelCase

- **Private Fields:** `_camelCase` with underscore prefix

- **Constants:** UPPER_SNAKE_CASE or PascalCase (be consistent)

---

## Namespace Conventions

```csharp
namespace ProjectName.FolderName;

// Example:
namespace HighLow.Services;
namespace HighLow.Models;
```

---

## Documentation Standards

### XML Documentation Comments
Required on:
- All public classes, interfaces, enums
- All public methods and properties
- Complex internal methods

**Example:**
```csharp
/// <summary>
/// Manages the game loop and player interactions.
/// </summary>
public class GameService
{
    /// <summary>
    /// Starts a new game with a shuffled deck.
    /// </summary>
    /// <param name="seed">Optional seed for reproducible shuffling.</param>
    /// <returns>The initial game state.</returns>
    public GameState StartNewGame(int? seed = null)
    {
        // ...
    }
}
```

---

## Error Handling Pattern

### Exceptions
- Use for truly exceptional situations (file not found, network error, etc.)
- Create custom exceptions when appropriate: `InvalidGuessException`
- Never swallow exceptions silently

### Result Pattern (Optional)
For expected failures (validation, not found), consider:
```csharp
public class Result<T>
{
    public bool IsSuccess { get; init; }
    public T? Value { get; init; }
    public string? Error { get; init; }
}
```

### Logging
- Log errors with context (what operation failed, relevant IDs)
- Use structured logging if applicable
- Don't log sensitive data (passwords, tokens, etc.)

---

## Testing Standards

### Test Organization
- One test class per production class
- Test class name: `[ClassUnderTest]Tests`
- Test file location: mirrors source structure in `/tests`

### Test Naming
```csharp
[Method]_[Scenario]_[ExpectedResult]

// Examples:
public void CompareCards_HigherCard_ReturnsPositive()
public void CalculateScore_WithStreak_AppliesMultiplier()
public void ShuffleDeck_WithSeed_ProducesDeterministicOrder()
```

### Test Structure (AAA Pattern)
```csharp
[Fact]
public void CalculateScore_WithStreak_AppliesMultiplier()
{
    // Arrange
    var scoringService = new ScoringService();
    var streak = 3;
    var elapsedSeconds = 2.0;

    // Act
    var result = scoringService.CalculateScore(
        isCorrect: true, 
        elapsedSeconds: elapsedSeconds, 
        currentStreak: streak);

    // Assert
    Assert.True(result > 10); // Base is 10, should be higher with streak
    Assert.Equal(38, result); // (10 + 5) * 2.5 = 37.5 → 38
}
```

### Mocking
- Mock external dependencies (file I/O, random number generation)
- Use a mocking framework (e.g., Moq, NSubstitute) if needed
- Don't mock the class under test
- Use seeded Random for deterministic shuffle tests

---

## Instructions for AI Agents

When working in this codebase:

1. **Always read AGENTS.md first** to understand conventions

2. **Follow the established patterns** in existing code

3. **Create tests alongside implementation** - never add features without tests

4. **Use dependency injection** for services to enable testing

5. **Keep entry points thin** - business logic belongs in services

6. **Handle edge cases explicitly** - document any assumptions

7. **Use meaningful variable names** - code should be self-documenting

8. **Validate inputs at boundaries** - services should validate their inputs

---

## Example: HighLow Card Game

Below is an example AGENTS.md for a HighLow card guessing game:

```markdown
# AGENTS.md

## Project Overview
A command-line high/low card guessing game. Players see a card and guess 
whether the next card will be higher or lower in value. Score based on 
accuracy, speed, and streak multipliers.

## Tech Stack
- Language: C# 12
- Framework: .NET 8.0
- Testing: xUnit
- No external dependencies required

## Project Structure
/HighLow
  /src
    /HighLow
      /Models        - Card, Deck, Suit, GameState, GameStatistics
      /Services      - GameService, ScoringService, DeckService
      /Display       - ConsoleRenderer for ASCII card art
      Program.cs
  /tests
    /HighLow.Tests
      /Models        - CardTests, DeckTests
      /Services      - ScoringServiceTests, GameServiceTests

## Game-Specific Conventions

### Card Representation
- Use Unicode suit symbols: ♠ ♥ ♦ ♣
- Card values: A=1, 2-10, J=11, Q=12, K=13
- Aces are always low (value 1)
- Use records for immutable card representation

### Scoring Rules
- Base points per correct guess: 10
- Speed bonus: max 5 points (decreases 1 point per second after 3 seconds)
- Streak multiplier: 1.0 + (streak_count × 0.5)
- Ties (same value): 0 points, streak continues

### Display Conventions
- Cards displayed in ASCII art boxes with box-drawing characters
- Use ✓ for correct, ✗ for incorrect
- Show running score, cards remaining, and current streak
- Fire emoji (🔥) for streaks of 3+

## Example Code

### Card Model
```csharp
namespace HighLow.Models;

public enum Suit { Spades, Hearts, Diamonds, Clubs }

public record Card(Suit Suit, int Value)
{
    public string Display => $"{ValueSymbol}{SuitSymbol}";
    
    public string ValueSymbol => Value switch
    {
        1 => "A", 11 => "J", 12 => "Q", 13 => "K",
        _ => Value.ToString()
    };
    
    public char SuitSymbol => Suit switch
    {
        Suit.Spades => '♠',
        Suit.Hearts => '♥',
        Suit.Diamonds => '♦',
        Suit.Clubs => '♣',
        _ => '?'
    };
}
```

### Scoring Service
```csharp
namespace HighLow.Services;

public class ScoringService
{
    private const int BasePoints = 10;
    private const int MaxSpeedBonus = 5;
    private const double StreakMultiplierIncrement = 0.5;
    
    public int CalculateScore(bool isCorrect, double elapsedSeconds, int currentStreak)
    {
        if (!isCorrect) return 0;
        
        var speedBonus = Math.Max(0, MaxSpeedBonus - (int)(elapsedSeconds - 3));
        var multiplier = 1.0 + (currentStreak * StreakMultiplierIncrement);
        
        return (int)Math.Round((BasePoints + speedBonus) * multiplier);
    }
}
```

## Testing Guidelines

### Deterministic Tests
Use seeded Random for shuffle tests:
```csharp
[Fact]
public void Shuffle_WithSameSeed_ProducesSameOrder()
{
    var deck1 = new DeckService(seed: 42);
    var deck2 = new DeckService(seed: 42);
    
    var cards1 = deck1.GetShuffledDeck();
    var cards2 = deck2.GetShuffledDeck();
    
    Assert.Equal(cards1, cards2);
}
```

### Scoring Test Examples
```csharp
[Theory]
[InlineData(true, 2.0, 0, 15)]   // Fast, no streak: 10 + 5 = 15
[InlineData(true, 5.0, 0, 10)]   // Slow, no streak: 10 + 0 = 10
[InlineData(true, 2.0, 3, 38)]   // Fast, streak 3: (10+5) * 2.5 = 37.5 → 38
[InlineData(false, 1.0, 5, 0)]   // Wrong guess: always 0
public void CalculateScore_VariousScenarios_ReturnsExpected(
    bool isCorrect, double seconds, int streak, int expected)
{
    var service = new ScoringService();
    var result = service.CalculateScore(isCorrect, seconds, streak);
    Assert.Equal(expected, result);
}
```
```
