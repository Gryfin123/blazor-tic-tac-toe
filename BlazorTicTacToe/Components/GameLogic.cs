using Microsoft.JSInterop;
using static BlazroTicTacToe.Components.Pages.Tictactoe;

namespace BlazroTicTacToe.Components
{
    public class GameLogic
    {
        // --- Events --- //
        public event MessageDelegate? RaiseMessage;
        public delegate void MessageDelegate(string message);
        


        // --- Data --- //
        CellState currentPlayer = CellState.CROSS;


        // Check if board is full
        public bool IsBoardFull
        {
            get
            {
                foreach (BoardCell item in currentBoardData)
                {
                    if (item.State == CellState.DEFAULT)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        // Array to hold board data
        public BoardCell[,] currentBoardData =
        {
        { new BoardCell(CellState.CROSS),
            new BoardCell(),
            new BoardCell(CellState.CROSS)},
        { new BoardCell(),
            new BoardCell(),
            new BoardCell()},
        { new BoardCell(),
            new BoardCell(CellState.CROSS),
            new BoardCell(CellState.CROSS)}
    };


        // --- Functions --- //
        //Change player after an action
        public void ChangePlayer()
        {
            if (currentPlayer == CellState.CROSS)
            {
                currentPlayer = CellState.CIRCLE;
            }
            else
            {
                currentPlayer = CellState.CROSS;
            }
        }

        // Triggered when clicked on a cell
        public void BoardCellOnClick(BoardCell cell)
        {
            cell.ChangeState(currentPlayer);

            if (CheckIfCurrentPlayerWon())
            {
                LockBoard();

                // Alert that the game is over and who has won
                string playerName = "";
                if (currentPlayer == CellState.CIRCLE)
                {
                    playerName = "Circle";
                }
                else
                {
                    playerName = "Cross";
                }

                RaiseMessage?.Invoke("Player with " + playerName + " won! Click Restart to try again.");

                return;
            }

            if (IsBoardFull)
            {
                // Alert that the game is over because of no space on the board
                RaiseMessage?.Invoke("Board is full, so the match is a draw. Click Restart to continue.");
                return;
            }

            ChangePlayer();
        }
        // Check if current player has winning combination
        public bool CheckIfCurrentPlayerWon()
        {
            for (int col = 0; col < currentBoardData.GetLength(0); col++)
            {
                for (int row = 0; row < currentBoardData.GetLength(1); row++)
                {
                    if (currentBoardData[col, row].State == currentPlayer)
                    {
                        // Checkes for lines made with current cell as center
                        if (CheckCell(col - 1, row - 1) && CheckCell(col + 1, row + 1)) return true;
                        if (CheckCell(col - 1, row + 1) && CheckCell(col + 1, row - 1)) return true;
                        if (CheckCell(col - 0, row - 1) && CheckCell(col + 0, row + 1)) return true;
                        if (CheckCell(col - 1, row - 0) && CheckCell(col + 1, row - 0)) return true;
                    }
                }
            }

            return false;
        }
        // Checks if cell at chosen coordinates is of current player
        private bool CheckCell(int col, int row)
        {
            // Check if coordinates are inside of index
            if (col < currentBoardData.GetLength(0) && col >= 0 &&
                row < currentBoardData.GetLength(1) && row >= 0)
            {
                // If searched cell is in an array, check if it matches current player
                if (currentBoardData[col, row].State == currentPlayer)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                // If checked place is out of bound (what is gonna happen), return that the cell is not of interest for current player
                return false;
            }
        }

        // Set all buttons to be unclickable
        public void LockBoard()
        {
            foreach (BoardCell item in currentBoardData)
            {
                item.Disable();
            }
        }
        // Restart board settings to default
        public void RestartBoard()
        {
            foreach (BoardCell item in currentBoardData)
            {
                item.Enable();
                item.ChangeState(CellState.DEFAULT);
            }
        }

    }
}

