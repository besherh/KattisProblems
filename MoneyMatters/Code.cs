using System;
using System.Collections.Generic;

namespace MoneyMatters
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var moneyMatters = new MoneyMatters();
                moneyMatters.Possible = true;
                moneyMatters.Intialize();
                if (moneyMatters.Decide())
                {
                    Console.WriteLine("POSSIBLE");

                }
                else
                {
                    Console.WriteLine("IMPOSSIBLE");

                }
            }
            catch (Exception ex)
            {
            }
        }

        public class MoneyMatters
        {
            public int DebtLength { get; set; }
            public int FriendLength { get; set; }
            public int[] DebtsArray { get; set; }
            bool[] Scanned;
            public bool Possible { get; set; }
            public long Total { get; set; }

            int[][] JaggedArray;
            public void Intialize()
            {
                string readLine = Console.ReadLine();
                if (readLine != null)
                {
                    string[] input = readLine.Split(new char[0]);
                    DebtLength = int.Parse(input[0]);
                    FriendLength = int.Parse(input[1]);
                }
                DebtsArray = new int[10000];
                //  JaggedArray = CreateJaggedArray<int[][]>(DebtLength,DebtLength);
                JaggedArray = new int[10000][];
                for (int i = 0; i < 10000; i++)
                {
                    JaggedArray[i] = new int[10000];
                }
                Scanned = new bool[10000];
                for (int i = 0; i < DebtLength; i++)
                {
                    int debt = int.Parse(Console.ReadLine());
                    DebtsArray[i] = debt;
                    Scanned[i] = false;
                }
                for (int i = 0; i < FriendLength; i++)
                {
                    string[] couple = Console.ReadLine().Split(new char[0]);
                    var a = int.Parse(couple[0]);
                    var b = int.Parse(couple[1]);
                    JaggedArray[a][b] = b;
                    JaggedArray[b][a] = a;

                }
               
            }
            void TraverseStructure(int node)
            {
                if (Scanned[node])
                    return;
                Scanned[node] = true;
                Total += DebtsArray[node];
                for (int i = 0; i < DebtLength; ++i)
                {
                    if (!Scanned[JaggedArray[node][i]])
                        TraverseStructure(JaggedArray[node][i]);
                }
            }
            public bool Decide()
            {
                Possible = true;
                for (int i = 0; i < DebtLength; ++i)
                {
                    Total = 0;
                    TraverseStructure(i);
                    if (Total != 0)
                    {
                        Possible = false;
                        break;
                    }
                }
                return Possible;
            }
        }
    }
}
