using System.Linq;

namespace CodewarsKatas.CodewarsKatas.Kyu6
{
    //https://www.codewars.com/kata/plus-1-array
    public class PlusOneArray
    {
        public static int[] Run(int[] arg)
        {
            if (arg == null || !arg.Any() || arg.Any(x => x < 0 || x > 9))
                return null;

            var buffer = 0;
            for (int i = arg.Length - 1; i >= 0; i--)
            {
                var t = i == arg.Length - 1 ? arg[i] + 1 + buffer : arg[i] + buffer;
                if (t > 9)
                {
                    arg[i] = t - 10;
                    buffer = 1;
                }
                else
                {
                    arg[i] = t;
                    buffer = 0;
                    break;
                }
            }

            if (buffer > 0)
            {
                var holder = arg.ToList();
                holder.Insert(0, buffer);
                arg = holder.ToArray();
            }

            return arg;
        }
    }
}
