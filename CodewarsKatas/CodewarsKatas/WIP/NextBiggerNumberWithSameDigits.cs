namespace CodewarsKatas.CodewarsKatas.WIP
{
	internal class NextBiggerNumberWithSameDigits
	{
		public static long NextBiggerNumber(long n)
		{
			for (int j = n.ToString().Length - 1; j > 0; j--)
			{
				var word = n.ToString();

				for (int i = j; i > 0; i--)
				{
					var c = word[i].ToString();
					word = word.Remove(i, 1).Insert(i - 1, c);
					long.TryParse(word, out var result);
					if (result > n) return result;
				}
			}

			return -1;
		}
	}
}