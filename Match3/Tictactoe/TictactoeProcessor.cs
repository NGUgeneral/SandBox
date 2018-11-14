using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Match3.Tictactoe
{
    class TictactoeProcessor
    {
        private static CellOwner[,] Field;
        private static CellOwner Winner = CellOwner.None;
        private static CellOwner Player = CellOwner.None;
        private static bool BotMode;
        private static int Side;
        private static Random r = new Random();

        private TictactoeProcessor(int side)
        {
            Side = side;
            Field = GenerateEmptyField();
        }

        #region Core

        public static void StartGame(int side)
        {
            new TictactoeProcessor(side);
            Console.WriteLine("Wanna play with a bot? [y]");
            BotMode = Console.ReadKey().Key == ConsoleKey.Y;

            Console.WriteLine("Enter coordinate for a move divided by coma. For example: 1,3 (which would be column 1 of row 3). After that - press enter.");
            Player = CellOwner.X;
            for (int i = 0; i < Side * Side; i++)
            {
                DrawField();
                Console.WriteLine($"Player {Player} move.");

                if (Player == CellOwner.O && BotMode)
                    MakeBotMove();
                else
                    MakePlayerMove();

                ValidateField();
                if (Winner != CellOwner.None)
                    break;
                Player = GetOpponentSym(Player);
            }

            DrawField();
            var winner = Winner == CellOwner.None ? "Tie" : Winner.ToString();
            Console.WriteLine($"\nWinner is: {winner}");
        }

        private static void MakePlayerMove()
        {
            var coord = GetValidCoordinate();
            while (!RegisterMove(coord.Item1, coord.Item2, Player))
                coord = GetValidCoordinate();
        }

        #endregion

        #region Bot

        private static void MakeBotMove()
        {
            var emptyCells = GetEmptyCells();

            var selfMove = GetWinningMove(Player, emptyCells);
            if (selfMove.Item1 != -1)
            {
                RegisterMove(selfMove.Item1 + 1, selfMove.Item2 + 1, Player);
                return;
            }

            var opponentMove = GetWinningMove(GetOpponentSym(Player), emptyCells);
            if (opponentMove.Item1 != -1)
            {
                RegisterMove(opponentMove.Item1 + 1, opponentMove.Item2 + 1, Player);
                return;
            }

            var move = emptyCells[r.Next(0, emptyCells.Count)];
            RegisterMove(move.Item1 + 1, move.Item2 + 1, Player);
        }

        private static (int, int) GetWinningMove(CellOwner owner, List<(int, int)> emptyCells)
        {
            foreach (var cell in emptyCells)
            {
                Field[cell.Item1, cell.Item2] = owner;
                if (DetermineWinner() == owner)
                {
                    Field[cell.Item1, cell.Item2] = CellOwner.None;
                    return cell;
                }
                Field[cell.Item1, cell.Item2] = CellOwner.None;
            }

            return (-1, -1);
        }

        private static List<(int, int)> GetEmptyCells()
        {
            var coords = new List<(int, int)>();
            for (int x = 0; x < Side; x++)
            {
                for (int y = 0; y < Side; y++)
                {
                    if (Field[x, y] == CellOwner.None)
                        coords.Add((x, y));
                }
            }

            return coords;
        }

        #endregion

        #region Dialogs

        private static (int, int) GetValidCoordinate()
        {
            var input = Console.ReadLine();
            while (!ValidateCoordinateInput(input))
            {
                Console.WriteLine("Invalid coordinates");
                input = Console.ReadLine();
            }

            return ParseInputCoordinate(input);
        }

        private static bool ValidateCoordinateInput(string input)
            => Regex.IsMatch(input, $"([1-{Side}])(,)([1-{Side}])");

        private static (int, int) ParseInputCoordinate(string input)
        {
            var coords = input.Split(',');
            return (int.Parse(coords[0]), int.Parse(coords[1]));
        }

        #endregion

        #region Moves and Validation

        private static bool RegisterMove(int x, int y, CellOwner owner)
        {
            //Subtract 1 from inputs, since coordinates are zero based
            var cellOwner = GetCellOwner(x - 1, y - 1);
            if (cellOwner == 0)
            {
                Console.WriteLine("Invalid coordinates");
                return false;
            }
                

            if ((int)cellOwner > 1)
            {
                Console.WriteLine("This cell is already occupied");
                return false;
            }

            Field[x - 1, y - 1] = owner;
            return true;
        }

        private static void ValidateField()
            => Winner = DetermineWinner();

        private static CellOwner DetermineWinner()
        {
            //Validate rows
            for (int y = 0; y < Side; y++)
            {
                var sym = Field[0, y];
                for (int x = 1; x < Side; x++)
                {
                    if(Field[x,y] != sym)
                        break;
                    if (x == Side - 1)
                        return sym;
                }
            }

            //Validate columns
            for (int x = 0; x < Side; x++)
            {
                var sym = Field[x, 0];
                for (int y = 1; y < Side; y++)
                {
                    if (Field[x, y] != sym)
                        break;
                    if (y == Side - 1)
                        return sym;
                }
            }

            //validate lr diagonal
            for (int i = 0; i < Side; i++)
            {
                if(Field[i,i] != Field[0, 0])
                    break;
                if(i == Side - 1)
                    return Field[0, 0];
            }

            //validate rl diagonal
            for (int i = 0; i < Side; i++)
            {
                if (Field[Side - 1, i] != Field[Side - 1, 0])
                    break;
                if (i == 2)
                    return Field[Side - 1, 0];
            }

            return CellOwner.None;
        }

        private static CellOwner GetOpponentSym(CellOwner sym)
            => sym == CellOwner.O ? CellOwner.X : CellOwner.O;

        #endregion

        #region Field Draw, Cell Access and Generation

        private static void DrawField()
        {
            for (int y = 0; y < Side; y++)
            {
                for (int x = 0; x < Side; x++)
                {
                    var cellOwner = GetCellOwner(x, y);
                    var sym = (int)cellOwner > 1 ? cellOwner.ToString() : " ";
                    Console.Write(sym);
                    if (x < Side - 1) Console.Write("|");
                }

                if (y < Side - 1)
                {
                    Console.Write("\n");
                    var divider = new StringBuilder();
                    for (int i = 0; i < Side; i++)
                        divider.Append("- ");
                    Console.WriteLine(divider);
                }
            }
            Console.Write("\n");
        }

        private CellOwner[,] GenerateEmptyField()
        {
            var field = new CellOwner[Side,Side];

            for (int y = 0; y < Side; y++)
            {
                for (int x = 0; x < Side; x++)
                {
                    field[x, y] = CellOwner.None;
                }
            }

            return field;
        }

        private static CellOwner GetCellOwner(int x, int y)
            => x < 0 || x >= Side || y < 0 || y >= Side ? 0 : Field[x,y];

        #endregion
    }

    public enum CellOwner
    {
        None = 1,
        X = 2,
        O = 3
    }
}
