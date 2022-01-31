using SudokuApp.Model.Base;
using SudokuApp.Model.SudokuModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuApp.Model.Rules
{
    public class ValueIsUniqueInRowRule : IBusinessRule
    {
        private readonly Sudoku _sudoku;
        private readonly int _row;
        private readonly int _newValue;
        
        public ValueIsUniqueInRowRule(Sudoku sudoku, int row, int newValue)
        {
            this._sudoku = sudoku;
            this._row = row;
            this._newValue = newValue;
        }

        public bool IsBroken()
        {
            IEnumerable<Cell> rowCells = _sudoku.GetRowCells(_row);

            return rowCells.Any(x => x.Value == _newValue);
        }

        public string Message => "Cell already has value";
    }
}

