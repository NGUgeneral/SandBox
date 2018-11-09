using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SandBox.Tictactoe
{
    class TictactoeProcessor
    {
        private readonly List<Cell> Field;
        private readonly int Side;

        public TictactoeProcessor(int side)
        {
            Side = side;
            Field = GenerateEmptyField(side);
            SetTieField();
            DrawField();
        }

        #region Moves and Validation

        public bool RegisterMove(int x, int y, CellOwner owner)
        {
            //Subtract 1 from inputs, since coordinates are zero based
            var cell = GetCell(x - 1, y - 1);
            if (cell == null)
                return false;

            if ((int)cell.Owner > 1)
            {
                Console.WriteLine("This cell is already occupied");
                return false;
            }

            cell.Owner = owner;
            return true;
        }

        private bool ValidateField()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Field Draw, Cell Access and Generation

        private void DrawField()
        {
            for (int j = 0; j < Side; j++)
            {
                for (int i = 0; i < Side; i++)
                {
                    var sym = (int)Field[i + j * Side].Owner > 1 ? Field[i + j * Side].Owner.ToString() : " ";
                    Console.Write(sym);
                    if (i < Side - 1) Console.Write("|");
                }

                if (j < Side - 1)
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

        private static List<Cell> GenerateEmptyField(int side)
        {
            var field = new List<Cell>();
            var r = new Random();

            for (int i = 0; i < side; i++)
            {
                for (int j = 0; j < side; j++)
                {
                    var cell = new Cell(j, i);
                    field.Add(cell);
                }
            }

            return field;
        }

        private Cell GetCell(int x, int y)
        {
            var cell = Field.FirstOrDefault(c => c.ThisCell(x, y));
            if (cell == null) throw new Exception("Invalid coordinate");

            return cell;
        }

        #endregion

        #region Test Area

        private List<Cell> GenerateRandomField(int side)
        {
            var field = new List<Cell>();
            var r = new Random();

            for (int i = 0; i < side; i++)
            {
                for (int j = 0; j < side; j++)
                {
                    var owner = (CellOwner)r.Next(0, Side);
                    var cell = new Cell(j, i)
                    {
                        Owner = owner
                    };

                    field.Add(cell);
                }
            }

            return field;
        }

        private void SetTieField()
        {
            var init = CellOwner.X;
            var d = 0;
            for (int y = 1; y < Side + 1; y++)
            {
                if (d == 1)
                {
                    init = init == CellOwner.X ? CellOwner.O : CellOwner.X;
                    d = 0;
                }   
                else
                {
                    d++;
                }

                for (int x = 1; x < Side + 1; x++)
                {
                    var sym = x % 2 == 0 ? init : GetOpponentSym(init);
                    RegisterMove(x, y, sym);
                }
            }
        }

        private static CellOwner GetOpponentSym(CellOwner sym)
            => sym == CellOwner.O ? CellOwner.X : CellOwner.O;

        private void SetXWonField()
        {
            for (int i = 1; i < Side + 1; i++)
                RegisterMove(i, i, CellOwner.X);
        }

        private void SetOWonField()
        {
            for (int i = 1; i < Side + 1; i++)
                RegisterMove(i, i, CellOwner.O);
        }

        #endregion

        #region Nested Classes

        private class Coord
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        private class Cell
        {
            private Coord Coordinate { get; }
            public CellOwner Owner { get; set; }

            public bool ThisCell(int x, int y)
                => Coordinate.X.Equals(x) && Coordinate.Y.Equals(y);

            public Cell(int x, int y)
            {
                Coordinate = new Coord
                {
                    X = x,
                    Y = y
                };
            }
        }

        public enum CellOwner
        {
            None = 1,
            X = 2,
            O = 3
        }

        #endregion
    }
}
