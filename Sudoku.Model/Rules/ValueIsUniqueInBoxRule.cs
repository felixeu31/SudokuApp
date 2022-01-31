using SudokuApp.Model.Base;
using SudokuApp.Model.SudokuModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuApp.Model.Rules
{
    public class ValueIsUniqueInBoxRule : IBusinessRule
    {
        private readonly Sudoku _sudoku;
        private readonly int _row;
        private readonly int _column;
        private readonly int _newValue;

        public ValueIsUniqueInBoxRule(Sudoku sudoku, int row, int column, int newValue)
        {
            this._sudoku = sudoku;
            this._row = row;
            this._column = column;
            this._newValue = newValue;
        }

        public bool IsBroken()
        {
            IEnumerable<Cell> boxCells = _sudoku.GetBoxCells(_row, _column);

            return boxCells.Any(x => x.Value == _newValue);
        }

        public string Message => "Cell already has value";
    }
}

