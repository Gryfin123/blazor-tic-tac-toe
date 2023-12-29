using static BlazroTicTacToe.Components.Pages.Tictactoe;

namespace BlazroTicTacToe.Components
{
    public class BoardCell
    {
        // Static Definitions for symbols and colors
        public static string _symbolPlayerX { get { return "x"; } }
        public static string _symbolPlayerO { get { return "o"; } }
        public static string _symbolDefault { get { return "-"; } }

        public static string _colorPlayerX { get { return " btn-danger "; } } 
        public static string _colorPlayerO { get { return " btn-success "; } }
        public static string _colorDefault { get { return " btn-secondary "; } }

        public static string _disabledText { get { return " disabled "; } }
        public static string _enabledText { get { return ""; } }



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
                        return _symbolDefault;
                    case CellState.CIRCLE:
                        return _symbolPlayerO;
                    case CellState.CROSS:
                        return _symbolPlayerX;
                    default:
                        return _symbolDefault;
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
                        return _colorDefault;
                    case CellState.CIRCLE:
                        return _colorPlayerO;
                    case CellState.CROSS:
                        return _colorPlayerX;
                    default:
                        return _colorDefault;
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
                    return _disabledText;
                }

                switch (state)
                {
                    case CellState.DEFAULT:
                        return _enabledText;
                    case CellState.CIRCLE:
                        return _disabledText;
                    case CellState.CROSS:
                        return _disabledText;
                    default:
                        return _enabledText;
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
