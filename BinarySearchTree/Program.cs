using System;

namespace BinarySearchTree
{
    class Program
    {

        static bool LinearSearch(double[] nums, double n)
        {
            foreach (var num in nums)
            {
                if (num == n)
                {
                    return true;
                }
            }
            return false;
        }
        static double[] CreateRandomDoubleArray(int n)
        {
            var rand = new Random();
            double[] ret = new double[n];
            for (int i = 0; i < n; i++)
            {
                ret[i] = rand.Next(0, 100000);
            }
            return ret;
        }

        static void TestTree(int n)
        {
            var rand = new Random();
            double[] nums = CreateRandomDoubleArray(n);
            int index = rand.Next(0, n - 1);
            var tree = new BinaryTree(nums);

            var timer = new System.Diagnostics.Stopwatch();
            timer.Start();
            tree.SearchTree(nums[index]);
            timer.Stop();
            Console.WriteLine($"Binary Tree Search: {timer.ElapsedTicks} ticks");
            timer.Restart();
            LinearSearch(nums, nums[index]);
            timer.Stop();
            Console.WriteLine($"Linear Search: {timer.ElapsedTicks} ticks");
        }
        static void Main(string[] args)
        {
            TestTree(10000000);
        }
    }
}
