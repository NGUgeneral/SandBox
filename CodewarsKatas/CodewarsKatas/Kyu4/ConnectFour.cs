using System;
using System.Collections.Generic;
using System.Text;

namespace CodewarsKatas.CodewarsKatas.Kyu4
{
	internal class ConnectFour
	{
		private static List<List<Cell>> Field;
		public static string Run(IEnumerable<string> moves)
		{
			Field = GenerateEmptyField();

			foreach (var move in moves)
				if (RegisterMove(CharToIndexMap[move[0]], move[2] == 'R' ? Cell.Red : Cell.Yellow))
					return $"{move.Substring(2)}";

			DrawField();

			return "Draw";
		}

		private static void DrawField()
		{
			for (int i = 0; i < Field.Count; i++)
			{
				var row = new StringBuilder();
				foreach (var c in Field[i])
				{
					var t = c.Equals(Cell.Red) ? 'R' :
									c.Equals(Cell.Yellow) ? 'Y' :
									' ';
					row.Append(t);
				}

				Console.WriteLine(row);
			}
		}

		private static bool RegisterMove(int column, Cell cell)
		{
			for (int i = Field.Count - 1; i >= 0; i--)
			{
				if (Field[i][column].Equals(Cell.Empty))
				{
					Field[i][column] = cell;
					return ValidateField(i, column, cell);
				}
			}

			return false;
		}

		private static bool ValidateField(int row, int column, Cell cell)
		{
			return ValidateColumn(column, cell) ||
			       ValidateRow(row, cell) ||
			       ValidateDiagonalLeft(row, column, cell) ||
			       ValidateDiagonalRight(row, column, cell);
		}

		private static bool ValidateColumn(int column, Cell cell)
		{
			if (Field[3][column].Equals(Cell.Empty))
				return false;

			var counter = 0;
			foreach (var row in Field)
			{
				counter = row[column].Equals(cell) ? counter + 1 : 0;
				if (counter > 3)
					return true;
			}

			return false;
		}

		private static bool ValidateRow(int row, Cell cell)
		{
			if (!Field[row][3].Equals(cell))
				return false;

			var counter = 0;
			foreach (var column in Field[row])
			{
				counter = column.Equals(cell) ? counter + 1 : 0;
				if (counter > 3)
					return true;
			}

			return false;
		}

		private static bool ValidateDiagonalLeft(int row, int column, Cell cell)
		{
			while (row + 1 < 6 && column - 1 > 0)
			{
				row++;
				column--;
			}

			var counter = 0;
			while (row - 1 >= 0 && column + 1 < 7)
			{
				if (Field[row][column].Equals(cell))
					counter++;

				if (counter > 3)
					return true;
				row--;
				column++;
			}

			return false;
		}

		private static bool ValidateDiagonalRight(int row, int column, Cell cell)
		{
			while (row + 1 < 6 && column + 1 < 7)
			{
				row++;
				column++;
			}

			var counter = 0;
			while (row - 1 >= 0 && column - 1 >= 0)
			{
				if (Field[row][column].Equals(cell))
					counter++;

				if (counter > 3)
					return true;
				row--;
				column--;
			}

			return false;
		}

		private static List<List<Cell>> GenerateEmptyField()
		{
			return new List<List<Cell>>
			{
				new List<Cell>{ 0, 0, 0, 0, 0, 0, 0 },
				new List<Cell>{ 0, 0, 0, 0, 0, 0, 0 },
				new List<Cell>{ 0, 0, 0, 0, 0, 0, 0 },
				new List<Cell>{ 0, 0, 0, 0, 0, 0, 0 },
				new List<Cell>{ 0, 0, 0, 0, 0, 0, 0 },
				new List<Cell>{ 0, 0, 0, 0, 0, 0, 0 }
			};
		}

		private static readonly Dictionary<char, int> CharToIndexMap = new Dictionary<char, int>
		{
			{'A', 0},
			{'B', 1},
			{'C', 2},
			{'D', 3},
			{'E', 4},
			{'F', 5},
			{'G', 6}
		};

		private enum Cell
		{
			Empty = 0,
			Red = 1,
			Yellow = 2
		}
	}
}