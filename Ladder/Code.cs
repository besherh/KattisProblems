using System;

namespace Ladder
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var readLine = Console.ReadLine();
                if (readLine == null) return;
                var input = readLine.Split(new char[0]);
                var h = int.Parse(input[0]);
                var v = int.Parse(input[1]);
                if ((h >= 1 && h <= 10000) && (v >= 1 && v <= 89))
                {
                    var result = Math.Ceiling(CalculateMinLength(h, v));
                    Console.WriteLine(result);
                }
            }
            catch (Exception ex)
            {
            }
        }

        public static double CalculateMinLength(int h, int v)
        {
            return (h/Math.Sin(ConvertToRadians(v)));
        }

        public static double ConvertToRadians(double a)
        {
            return (Math.PI/180)*a;
        }
    }
}
