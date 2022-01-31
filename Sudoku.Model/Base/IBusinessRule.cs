namespace SudokuApp.Model.Base
{
    public interface IBusinessRule
    {
        bool IsBroken();

        string Message { get; }
    }
}