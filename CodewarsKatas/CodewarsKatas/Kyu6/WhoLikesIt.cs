namespace CodewarsKatas.CodewarsKatas.Kyu6
{
  //https://www.codewars.com/kata/who-likes-it/
  class WhoLikesIt
  {
    public static string Run(string[] names)
      => names != null ? GetNamesSequence(names) + " like" + (names.Length > 1 ? string.Empty : "s") + " this" : null;

    private static string GetNamesSequence(string[] names)
    {
      switch (names.Length)
      {
          case 0:
            return "no one";
          case 1:
            return names[0];
          case 2:
            return names[0] + " and " + names[1];
          case 3:
            return names[0] + ", " + names[1] + " and " + names[2];
          default:
            return names[0] + ", " + names[1] + " and " + (names.Length - 2) + " others";
      }
    }
  }
}
