using System.Linq;

namespace CodewarsKatas.CodewarsKatas.Kyu5
{
	//https://www.codewars.com/kata/greed-is-good/train/csharp
	internal class GreedIsGood
	{
		public static int Score(int[] dice)
		{
			int result = 0;

			for (int i = 1; i < 7; i++)
			{
				var count = dice.Count(x => x == i);
				switch (i)
				{
					case 1:
						result += 1000 * (count / 3) + 100 * (count % 3);
						break;

					case 6:
						result += 600 * (count / 3);
						break;

					case 5:
						result += 500 * (count / 3) + 50 * (count % 3);
						break;

					case 4:
						result += 400 * (count / 3);
						break;

					case 3:
						result += 300 * (count / 3);
						break;

					case 2:
						result += 200 * (count / 3);
						break;
				}
			}

			return result;
		}
	}
}