using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MusicLibrary.Dal.Utils
{
    public static class UrlIdGenerator
    {
        public static string Generate(string name, IList<string> uniqueNames)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException(nameof(name));
            if (uniqueNames == null) throw new ArgumentNullException(nameof(uniqueNames));

            name = Regex.Replace(name, "[^A-Za-z-0-9 ]", "");
            name = name.ToLower().Trim();
            name = Regex.Replace(name, "[\\s]+", "-");

            if (name == string.Empty)
            {
                var rand = new Random();
                while (uniqueNames.Contains(name))
                {
                    name = GetRandomHexString(1, long.MaxValue, rand);
                }
                return name;
            }
            
            if (!uniqueNames.Contains(name))
            {
                return name;
            }

            var builder = new StringBuilder(name.Length + int.MaxValue.ToString().Length + 1);

            for (var i = 1; i < int.MaxValue; i++)
            {
                var result = builder
                    .Append(name)
                    .Append("-")
                    .Append(i)
                    .ToString();

                if (!uniqueNames.Contains(result))
                {
                    return result;
                }

                builder.Clear();
            }

            return name;
        }

        private static string GetRandomHexString(long min, long max, Random rand)
        {
            var buf = new byte[8];
            rand.NextBytes(buf);
            var longRand = BitConverter.ToInt64(buf, 0);
            return (Math.Abs(longRand % (max - min)) + min).ToString("X");
        }
    }
}
