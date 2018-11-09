using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace SandBox.Tictactoe
{
    class TictactoeProcessor
    {
        private readonly List<Cell> Field;

        public TictactoeProcessor()
        {
            Field = GenerateEmptyField(3, 3);
            SetYWonField();
            DrawField();
        }

        #region Moves and Validation

        public bool RegisterMove(int x, int y, CellOwner owner)
        {
            //Subtract 1 from inputs, since coordinates are zero based
            var cell = Field.SingleOrDefault(c => c.ThisCell(x - 1, y - 1));
            if (cell == null)
            {
                Console.WriteLine("Invalid coordinate for a move");
                return false;
            }

            if (cell.Owner > 0)
            {
                Console.WriteLine("This cell is already occupied");
                return false;
            }

            cell.Owner = owner;
            return true;
        }

        #endregion

        #region Field Draw and Generation

        private void DrawField()
        {
            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    var sym = Field[i + j * 3].Owner > 0 ? Field[i + j * 3].Owner.ToString() : " ";
                    Console.Write(sym);
                    if (i < 2) Console.Write("|");
                }

                if (j < 2)
                {
                    Console.Write("\n");
                    Console.WriteLine("-----");
                }
            }
            Console.Write("\n");
        }

        private static List<Cell> GenerateEmptyField(int x, int y)
        {
            var field = new List<Cell>();
            var r = new Random();

            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    var cell = new Cell(j, i);
                    field.Add(cell);
                }
            }

            return field;
        }

        #endregion

        #region Test Area

        private List<Cell> GenerateRandomField(int width, int height)
        {
            var field = new List<Cell>();
            var r = new Random();

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    var owner = (CellOwner)r.Next(0, 3);
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
            RegisterMove(1, 1, CellOwner.X);
            RegisterMove(2, 1, CellOwner.O);
            RegisterMove(3, 1, CellOwner.X);
            RegisterMove(1, 2, CellOwner.O);
            RegisterMove(2, 2, CellOwner.X);
            RegisterMove(3, 2, CellOwner.X);
            RegisterMove(1, 3, CellOwner.O);
            RegisterMove(2, 3, CellOwner.X);
            RegisterMove(3, 3, CellOwner.O);
        }

        private void SetXWonField()
        {
            RegisterMove(1, 1, CellOwner.X);
            RegisterMove(3, 1, CellOwner.O);
            RegisterMove(3, 2, CellOwner.X);
            RegisterMove(3, 3, CellOwner.O);
            RegisterMove(1, 3, CellOwner.X);
            RegisterMove(2, 3, CellOwner.O);
            RegisterMove(1, 2, CellOwner.X);
        }

        private void SetYWonField()
        {
            RegisterMove(1, 1, CellOwner.O);
            RegisterMove(3, 1, CellOwner.X);
            RegisterMove(3, 2, CellOwner.O);
            RegisterMove(3, 3, CellOwner.X);
            RegisterMove(1, 3, CellOwner.O);
            RegisterMove(2, 3, CellOwner.X);
            RegisterMove(1, 2, CellOwner.O);
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
            None = 0,
            X = 1,
            O = 2
        }

        #endregion
    }
}
