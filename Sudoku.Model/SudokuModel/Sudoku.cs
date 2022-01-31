using SudokuApp.Model.Base;
using SudokuApp.Model.Restrictions;
using SudokuApp.Model.Rules;
using System.Linq;
namespace SudokuApp.Model.SudokuModel
{
    public class Sudoku
    {
        public List<Cell> Cells { get; set; }

        private Sudoku()
        {
            Cells = new List<Cell>();
        }

        public static Sudoku Initialize()
        {
            Sudoku newSudoku = new Sudoku();

            for (int row = 1; row <= 9; row++)
            {
                for (int column = 1; column <= 9; column++)
                {
                    newSudoku.Cells.Add(Cell.Create(row, column));
                }
            }

            return newSudoku;
        }

        public void PutValue(int row, int column, int value)
        {
            Cell cell = GetCell(row, column);

            RuleExtensions.CheckRule(new CellValueInvalidValueRule(value));

            RuleExtensions.CheckRule(new CellMustBeEmptyRule(cell));

            RuleExtensions.CheckRule(new ValueIsUniqueInRowRule(this, row, value));

            RuleExtensions.CheckRule(new ValueIsUniqueInColumnRule(this, column, value));

            RuleExtensions.CheckRule(new ValueIsUniqueInBoxRule(this, row, column, value));

            cell.PutValue(value);

            AddRestrictionsForNewCell(cell);
        }

        private void AddRestrictionsForNewCell(Cell newCell)
        {
            if (newCell != null && newCell.Value.HasValue)
            {
                int newValue = newCell.Value.Value;

                foreach (var cell in GetRowCells(newCell.Row))
                {
                    cell.AddRestriction(newValue, ValueRestrictionType.SameRow);
                }

                foreach (var cell in GetColumnCells(newCell.Column))
                {
                    cell.AddRestriction(newValue, ValueRestrictionType.SameColumn);
                }

                foreach (var cell in GetBoxCells(newCell.Row, newCell.Column))
                {
                    cell.AddRestriction(newValue, ValueRestrictionType.SameBox);
                }
            }
        }

        internal IEnumerable<Cell> GetBoxCells(int row, int column)
        {
            return Cells.Where(x => x.Box == Box.FromCoordinates(row, column));
        }

        public IEnumerable<Cell> GetRowCells(int row)
        {
            return Cells.Where(x => x.Row == row);
        }

        public IEnumerable<Cell> GetColumnCells(int column)
        {
            return Cells.Where(x => x.Column == column);
        }

        public Cell GetCell(int row, int column)
        {
            Cell cell = Cells.FirstOrDefault(x => x.Row == row && x.Column == column);

            if (cell == null)
                throw new Exception("Cell not found");

            return cell;
        }

        public AllowedValue GuessNextCell()
        {
            for (int row = 1; row <= 9; row++)
            {
                IEnumerable<Cell> cells = GetRowCells(row);

                List<AllowedValue> allowedValues = new List<AllowedValue>();

                foreach (var allowedValue in cells.SelectMany(x => x.AllowedValues).Distinct())
                {
                    allowedValues.Add(new AllowedValue(allowedValue, cells.Where(x => x.AllowedValues.Contains(allowedValue))));
                }

                if(allowedValues.Any(x => x.Cells.Count() == 1))
                    return allowedValues.First(x => x.Cells.Count() == 1);
            }

            for (int column = 1; column <= 9; column++)
            {
                IEnumerable<Cell> cells = GetColumnCells(column);

                List<AllowedValue> allowedValues = new List<AllowedValue>();

                foreach (var allowedValue in cells.SelectMany(x => x.AllowedValues).Distinct())
                {
                    allowedValues.Add(new AllowedValue(allowedValue, cells.Where(x => x.AllowedValues.Contains(allowedValue))));
                }

                if (allowedValues.Any(x => x.Cells.Count() == 1))
                    return allowedValues.First(x => x.Cells.Count() == 1);
            }

            foreach (var box in Cells.Select(x => x.Box).Distinct())
            {
                IEnumerable<Cell> cells = Cells.Where(x=> x.Box == box);

                List<AllowedValue> allowedValues = new List<AllowedValue>();

                foreach (var allowedValue in cells.SelectMany(x => x.AllowedValues).Distinct())
                {
                    allowedValues.Add(new AllowedValue(allowedValue, cells.Where(x => x.AllowedValues.Contains(allowedValue))));
                }

                if (allowedValues.Any(x => x.Cells.Count() == 1))
                    return allowedValues.First(x => x.Cells.Count() == 1);
            }

            return null;
        }
    }
}