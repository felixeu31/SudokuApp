using SudokuApp.Model.Base;
using SudokuApp.Model.SudokuModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuApp.Model.Rules
{
    public class CellMustBeEmptyRule : IBusinessRule
    {
        private readonly Cell _cell;

        public CellMustBeEmptyRule(Cell cell)
        {
            _cell = cell;
        }

        public bool IsBroken()
        {
            return _cell.Value.HasValue;
        }

        public string Message => "Cell already has value";
    }
}

