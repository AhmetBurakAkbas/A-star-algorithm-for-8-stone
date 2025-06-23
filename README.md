# 8 Puzzle Solver using A* Algorithm – C# Implementation

This project implements the **A\*** pathfinding algorithm to solve the classic **8-puzzle problem**. The application is developed in **C#** without using any external pathfinding libraries. The puzzle states and solution steps are visualized through a graphical interface.

---

## 🧩 Problem Description

- **Goal:** Reach the target configuration of the 8-puzzle using the least number of moves.
- **Puzzle Elements:** Tiles numbered from **1 to 8** and a **blank (empty)** space.
- **Operators:** Move the blank tile **up, down, left, or right**.
- **Cost:** Each move has a **cost of 1**.
- **Algorithm:** A* (A star) search using the function `f(n) = g(n) + h(n)`

---

## 🧠 A* Algorithm Components

- **g(n):** Cost from the start state to the current node (number of moves so far)
- **h(n):** Heuristic estimate of the cost to reach the goal
    - You can implement:
      - **Manhattan Distance**
      - Or **Misplaced Tile Heuristic**

---

## 🖥️ Features

- Graphical UI displaying the initial and goal states
- User-defined start and target configurations
- Visual step-by-step solution path
- No use of pre-built pathfinding libraries – pure A* implementation
- Input validation and flexible grid initialization

---

## 🚀 How to Use

1. Clone the repository.
2. Open the solution in **Visual Studio**.
3. Run the application.
4. Enter the **starting configuration** and **goal state**.
5. Click the "Solve" button to visualize the A* algorithm in action.

---

## 📷 Example

| Start State | Goal State |
|-------------|------------|
| 4 1 3        | 1 2 3      |
| 2 8 5        | 4 5 6      |
| 7 _ 6        | 7 8 _      |

---

## 🔧 Technologies Used

- **Language:** C#
- **Platform:** Windows Forms / Console App (as implemented)
- **Algorithm:** A* (custom implementation)

---

## 📁 Project Structure

- `Node.cs` – Represents puzzle states with cost values
- `PuzzleSolver.cs` – Core logic of the A* search
- `MainForm.cs` – GUI for input/output (if using WinForms)
- `Program.cs` – Entry point

---

## 🧾 Notes

- No third-party libraries used
- Each move is visualized
- Supports custom input
- For educational use; clean, modular code

---

## 📌 Future Work

- Add support for different puzzle sizes (e.g., 15-puzzle)
- Add timing and move counters
- Add step-by-step debugging mode

---

### 🪪 License

MIT License

---

**Enjoy solving the puzzle!**

Ahmet Burak Akbaş
