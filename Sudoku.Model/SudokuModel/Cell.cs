using SudokuApp.Model.Restrictions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuApp.Model.SudokuModel
{
    public class Cell
    {
        private readonly int _row;
        private readonly int _column;
        private int? _value;
        private List<ValueRestriction> _valueRestrictions { get; set; }

        public int Row { get { return _row; } }
        public int Column { get { return _column; } }
        public int? Value { get { return _value; } }

        public Box Box { get { return Box.FromCoordinates(_row, _column); } }

        //public IEnumerable<ValueRestriction> ValueRestrictions { get { return _valueRestrictions; } }

        public IEnumerable<int> AllowedValues
        {
            get
            {
                if(Value != null)
                    return new List<int>();

                return (new List<int> { 1,2,3,4,5,6,7,8,9}).Where(x => !_valueRestrictions.Any(restriction => restriction.Value == x));
            }
        }

        private Cell(int row, int column)
        {
            _row = row;
            _column = column;
            _valueRestrictions = new List<ValueRestriction>();
        }

        public static Cell Create(int row, int column)
        {
            return new Cell(row, column);
        }

        public void PutValue(int value)
        {
            _value = value;
        }

        internal void AddRestriction(int value, ValueRestrictionType valueRestrictionType)
        {
            ValueRestriction valueRestriction = ValueRestriction.Create(value, valueRestrictionType);

            if (!_valueRestrictions.Any(x => x == valueRestriction))
                _valueRestrictions.Add(valueRestriction);
        }
    }
}
