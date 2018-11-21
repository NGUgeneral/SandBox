using System;
using System.Collections.Generic;

namespace CodewarsKatas.CodewarsKatas.WIP.Kyu3
{
	internal class TotalAreaCoveredByRectangles
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
					//Nope, this is wrong logic. See CustomComplexTest for reference;
					rectangleArea -= GetIntersectionRectangleArea(rectangle, registeredRectangle);
					if (rectangleArea <= 0)
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

		private static long GetIntersectionRectangleArea(int[] r1, int[] r2)
		{
			var xi = GetLinesIntersection(r1[0], r1[2], r2[0], r2[2]);
			var yi = GetLinesIntersection(r1[1], r1[3], r2[1], r2[3]);

			return xi.Item1 < 0 || xi.Item2 < 0 || yi.Item1 < 0 || yi.Item2 < 0 ? 0 : CalculateRectangleArea(new[] { xi.Item1, yi.Item1, xi.Item2, yi.Item2 });
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