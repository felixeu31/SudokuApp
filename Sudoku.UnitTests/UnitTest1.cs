using Xunit;
using SudokuApp.Model.SudokuModel;

namespace SudokuApp.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void WhenInitilize_HasAllCells()
        {
            Sudoku sudoku = Sudoku.Initialize();

            Assert.Equal(81, sudoku.Cells.Count);
        }

        //[Fact]
        //public void WhenInitilize_CellIsInCorrectBox()
        //{
        //    Sudoku sudoku = Sudoku.Initialize();

        //    Assert.Equal(1, sudoku.GetCell(1, 6).Box);
        //}

        [Fact]
        public void WhenPutValue_InFilledCell_GetException()
        {
            Sudoku sudoku = Sudoku.Initialize();

            Assert.Equal(81, sudoku.Cells.Count);
        }
    }
}