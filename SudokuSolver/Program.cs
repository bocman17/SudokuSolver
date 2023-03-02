using SudokuLibrary;
using System.Runtime.InteropServices;
using System.Security;

try
{
    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
    {
        Console.SetWindowSize(100, 25);
    }
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"type: {ex.GetType()}, message: {ex.Message}");

}
catch (SecurityException ex)
{
    Console.WriteLine($"type: {ex.GetType()}, message: {ex.Message}");

}
catch (IOException ex)
{
    Console.WriteLine($"type: {ex.GetType()}, message: {ex.Message}");

}
catch (PlatformNotSupportedException ex)
{
    Console.WriteLine($"type: {ex.GetType()}, message: {ex.Message}");

}

Console.WriteLine("Welcome to Sudoku Solver");
Console.WriteLine();

var input = Solver.Input();
Console.WriteLine();
Solver.PrintSudoku(input);
Console.WriteLine();
Solver.SolveSudoku(input);
