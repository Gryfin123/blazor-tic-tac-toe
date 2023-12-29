using static BlazroTicTacToe.Components.Pages.Tictactoe;

namespace BlazroTicTacToe.Components
{
    public class BoardCell
    {
        // Static Definitions for symbols and colors
        public static string _playerSymbol1 { get { return "x"; } }
        public static string _playerSymbol2 { get { return "o"; } }
        public static string _defaultSymbol { get { return "-"; } }

        public static string _playerColor1 { get { return " btn-secondary "; } } 
        public static string _playerColor2 { get { return " btn-success "; } }
        public static string _defaultColor { get { return " btn-secondary "; } }

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
                        return _defaultSymbol;
                    case CellState.CIRCLE:
                        return _playerSymbol2;
                    case CellState.CROSS:
                        return _playerSymbol1;
                    default:
                        return _defaultSymbol;
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
                        return _defaultColor;
                    case CellState.CIRCLE:
                        return _playerColor2;
                    case CellState.CROSS:
                        return _playerColor1;
                    default:
                        return _defaultColor;
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
