using System;
using System.Collections.Generic;
using System.Linq;

namespace CodewarsKatas.CodewarsKatas.Kyu5
{
	//https://www.codewars.com/kata/int32-to-ipv4/train/csharp
	internal class Int32ToIPv4
	{
		public static string UInt32ToIP(uint ip)
		{
			var result = new List<string>();

			foreach (var part in BitConverter.GetBytes(ip).Reverse())
				result.Add(part.ToString());

			return string.Join(".", result);
		}
	}
}