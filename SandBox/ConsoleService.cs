using System;
using System.Collections.Generic;
using System.Text;

namespace SandBox
{
    class ConsoleService
    {
        public ConsoleService()
        {
            
            Console.WriteLine("\nPress any key to exit ...");
            Console.ReadKey();
        }

        //Console.WriteLine(GetBitString("01100110011101010110001101101011", 8));
        private string GetBitString(string s, int bitLength)
        {
            var bytesPairs = GetBytesFromString(s, bitLength);
            var word = new StringBuilder();

            foreach (var bytesPair in bytesPairs)
            {
                var byteArr = new[] { bytesPair.Item1, bytesPair.Item2 };
                word.Append(BitConverter.ToChar(byteArr, 0));
            }

            return word.ToString();
        }

        private List<(byte, byte)> GetBytesFromString(string s, int bitLength)
        {
            var bytes = new List<(byte, byte)>();
            for (int j = 0; j < s.Length / bitLength; j++)
            {
                var tuple = new string[2];
                for (int c = 0; c < bitLength / 8; c++)
                {
                    var word = new StringBuilder();
                    for (int i = 0; i < 8; i++)
                    {

                        word.Append(s[bitLength * j + bitLength / 8 * c + i]);
                    }

                    tuple[c] = word.ToString();
                }
                bytes.Add((Convert.ToByte(tuple[0], 2), Convert.ToByte(tuple[1], 2)));
            }

            return bytes;
        }
    }
}
