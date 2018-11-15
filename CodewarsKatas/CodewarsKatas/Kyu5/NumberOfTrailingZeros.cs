namespace CodewarsKatas.CodewarsKatas.Kyu5
{
    class NumberOfTrailingZeros
    {
        //https://www.codewars.com/kata/number-of-trailing-zeros-of-n/train/csharp
        public static int Run(int n)
        {
            var result = 0;

            for (int i = 5; i <= n; i *= 5)
                result += n / i;

            return result;
        }
    }
}
