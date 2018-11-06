using System.Linq;
using System.Collections.Generic;

//https://www.codewars.com/kata/sudoku-solution-validator/train/csharp
namespace SandBox.CodewarsKatas
{
    public class SudokuSolutionValidator
    {
        private static List<int> correctSample = new List<int>{ 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        public static bool ValidateSolution(int[][] board)
        {
            if (!board.Any()) return false;
            if (board.Length != board[0].Length) return false;

            for (int i = 0; i < board[0].Length; i++)
                if (!ValidateRow(board, i) || !ValidateColumn(board, i)) return false;

            for (int y = 0; y < 9; y += 3)
            {
                for (int x = 0; x < 9; x += 3)
                    if (!ValidateSquare(board, y, x))
                        return false;
            }

            return true;
        }

        private static bool ValidateRow(int[][] board, int row)
        {
            var sequence = new List<int>();
            sequence.AddRange(correctSample);

            foreach (var num in board[row])
                sequence.Remove(num);

            return !sequence.Any();
        }

        private static bool ValidateColumn(int[][] board, int column)
        {
            var sequence = new List<int>();
            sequence.AddRange(correctSample);

            var columnSequence = new List<int>();

            foreach (var row in board)
                columnSequence.Add(row[column]);

            foreach (var num in columnSequence)
                sequence.Remove(num);

            return !sequence.Any();
        }

        private static bool ValidateSquare(int[][] board, int row, int column)
        {
            var sequence = new List<int>();
            sequence.AddRange(correctSample);

            var squareSequence = new List<int>();

            for (int y = row; y < row + 3; y++)
            {
                for (int x = column; x < column + 3; x++)
                    squareSequence.Add(board[y][x]);
            }

            foreach (var num in squareSequence)
                sequence.Remove(num);

            return !sequence.Any();
        }
    }
}
