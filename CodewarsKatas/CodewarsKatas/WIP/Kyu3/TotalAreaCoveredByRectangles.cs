using System;
using System.Collections.Generic;
using System.Linq;

namespace CodewarsKatas.CodewarsKatas.WIP.Kyu3
{
    class TotalAreaCoveredByRectangles
    {
        //Works but required optimization, since solution falls out with timeout;
        public static long Calculate(IEnumerable<int[]> rectangles)
        {
            var area = 0L;
            var registeredRectangles = new List<int[]>();

            foreach (var rectangle in rectangles)
            {
                var rectangleArea = CalculateRectangleArea(rectangle);

                foreach (var registeredRectangle in registeredRectangles)
                {
                    rectangleArea -= CalculateRectangleArea(GetIntersectionRectangle(rectangle, registeredRectangle));
                    if (rectangleArea < 0)
                    {
                        rectangleArea = 0;
                        break;
                    }
                }

                area += rectangleArea;
                registeredRectangles.Add(rectangle);
            }
            
            return area;
        }

        private static long CalculateRectangleArea(int[] r)
            => (r[2] - r[0]) * (r[3] - r[1]);

        private static int[] GetIntersectionRectangle(int[] r1, int[] r2)
        {
            var result = new int[4];

            var xi = GetLinesIntersection(r1[0], r1[2], r2[0], r2[2]);
            var yi = GetLinesIntersection(r1[1], r1[3], r2[1], r2[3]);

            result[0] = xi.Item1;
            result[2] = xi.Item2;
            result[1] = yi.Item1;
            result[3] = yi.Item2;

            return result.Any(x => x < 0) ? new int[4] : result;
        }

        private static Tuple<int, int> GetLinesIntersection(int a1, int a2, int b1, int b2)
        {
            var c1 = -1;
            var c2 = -1;

            if (a1 >= b1 && a1 <= b2)
            {
                c1 = a1;
            }
            else if (b1 >= a1 && b1 <= a2)
            {
                c1 = b1;
            }

            if (a2 >= b1 && a2 <= b2)
            {
                c2 = a2;
            }
            else if (b2 >= a1 && b2 <= a2)
            {
                c2 = b2;
            }

            return new Tuple<int, int>(c1, c2);
        }
    }
}
