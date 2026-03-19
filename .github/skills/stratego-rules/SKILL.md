---
name: stratego-rules
description: Complete rules reference for the Stratego board game. Use this when asked about Stratego game rules, piece ranks, movement, combat mechanics, setup, win conditions, or any other aspect of how Stratego is played.
---

# Stratego Rules Reference

## Overview

Stratego is a two-player strategy board game played on a 10×10 grid. Each player commands an army of 40 pieces with the objective of capturing the opponent's Flag or leaving them with no legal moves.

## Board Layout

- The board is 10×10 squares.
- Two 2×2 impassable lakes are located in the center (columns 3–4, rows 5–6 and columns 7–8, rows 5–6, using 1-based indexing). No piece may enter or cross a lake.
- Each player sets up their pieces in the four rows nearest to them (rows 1–4 for one player, rows 7–10 for the other).
- Setup is secret: pieces are placed face-down and the opponent cannot see the rank of any piece until it is involved in combat.

## Pieces

Each player has 40 pieces. The number of each piece and its special rules are:

| Piece    | Rank | Count | Notes                                                    |
|----------|------|-------|----------------------------------------------------------|
| Marshal  | 10   | 1     | Highest-ranked movable piece. Loses to the Spy.          |
| General  | 9    | 1     |                                                          |
| Colonel  | 8    | 2     |                                                          |
| Major    | 7    | 3     |                                                          |
| Captain  | 6    | 4     |                                                          |
| Lieutenant| 5   | 4     |                                                          |
| Sergeant | 4    | 4     |                                                          |
| Miner    | 3    | 5     | The only piece that can defuse (capture) a Bomb.         |
| Scout    | 2    | 8     | Can move any number of squares in a straight line.       |
| Spy      | 1    | 1     | Can capture the Marshal only when the Spy initiates the attack. Loses to all other pieces. |
| Bomb     | B    | 6     | Immovable. Defeats any attacking piece except a Miner.   |
| Flag     | F    | 1     | Immovable. Capturing the opponent's Flag wins the game.  |

## Movement

- On each turn a player must move exactly one piece.
- Most pieces move exactly one square per turn — horizontally or vertically. Diagonal movement is not allowed.
- **Scout** may move any number of unoccupied squares in a straight line (horizontally or vertically) in a single turn, similar to a rook in chess. It may not jump over other pieces or lakes.
- **Bomb** and **Flag** are immovable and cannot be moved at any point during the game.
- A piece cannot move to a square occupied by a friendly piece.
- A piece cannot move onto or through a lake square.
- A piece cannot move back and forth between the same two squares on three consecutive turns (the two-square rule / perpetual-motion rule). If it does, the player must make a different move.

## Combat

Combat occurs when a piece moves onto a square occupied by an opposing piece.

1. Both pieces are revealed (turned face-up) to both players.
2. The piece with the **higher rank wins** and remains on the board; the losing piece is removed.
3. If both pieces have **equal rank**, both pieces are removed from the board.
4. The winning piece moves into the contested square.

### Special combat rules

- **Spy vs. Marshal**: The Spy defeats the Marshal **only** when the Spy is the attacker (moves onto the Marshal's square). If the Marshal attacks the Spy, the Marshal wins.
- **Miner vs. Bomb**: The Miner is the only piece that defeats a Bomb. Any other piece that attacks a Bomb is destroyed; the Bomb remains.
- **Any piece vs. Flag**: Any piece that moves onto the Flag's square captures it and wins the game.

## Win Conditions

A player wins when either:
1. They **capture the opponent's Flag**.
2. The opponent **has no legal moves** on their turn (all movable pieces are completely surrounded by friendly pieces, lakes, or board edges).

A draw can be agreed upon by both players if neither side can make progress.

## Setup Rules

- Players set up their 40 pieces in their own four starting rows before the game begins.
- Placement is entirely up to each player — there are no mandatory positions.
- Pieces are placed face-down so the opponent cannot see the ranks.
- Once both players have finished setup, the player who goes first (often determined randomly) takes the first turn.

## Turn Structure

1. The current player moves one of their pieces (or initiates combat by moving onto an opponent's square).
2. If combat occurs, resolve it according to the combat rules above.
3. Play passes to the other player.

## Key Strategic Notes

- Bombs are commonly used to protect the Flag.
- Miners are valuable because they are the only way to neutralize Bombs.
- The Spy is high-risk, high-reward: it is the only piece that can eliminate the Marshal but loses to every other rank.
- Scouts are useful for reconnaissance and rapid repositioning.
- Piece positions remain secret until revealed in combat, making bluffing and deduction central to the game.
