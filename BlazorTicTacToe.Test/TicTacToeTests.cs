using BlazroTicTacToe.Components;
using FluentAssertions;

namespace BlazorTicTacToe.Test
{

    public class TicTacToeTests
    {
        // --- Game Logic --- //
        [Fact]
        public void GameLogic_IsBoardFull_CaseInitial()
        {
            // Arrange 
            GameLogic gameLogic = new GameLogic();

            // Act


            // Assert
            gameLogic.IsBoardFull.Should().BeFalse();
        }
        [Fact]
        public void GameLogic_IsBoardFull_CaseAfterReset()
        {
            // Arrange 
            GameLogic gameLogic = new GameLogic();

            // Act
            gameLogic.RestartBoard();

            // Assert
            gameLogic.IsBoardFull.Should().BeFalse();
        }
        [Fact]
        public void GameLogic_IsBoardFull_CasePartiallyFull()
        {
            // Arrange 
            GameLogic gameLogic = new GameLogic();

            // Act
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[0, 0]);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[0, 1]);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[0, 2]);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[2, 0]);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[2, 2]);

            // Assert
            gameLogic.IsBoardFull.Should().BeFalse();
        }
        [Fact]
        public void GameLogic_IsBoardFull_CaseFull()
        {
            // Arrange 
            GameLogic gameLogic = new GameLogic();

            // Act
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[0, 0], CellState.CROSS);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[0, 1], CellState.CIRCLE);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[0, 2], CellState.CROSS);

            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[1, 0], CellState.CROSS);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[1, 1], CellState.CIRCLE);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[1, 2], CellState.CROSS);

            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[2, 0], CellState.CIRCLE);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[2, 1], CellState.CROSS);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[2, 2], CellState.CIRCLE);

            // Assert
            gameLogic.IsBoardFull.Should().BeTrue();
        }

        [Fact]
        public void GameLogic_ChangePlayer_SwitchingPlayer()
        {
            // Arrange 
            GameLogic gameLogic = new GameLogic();

            // Act
            CellState result1 = gameLogic.currentPlayer;
            gameLogic.ChangePlayer();

            CellState result2 = gameLogic.currentPlayer;
            gameLogic.ChangePlayer();

            CellState result3 = gameLogic.currentPlayer;

            // Assert
            result1.Should().Be(result3);
            result2.Should().NotBe(result1);
            result2.Should().NotBe(result3);
        }

        [Fact]
        public void GameLogic_CheckIfCurrentPlayerWon_ReturnsTrue()
        {
            // Arrange 
            GameLogic gameLogic = new GameLogic();

            // Act
            // Case 1
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[0, 0], CellState.CROSS);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[0, 1], CellState.CROSS);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[0, 2], CellState.CROSS);

            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[1, 0], CellState.DEFAULT);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[1, 1], CellState.DEFAULT);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[1, 2], CellState.DEFAULT);

            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[2, 0], CellState.DEFAULT);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[2, 1], CellState.DEFAULT);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[2, 2], CellState.DEFAULT);
            gameLogic.currentPlayer = CellState.CROSS;
            bool result1 = gameLogic.CheckIfCurrentPlayerWon();

            // Case 2
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[0, 0], CellState.CROSS);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[0, 1], CellState.CIRCLE);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[0, 2], CellState.CROSS);

            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[1, 0], CellState.DEFAULT);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[1, 1], CellState.CROSS);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[1, 2], CellState.DEFAULT);

            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[2, 0], CellState.CIRCLE);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[2, 1], CellState.DEFAULT);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[2, 2], CellState.CROSS);
            gameLogic.currentPlayer = CellState.CROSS;
            bool result2 = gameLogic.CheckIfCurrentPlayerWon();

            // Case 3
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[0, 0], CellState.CROSS);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[0, 1], CellState.CIRCLE);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[0, 2], CellState.CROSS);

            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[1, 0], CellState.DEFAULT);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[1, 1], CellState.CIRCLE);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[1, 2], CellState.DEFAULT);

            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[2, 0], CellState.CROSS);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[2, 1], CellState.CROSS);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[2, 2], CellState.CROSS);
            gameLogic.currentPlayer = CellState.CROSS;
            bool result3 = gameLogic.CheckIfCurrentPlayerWon();

            // Case 4
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[0, 0], CellState.CROSS);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[0, 1], CellState.CIRCLE);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[0, 2], CellState.CROSS);

            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[1, 0], CellState.DEFAULT);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[1, 1], CellState.CIRCLE);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[1, 2], CellState.DEFAULT);

            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[2, 0], CellState.CIRCLE);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[2, 1], CellState.CIRCLE);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[2, 2], CellState.DEFAULT);
            gameLogic.currentPlayer = CellState.CIRCLE;
            bool result4 = gameLogic.CheckIfCurrentPlayerWon();

            // Case 5
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[0, 0], CellState.CIRCLE);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[0, 1], CellState.CROSS);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[0, 2], CellState.CROSS);

            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[1, 0], CellState.CIRCLE);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[1, 1], CellState.DEFAULT);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[1, 2], CellState.DEFAULT);

            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[2, 0], CellState.CIRCLE);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[2, 1], CellState.DEFAULT);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[2, 2], CellState.CROSS);
            gameLogic.currentPlayer = CellState.CIRCLE;
            bool result5 = gameLogic.CheckIfCurrentPlayerWon();

            // Case 6
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[0, 0], CellState.CIRCLE);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[0, 1], CellState.CROSS);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[0, 2], CellState.CROSS);

            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[1, 0], CellState.CIRCLE);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[1, 1], CellState.CIRCLE);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[1, 2], CellState.CROSS);

            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[2, 0], CellState.DEFAULT);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[2, 1], CellState.DEFAULT);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[2, 2], CellState.CROSS);
            gameLogic.currentPlayer = CellState.CROSS;
            bool result6 = gameLogic.CheckIfCurrentPlayerWon();

            // Assert
            result1.Should().BeTrue();
            result2.Should().BeTrue();
            result3.Should().BeTrue();
            result4.Should().BeTrue();
            result5.Should().BeTrue();
            result6.Should().BeTrue();
        }
        [Fact]
        public void GameLogic_CheckIfCurrentPlayerWon_ReturnsFalse()
        {
            // Arrange 
            GameLogic gameLogic = new GameLogic();
            // Act
            // Case 1
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[0, 0], CellState.CROSS);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[0, 1], CellState.CIRCLE);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[0, 2], CellState.CROSS);

            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[1, 0], CellState.DEFAULT);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[1, 1], CellState.DEFAULT);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[1, 2], CellState.DEFAULT);

            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[2, 0], CellState.DEFAULT);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[2, 1], CellState.DEFAULT);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[2, 2], CellState.DEFAULT);
            gameLogic.currentPlayer = CellState.CIRCLE;
            bool result1 = gameLogic.CheckIfCurrentPlayerWon();

            // Case 2
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[0, 0], CellState.CROSS);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[0, 1], CellState.CIRCLE);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[0, 2], CellState.CROSS);

            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[1, 0], CellState.DEFAULT);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[1, 1], CellState.CIRCLE);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[1, 2], CellState.DEFAULT);

            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[2, 0], CellState.DEFAULT);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[2, 1], CellState.CROSS);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[2, 2], CellState.DEFAULT);
            gameLogic.currentPlayer = CellState.CIRCLE;
            bool result2 = gameLogic.CheckIfCurrentPlayerWon();

            // Case 3
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[0, 0], CellState.CROSS);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[0, 1], CellState.CIRCLE);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[0, 2], CellState.CROSS);

            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[1, 0], CellState.DEFAULT);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[1, 1], CellState.CIRCLE);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[1, 2], CellState.DEFAULT);

            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[2, 0], CellState.CROSS);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[2, 1], CellState.CROSS);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[2, 2], CellState.CIRCLE);
            gameLogic.currentPlayer = CellState.CIRCLE;
            bool result3 = gameLogic.CheckIfCurrentPlayerWon();

            // Case 4
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[0, 0], CellState.CROSS);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[0, 1], CellState.CIRCLE);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[0, 2], CellState.CROSS);

            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[1, 0], CellState.CIRCLE);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[1, 1], CellState.CIRCLE);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[1, 2], CellState.CROSS);

            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[2, 0], CellState.CROSS);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[2, 1], CellState.CROSS);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[2, 2], CellState.CIRCLE);
            gameLogic.currentPlayer = CellState.CIRCLE;
            bool result4 = gameLogic.CheckIfCurrentPlayerWon();

            // Case 5
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[0, 0], CellState.CROSS);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[0, 1], CellState.CIRCLE);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[0, 2], CellState.CROSS);

            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[1, 0], CellState.CIRCLE);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[1, 1], CellState.CIRCLE);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[1, 2], CellState.CROSS);

            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[2, 0], CellState.CROSS);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[2, 1], CellState.CIRCLE);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[2, 2], CellState.CIRCLE);
            gameLogic.currentPlayer = CellState.CROSS;
            bool result5 = gameLogic.CheckIfCurrentPlayerWon();


            // Assert
            result1.Should().BeFalse();
            result2.Should().BeFalse();
            result3.Should().BeFalse();
            result4.Should().BeFalse();
            result5.Should().BeFalse();
        }

        [Fact]
        public void GameLogic_CheckCellForCurrentPlayer_ReturnTrue()
        {
            // Arrange 
            GameLogic gameLogic = new GameLogic();

            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[0, 0], CellState.CROSS);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[0, 1], CellState.CIRCLE);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[0, 2], CellState.CROSS);

            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[1, 0], CellState.DEFAULT);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[1, 1], CellState.CROSS);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[1, 2], CellState.DEFAULT);

            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[2, 0], CellState.CIRCLE);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[2, 1], CellState.CIRCLE);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[2, 2], CellState.CROSS);

            gameLogic.currentPlayer = CellState.CROSS;

            // Act
            bool result1 = gameLogic.CheckCellForCurrentPlayer(0,0);
            bool result2 = gameLogic.CheckCellForCurrentPlayer(1,1);
            bool result3 = gameLogic.CheckCellForCurrentPlayer(2,2);
            bool result4 = gameLogic.CheckCellForCurrentPlayer(0,2);

            // Assert
            result1.Should().BeTrue();
            result2.Should().BeTrue();
            result3.Should().BeTrue();
            result4.Should().BeTrue();
        }
        [Fact]
        public void GameLogic_CheckCellForCurrentPlayer_ReturnFalse()
        {
            // Arrange 
            GameLogic gameLogic = new GameLogic();

            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[0, 0], CellState.CROSS);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[0, 1], CellState.CIRCLE);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[0, 2], CellState.CROSS);

            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[1, 0], CellState.DEFAULT);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[1, 1], CellState.CROSS);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[1, 2], CellState.DEFAULT);

            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[2, 0], CellState.CIRCLE);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[2, 1], CellState.CIRCLE);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[2, 2], CellState.CROSS);

            gameLogic.currentPlayer = CellState.CROSS;

            // Act
            bool result1 = gameLogic.CheckCellForCurrentPlayer(0, 1);
            bool result2 = gameLogic.CheckCellForCurrentPlayer(1, 0);
            bool result3 = gameLogic.CheckCellForCurrentPlayer(-1, 0);
            bool result4 = gameLogic.CheckCellForCurrentPlayer(0, -1);
            bool result5 = gameLogic.CheckCellForCurrentPlayer(10, 0);
            bool result6 = gameLogic.CheckCellForCurrentPlayer(0, 10);

            // Assert
            result1.Should().BeFalse();
            result2.Should().BeFalse();
            result3.Should().BeFalse();
            result4.Should().BeFalse();
            result5.Should().BeFalse();
            result6.Should().BeFalse();
        }

        [Fact]
        public void GameLogic_LockBoard_Complete()
        {
            // Arrange 
            GameLogic gameLogic = new GameLogic();

            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[0, 0], CellState.CROSS);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[0, 1], CellState.CIRCLE);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[0, 2], CellState.CROSS);

            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[1, 0], CellState.DEFAULT);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[1, 1], CellState.CROSS);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[1, 2], CellState.DEFAULT);

            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[2, 0], CellState.CIRCLE);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[2, 1], CellState.CIRCLE);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[2, 2], CellState.DEFAULT);

            gameLogic.currentPlayer = CellState.CROSS;

            // Act
            gameLogic.LockBoard();

            // Assert
            gameLogic.currentBoardData[0, 0].Disabled.Should().BeTrue();
            gameLogic.currentBoardData[0, 1].Disabled.Should().BeTrue();
            gameLogic.currentBoardData[0, 2].Disabled.Should().BeTrue();

            gameLogic.currentBoardData[1, 0].Disabled.Should().BeTrue();
            gameLogic.currentBoardData[1, 1].Disabled.Should().BeTrue();
            gameLogic.currentBoardData[1, 2].Disabled.Should().BeTrue();

            gameLogic.currentBoardData[2, 0].Disabled.Should().BeTrue();
            gameLogic.currentBoardData[2, 1].Disabled.Should().BeTrue();
            gameLogic.currentBoardData[2, 2].Disabled.Should().BeTrue();

        }

        [Fact]
        public void GameLogic_RestartBoard_Complete()
        {
            // Arrange 
            GameLogic gameLogic = new GameLogic();

            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[0, 0], CellState.CROSS);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[0, 1], CellState.CIRCLE);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[0, 2], CellState.CROSS);

            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[1, 0], CellState.DEFAULT);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[1, 1], CellState.CROSS);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[1, 2], CellState.DEFAULT);

            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[2, 0], CellState.CIRCLE);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[2, 1], CellState.CIRCLE);
            gameLogic.BoardCellOnClick(gameLogic.currentBoardData[2, 2], CellState.DEFAULT);

            gameLogic.currentPlayer = CellState.CROSS;

            // Act
            gameLogic.RestartBoard();

            // Assert
            gameLogic.currentBoardData[0, 0].State.Should().Be(CellState.DEFAULT);
            gameLogic.currentBoardData[0, 1].State.Should().Be(CellState.DEFAULT);
            gameLogic.currentBoardData[0, 2].State.Should().Be(CellState.DEFAULT);

            gameLogic.currentBoardData[1, 0].State.Should().Be(CellState.DEFAULT);
            gameLogic.currentBoardData[1, 1].State.Should().Be(CellState.DEFAULT);
            gameLogic.currentBoardData[1, 2].State.Should().Be(CellState.DEFAULT);

            gameLogic.currentBoardData[2, 0].State.Should().Be(CellState.DEFAULT);
            gameLogic.currentBoardData[2, 1].State.Should().Be(CellState.DEFAULT);
            gameLogic.currentBoardData[2, 2].State.Should().Be(CellState.DEFAULT);

        }


        // --- Board Cell --- //
        [Fact]
        public void BoardCell_GetText_Successful()
        {
            // Arrange 
            BoardCell cell = new BoardCell(CellState.DEFAULT);

            // Act
            string result1 = cell.Text;

            cell.ChangeState(CellState.CIRCLE);
            string result2 = cell.Text;

            cell.ChangeState(CellState.CROSS);
            string result3 = cell.Text;

            // Assert
            result1.Should().Be(BoardCell._symbolDefault);
            result2.Should().Be(BoardCell._symbolPlayerO);
            result3.Should().Be(BoardCell._symbolPlayerX);
        }
        [Fact]
        public void BoardCell_GetColor_Successful()
        {
            // Arrange 
            BoardCell cell = new BoardCell(CellState.DEFAULT);

            // Act
            string result1 = cell.Color;

            cell.ChangeState(CellState.CIRCLE);
            string result2 = cell.Color;

            cell.ChangeState(CellState.CROSS);
            string result3 = cell.Color;

            // Assert
            result1.Should().Be(BoardCell._colorDefault);
            result2.Should().Be(BoardCell._colorPlayerO);
            result3.Should().Be(BoardCell._colorPlayerX);
        }
        [Fact]
        public void BoardCell_GetDisabledText_Successful()
        {
            // Arrange 
            BoardCell cell = new BoardCell(CellState.DEFAULT);

            // Act
            string result1 = cell.DisabledText;

            cell.ChangeState(CellState.CIRCLE);
            string result2 = cell.DisabledText;

            cell.ChangeState(CellState.CROSS);
            string result3 = cell.DisabledText;

            // Assert
            result1.Should().Be(BoardCell._enabledText);
            result2.Should().Be(BoardCell._disabledText);
            result3.Should().Be(BoardCell._disabledText);
        }


        [Fact]
        public void BoardCell_Constructor_Default()
        {
            // Arrange 
            BoardCell cell = new BoardCell();

            // Assert
            cell.State.Should().Be(CellState.DEFAULT);
        }
        [Fact]
        public void BoardCell_Constructor_ManuallySet()
        {
            // Arrange 
            BoardCell cell = new BoardCell(CellState.CROSS);

            // Assert
            cell.State.Should().Be(CellState.CROSS);
        }

        [Fact]
        public void BoardCell_ChangeState_Successful()
        {
            // Arrange 
            BoardCell cell = new BoardCell(CellState.DEFAULT);

            // Act
            CellState result1 = cell.State;

            cell.ChangeState(CellState.CROSS);
            CellState result2 = cell.State;

            cell.ChangeState(CellState.CIRCLE);
            CellState result3 = cell.State;

            cell.ChangeState(CellState.DEFAULT);
            CellState result4 = cell.State;

            // Assert
            result1.Should().Be(CellState.DEFAULT);
            result2.Should().Be(CellState.CROSS);
            result3.Should().Be(CellState.CIRCLE);
            result4.Should().Be(CellState.DEFAULT);
        }


        [Fact]
        public void BoardCell_Disable_Successful()
        {
            // Arrange 
            BoardCell cell = new BoardCell(CellState.DEFAULT);

            // Act
            cell.Disable();

            // Assert
            cell.Disabled.Should().BeTrue();
        }
        [Fact]
        public void BoardCell_Enable_Successful()
        {
            // Arrange 
            BoardCell cell = new BoardCell(CellState.DEFAULT);

            // Act
            cell.Disable();
            cell.Enable();

            // Assert
            cell.Disabled.Should().BeFalse();
        }






    }
}