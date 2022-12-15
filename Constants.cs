using System;
using System.Linq;

namespace ParaBankPractice
{
    public static class Constants
    {
        public const int TimeoutInSeconds = 30;
        private static Random Random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[Random.Next(s.Length)]).ToArray());
        }
    }
}