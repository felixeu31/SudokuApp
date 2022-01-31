using NUnit.Framework;
using SudokuApp.Model.Rules;
using SudokuApp.Model.SudokuModel;
using SudokuApp.UnitTests.Base;
using System.Linq;

namespace SudokuApp.UnitTests.NUnit
{
    public class SudokuTests : TestBase
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WhenInitilize_HasAllCells()
        {
            Sudoku sudoku = Sudoku.Initialize();

            Assert.AreEqual(81, sudoku.Cells.Count);
        }

        [Test]
        public void WhenPutValue_InvalidValue_GetException()
        {
            Sudoku sudoku = Sudoku.Initialize();

            AssertBrokenRule<CellValueInvalidValueRule>(() =>
            {
                sudoku.PutValue(1, 1, 10);
            });
        }

        [Test]
        public void WhenPutValue_InFilledCell_GetException()
        {
            Sudoku sudoku = Sudoku.Initialize();

            AssertBrokenRule<CellMustBeEmptyRule>(() =>
            {
                sudoku.PutValue(1,1,1);
                sudoku.PutValue(1,1,1);
            });
        }



        [Test]
        public void WhenPutValue_InRowWithSameNumber_GetException()
        {
            Sudoku sudoku = Sudoku.Initialize();

            AssertBrokenRule<ValueIsUniqueInRowRule>(() =>
            {
                sudoku.PutValue(1, 1, 1);
                sudoku.PutValue(1, 2, 1);
            });
        }


        [Test]
        public void WhenPutValue_InColumnWithSameNumber_GetException()
        {
            Sudoku sudoku = Sudoku.Initialize();

            AssertBrokenRule<ValueIsUniqueInColumnRule>(() =>
            {
                sudoku.PutValue(1, 1, 1);
                sudoku.PutValue(2, 1, 1);
            });
        }


        [Test]
        public void WhenPutValue_InBoxWithSameNumber_GetException()
        {
            Sudoku sudoku = Sudoku.Initialize();

            AssertBrokenRule<ValueIsUniqueInBoxRule>(() =>
            {
                sudoku.PutValue(4, 1, 1);
                sudoku.PutValue(5, 2, 1);
            });
        }

        [Test]
        public void WhenInitialize_restrictionsAreCreated()
        {
            Sudoku sudoku = Sudoku.Initialize();

            sudoku.PutValue(1,4,6);
            sudoku.PutValue(2,1,9);
            sudoku.PutValue(2,3,7);
            sudoku.PutValue(2,4,4);
            sudoku.PutValue(2,6,8);
            sudoku.PutValue(3,5,9);
            sudoku.PutValue(3,7,7);
            sudoku.PutValue(3,9,3);
            sudoku.PutValue(4,4,7);
            sudoku.PutValue(4,5,2);
            sudoku.PutValue(4,7,4);
            sudoku.PutValue(5,1,8);
            sudoku.PutValue(5,3,9);
            sudoku.PutValue(5,4,3);
            sudoku.PutValue(5,5,6);
            sudoku.PutValue(5,6,4);
            sudoku.PutValue(6,2,3);
            sudoku.PutValue(6,3,4);
            sudoku.PutValue(6,4,8);
            sudoku.PutValue(6,6,5);
            sudoku.PutValue(6,7,2);
            sudoku.PutValue(6,8,6);
            sudoku.PutValue(7,4,9);
            sudoku.PutValue(7,9,2);
            sudoku.PutValue(8,2,9);
            sudoku.PutValue(8,4,5);
            sudoku.PutValue(8,7,6);
            sudoku.PutValue(9,3,5);
            sudoku.PutValue(9,5,8);
            sudoku.PutValue(9,6,2);
            sudoku.PutValue(9,9,4);


            do
            {
                var nextValue = sudoku.GuessNextCell();

                if (nextValue != null)
                {
                    Cell cell = nextValue.Cells.First();
                    sudoku.PutValue(cell.Row, cell.Column, nextValue.Value);
                }

            } while (!sudoku.Cells.All(x => x.Value.HasValue));

        }
    }
}