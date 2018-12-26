namespace CodewarsKatas.CodewarsKatas.Kyu6
{
  class SimpleFun79
  {
    // https://www.codewars.com/kata/simple-fun-number-79-delete-a-digit/train/csharp
    public static int DeleteDigit(int n)
    {
      var result = 0;
      var num = n.ToString();

      for (int i = 0; i < num.Length; i++)
      {
        var temp = int.Parse(num.Substring(0, i) + num.Substring(i + 1));
        if (temp > result)
          result = temp;
      }

      return result;
    }
  }
}
