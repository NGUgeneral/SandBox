using System.Collections.Generic;

namespace CodewarsKatas.CodewarsKatas.WIP.Kyu3
{
	internal class TotalAreaCoveredByRectangles
	{
		public static long Run(IEnumerable<int[]> rectangles)
		{
		  var area = 0;
			return area;
		}

	  public static IEnumerable<int[]> CutOutRectangle(int[] rectangle, int[] blade)
	  {
	    var split = new List<int[]>();
	    return null;
	  }

   // public static IEnumerable<int[]> CutRectangleByLine(int[] rectangle, int? x, int? y)
	  //{
	  //  if (x != null)
	  //  {

	  //  }

	  //  if (y != null)
	  //  {

	  //  }
	  //}

	  private static IEnumerable<int[]> CutOnX(int[] r, int x)
	  {
	    if (x <= r[0] || x >= r[2])
	      yield return r;

	    yield return new[] { r[0], r[1], x, r[3] };
	    yield return new[] { x, r[1], r[2], r[3] };
	  }

	  private static IEnumerable<int[]> CutOnY(int[] r, int y)
	  {
	    if (y <= r[1] || y >= r[3])
	      yield return r;

	    yield return new[] { r[0], r[1], r[2], y };
	    yield return new[] { r[0], y, r[2], r[3] };
	  }

	  public static long GetRectangleArea(int[] r)
	    => (r[2] - r[0])*(r[3] - r[1]);
	}
}