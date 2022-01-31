using SudokuApp.Model.Base;
using SudokuApp.Model.SudokuModel;
   

namespace SudokuApp.Model.Rules
{
    public class CellValueInvalidValueRule : IBusinessRule
    {
        private readonly int _value;

        public CellValueInvalidValueRule(int value)
        {
            _value = value;
        }

        public bool IsBroken()
        {
            return !(_value >= 1 && _value <= 9);
        }

        public string Message => "Given value is invalid. Must be an integer value from 1 to 9";
    }
}