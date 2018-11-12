using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SandBox.Tictactoe
{
    class TictactoeProcessor
    {
        private static CellOwner[,] Field;
        private static CellOwner Winner = CellOwner.None;
        private static CellOwner Player = CellOwner.None;
        private static int Side;
        private static Random r = new Random();

        private TictactoeProcessor(int side)
        {
            Side = side;
            Field = GenerateEmptyField();
        }

        public static void StartGame(int side)
        {
            new TictactoeProcessor(side);
            Console.WriteLine("Enter coordinate for a move divided by coma. For example: 1,3 (which would be column 1 of row 3). After that - press enter.");
            Player = CellOwner.X;
            for(int i = 0; i < Side*Side; i++)
            {
                DrawField();
                Console.WriteLine($"Player {Player} move.");

                if (Player == CellOwner.X)
                {   
                    var coord = GetValidCoordinate();
                    while (!RegisterMove(coord.Item1, coord.Item2, Player))
                        coord = GetValidCoordinate();
                }
                else
                {
                    MakeBotMove(CellOwner.O);
                }

                ValidateField();
                if (Winner != CellOwner.None)
                    break;
                Player = GetOpponentSym(Player);
            }

            DrawField();
            var winner = Winner == CellOwner.None ? "Tie" : Winner.ToString();
            Console.WriteLine($"\nWinner is: {winner}");
        }

        #region Bot

        private static void MakeBotMove(CellOwner player)
        {
            var emptyCells = GetEmptyCells();

            var selfMove = GetWinningMove(player, emptyCells);
            if (selfMove.Item1 != -1)
            {
                RegisterMove(selfMove.Item1 + 1, selfMove.Item2 + 1, player);
                return;
            }

            var opponentMove = GetWinningMove(GetOpponentSym(player), emptyCells);
            if (opponentMove.Item1 != -1)
            {
                RegisterMove(opponentMove.Item1 + 1, opponentMove.Item2 + 1, player);
                return;
            }

            var move = emptyCells[r.Next(0, emptyCells.Count)];
            RegisterMove(move.Item1 + 1, move.Item2 + 1, player);
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

        #region Test Area

        private CellOwner[,] GenerateRandomField()
        {
            var field = new CellOwner[Side, Side];

            for (int y = 0; y < Side; y++)
            {
                for (int x = 0; x < Side; x++)
                    field[x, y] = r.Next(1, 3) % 2 == 0 ? CellOwner.X : CellOwner.O;
            }

            return field;
        }

        private void SetTieField()
        {
            var init = CellOwner.X;
            var i = 0;
            for (int y = 1; y < Side + 1; y++)
            {
                if (i == 1)
                {
                    init = init == CellOwner.X ? CellOwner.O : CellOwner.X;
                    i = 0;
                }   
                else
                {
                    i++;
                }

                for (int x = 1; x < Side + 1; x++)
                {
                    var sym = x % 2 == 0 ? init : GetOpponentSym(init);
                    RegisterMove(x, y, sym);
                }
            }
        }

        

        private void SetXWonLrDiagonalField()
        {
            for (int i = 1; i < Side + 1; i++)
                RegisterMove(i, i, CellOwner.X);
        }

        private void SetXWonRlDiagonalField()
        {
            for (int i = 1; i < Side + 1; i++)
                RegisterMove(Side + 1 - i, i, CellOwner.X);
        }

        private void SetXWonRowField()
        {
            for (int i = 1; i < Side + 1; i++)
                RegisterMove(i, 1, CellOwner.X);
        }

        private void SetOWonColumnField()
        {
            for (int i = 1; i < Side + 1; i++)
                RegisterMove(1, i, CellOwner.O);
        }

        private void SetOWonDiagonalField()
        {
            for (int i = 1; i < Side + 1; i++)
                RegisterMove(i, i, CellOwner.O);
        }

        private void SetVShape()
        {
            RegisterMove(1, 1, CellOwner.O);
            RegisterMove(2, 2, CellOwner.O);
            RegisterMove(3, 1, CellOwner.O);
        }

        #endregion
    }

    public enum CellOwner
    {
        None = 1,
        X = 2,
        O = 3
    }
}
