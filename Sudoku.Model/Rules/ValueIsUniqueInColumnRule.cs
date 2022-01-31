using SudokuApp.Model.Base;
using SudokuApp.Model.SudokuModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuApp.Model.Rules
{
    public class ValueIsUniqueInColumnRule : IBusinessRule
    {
        private readonly Sudoku _sudoku;
        private readonly int _column;
        private readonly int _newValue;

        public ValueIsUniqueInColumnRule(Sudoku sudoku, int column, int newValue)
        {
            this._sudoku = sudoku;
            this._column = column;
            this._newValue = newValue;
        }

        public bool IsBroken()
        {
            IEnumerable<Cell> columnCells = _sudoku.GetColumnCells(_column);

            return columnCells.Any(x => x.Value == _newValue);
        }

        public string Message => "Cell already has value";
    }
}

