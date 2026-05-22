# CS20200-Terminal-Blackjack

A simple, interactive, command-line Blackjack game built with F# and .NET 10.

## How to Run the Game

Follow these steps to run the game on your machine. We strongly suggest testing this on a clean machine installation.

### Prerequisites
* [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) must be installed on your system.

### Execution Steps
1. Open your terminal or command prompt.
2. Navigate to the project root directory (where `TerminalBlackjack.fsproj` is located).
3. Run the following command to start the game:
   ```bash
   dotnet run

## Game Rules (Stated Requirements)

1. [cite_start]**Standard Deck:** The game uses a standard 52-card deck[cite: 179]. [cite_start]The cards are shuffled at the beginning of the game[cite: 179].
2. [cite_start]**Card Values:** Number cards (2-10) are worth their face value, face cards (J, Q, K) are worth 10, and Aces are worth 1 or 11 (whichever is more advantageous without exceeding 21)[cite: 180].
3. [cite_start]**Initial Deal:** The user and the dealer each receive two cards initially[cite: 181]. [cite_start]The user’s cards are fully visible, but only one of the dealer’s cards is shown to the user[cite: 182].
4. [cite_start]**Player Options:** On their turn, the user can choose to enter `H` to Hit (draw another card) or `S` to Stand (end their turn)[cite: 183].
5. [cite_start]**Bust Condition:** If the user chooses to hit and their card total exceeds 21, the game system will print a "Bust" message, and the user immediately loses the game[cite: 184].
6. [cite_start]**Dealer AI Rules:** When the user chooses to stand, it becomes the dealer’s turn[cite: 185]. [cite_start]The dealer will reveal their hidden card [cite: 185] [cite_start]and must automatically hit if their total is 16 or less, and must stand if their total is 17 or higher[cite: 186].
7. [cite_start]**Win Condition:** If the dealer's total exceeds 21, the dealer busts and the user wins[cite: 187]. [cite_start]If neither busts, the scores are compared after the dealer stands[cite: 188]. [cite_start]The one with a total closest to 21 wins[cite: 188]. [cite_start]If the totals are the same, the game is a tie[cite: 189].

---

## LLM (Large Language Model) Usage Experience

> [cite_start]💡 **Note:** This section is included in compliance with the course project guidelines[cite: 81, 112].

### 1. What the LLM was used for:
* Setting up the multi-file project architecture (`Domain.fs`, `Deck.fs`, `Score.fs`, `Program.fs`).
* Implementing the structural backbone for the recursive player/dealer turns in F#.
* Writing the Ace optimization scoring algorithm.

### 2. What had to be manually changed or reprompted:
* **Syntax Error Fix:** A comma was missing in a tuple return inside `playerTurn` (changed `(deck playerHand, false)` to `(deck, playerHand, false)`), which initially caused cascading compiler type mismatches.
* **Game Pacing:** The dealer's turn initially executed instantly, printing walls of text in milliseconds. I manually added `System.Threading.Thread.Sleep` pacing to create a readable, dramatic turn flow for the user.

### 3. Main points that the LLM was not able to do correctly:
* [cite_start]The LLM failed to inherently balance the "gameplay experience/pacing" for a CLI environment, requiring human intervention to introduce timing delays between dealer moves[cite: 116].
* [cite_start]It occasionally struggled with F#'s strict type inference rules across multi-file boundaries until explicit 3-position tuple returns were properly aligned[cite: 116].