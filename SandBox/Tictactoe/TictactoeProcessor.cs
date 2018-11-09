using System;
using System.Collections.Generic;

namespace SandBox.Tictactoe
{
    class TictactoeProcessor
    {
        private readonly List<Cell> Field;

        public TictactoeProcessor()
        {
            Field = GenerateEmptyField(3, 3);
            DrawField();
        }



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



        private List<Cell> GenerateRandomField(int x, int y)
        {
            var field = new List<Cell>();
            var r = new Random();

            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
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

            public Cell(int x, int y)
            {
                Coordinate = new Coord
                {
                    X = x,
                    Y = y
                };
            }
        }

        private enum CellOwner
        {
            None = 0,
            X = 1,
            O = 2
        }

        #endregion
    }
}
