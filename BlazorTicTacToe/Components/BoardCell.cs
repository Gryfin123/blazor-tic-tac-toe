using static BlazroTicTacToe.Components.Pages.Tictactoe;

namespace BlazroTicTacToe.Components
{
    public class BoardCell
    {
        private CellState state = CellState.DEFAULT;
        private bool disabled = false;

        public CellState State
        {
            get { return state; }
            private set { state = value; }
        }
        public string Text
        {
            get
            {
                switch (state)
                {
                    case CellState.DEFAULT:
                        return "-";
                    case CellState.CIRCLE:
                        return "o";
                    case CellState.CROSS:
                        return "x";
                    default:
                        return "-";
                }
            }
        }
        public string Color
        {
            get
            {
                switch (state)
                {
                    case CellState.DEFAULT:
                        return " btn-secondary ";
                    case CellState.CIRCLE:
                        return " btn-success ";
                    case CellState.CROSS:
                        return " btn-danger ";
                    default:
                        return "btn-secondary";
                }
            }
        }
        public bool Disabled
        {
            get { return disabled; }
        }
        public string DisabledText
        {
            get
            {
                if (disabled)
                {
                    return " disabled ";
                }

                switch (state)
                {
                    case CellState.DEFAULT:
                        return "";
                    case CellState.CIRCLE:
                        return " disabled ";
                    case CellState.CROSS:
                        return " disabled ";
                    default:
                        return "";
                }
            }
        }

        public BoardCell() {; }
        public BoardCell(CellState cellState)
        {
            ChangeState(cellState);
        }

        // Changed button adequate to the state
        public void ChangeState(CellState cellState)
        {
            state = cellState;
        }
        public void Disable()
        {
            disabled = true;
        }
        public void Enable()
        {
            disabled = false;
        }

    }

    public enum CellState
    {
        DEFAULT,
        CIRCLE,
        CROSS
    }
}
