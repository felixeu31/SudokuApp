using SudokuApp.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuApp.Model.SudokuModel
{
    public class Box : ValueObject
    {
        private readonly int _boxRow;
        private readonly int _boxColumn;

        private Box(int row, int column)
        {
            _boxRow = (int)Math.Ceiling(row / 3M);
            _boxColumn = (int)Math.Ceiling(column / 3M);
        }

        public static Box FromCoordinates(int row, int column)
        {
            return new Box(row, column);
        }

        public int BoxRow { get { return _boxRow;} }

        public int BoxColumn { get { return _boxColumn;} }
    }
}
