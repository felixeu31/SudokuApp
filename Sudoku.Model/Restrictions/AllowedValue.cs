using SudokuApp.Model.SudokuModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuApp.Model.Restrictions
{
    public class AllowedValue
    {
        public int Value { get; set; }
        public IEnumerable<Cell> Cells { get; set; }

        public int CellCount { get { return Cells.Count(); } }

        public AllowedValue(int value, IEnumerable<Cell> cells)
        {
            Value = value;
            Cells = cells;
        }
    }
}
