using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantingTrees
{
    class Program
    {
        public static void BubleSort(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length-1; j++)
                {
                    if (nums[j] < nums[j+1])
                    {
                        var temp = nums[j];
                        nums[j] = nums[j + 1];
                        nums[j + 1] = temp;
                    }
                }
            }
        }

        public static int CalculatePartyTime(int[] trees)
        {
            var max = 0;
            for (int i = 0; i < trees.Length; i++)
            {
                if (trees[i] + (i+1) > max)
                {
                    max = trees[i] + (i+1);
                }
            }
            return max + 1;
        }
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllLines("trees.2.in");
            int treesNo =int.Parse(lines[0]);

            var treesArray = lines[1].Split(new char[0]).ToArray();
            var intArray = new int[treesNo];

            for (int i = 0; i < treesArray.Length; i++)
            {
                
                    intArray[i] = int.Parse(treesArray[i]);

                
            }
            BubleSort(intArray);
            Console.WriteLine(CalculatePartyTime(intArray));
        }
    }
}
