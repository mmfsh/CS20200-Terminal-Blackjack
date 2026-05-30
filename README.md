# CS20200-Terminal-Blackjack

A simple, interactive, command-line Blackjack game built with F# and .NET 10.

## How to Run the Game

Follow these steps to run the game on your machine. We strongly suggest testing this on a clean machine installation.

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) must be installed on your system.

### Execution Steps

1. Open your terminal or command prompt.
2. Navigate to the project root directory (where `TerminalBlackjack.fsproj` is located).
3. Run the following command to start the game:
   ```bash
   dotnet run
   ```

## Game Rules (Stated Requirements)

1. **Standard Deck:** The game uses a standard 52-card deck. The cards are shuffled at the beginning of the game.
2. **Card Values:** Number cards (2-10) are worth their face value, face cards (J, Q, K) are worth 10, and Aces are worth 1 or 11 (whichever is more advantageous without exceeding 21).
3. **Initial Deal:** The user and the dealer each receive two cards initially. The user’s cards are fully visible, but only one of the dealer’s cards is shown to the user.
4. **Player Options:** On their turn, the user can choose to enter `H` to Hit (draw another card) or `S` to Stand (end their turn).
5. **Bust Condition:** If the user chooses to hit and their card total exceeds 21, the game system will print a "Bust" message, and the user immediately loses the game.
6. **Dealer AI Rules:** When the user chooses to stand, it becomes the dealer’s turn. The dealer will reveal their hidden card and must automatically hit if their total is 16 or less, and must stand if their total is 17 or higher.
7. **Win Condition:** If the dealer's total exceeds 21, the dealer busts and the user wins. If neither busts, the scores are compared after the dealer stands. The one with a total closest to 21 wins. If the totals are the same, the game is a tie.

---

## LLM (Large Language Model) Usage Experience

### 1. What the LLM was used for:

- Setting up the multi-file project architecture (`Domain.fs`, `Deck.fs`, `Score.fs`, `Program.fs`).
- Implementing the structural backbone for the recursive player/dealer turns in F#.
- Writing the Ace optimization scoring algorithm.
- Writing the README.md documentation writing.

### 2. What had to be manually changed or reprompted:

- **Syntax Error Fix:** A comma was missing in a tuple return inside `playerTurn` (changed `(deck playerHand, false)` to `(deck, playerHand, false)`), which initially caused cascading compiler type mismatches.
- **Game Pacing:** The dealer's turn initially executed instantly, printing walls of text in milliseconds. I manually added `System.Threading.Thread.Sleep` pacing to create a readable, dramatic turn flow for the user.

### 3. Main points that the LLM was not able to do correctly:

- The LLM failed to inherently balance the "gameplay experience/pacing" for a CLI environment, requiring human intervention to introduce timing delays between dealer moves.
- It occasionally struggled with F#'s strict type inference rules across multi-file boundaries until explicit 3-position tuple returns were properly aligned.
