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

        static double[] TestTree(int n, double[] nums)
        {
            var rand = new Random();
            
            
            var tree = new BinaryTree(nums);
            double[] times = new double[2];
            int index = rand.Next(0, n - 1);
            //index = n - 1;
            var timer = new System.Diagnostics.Stopwatch();
            timer.Start();
            tree.SearchTree(nums[index]);
            timer.Stop();
            //Console.WriteLine("Binary Tree Search: {0} ticks", timer.ElapsedTicks);
            times[0] = timer.ElapsedTicks;
            timer.Restart();
            LinearSearch(nums, nums[index]);
            timer.Stop();
            //Console.WriteLine("Linear Search: {0} ticks", timer.ElapsedTicks);
            times[1] = timer.ElapsedTicks;
            return times;
        }
        static void Main(string[] args)
        {
            double[] times = new double[] { 0, 0 };
            int n = 100000;
            int num_iter = 100;
            double[] nums = CreateRandomDoubleArray(n);
            for (int i = 0; i < num_iter; i++)
            {
                double[] time = TestTree(n, nums);
                times[0] += time[0];
                times[1] += time[1];
            }
            times[0] = times[0] / num_iter;
            times[1] = times[1] / num_iter;
            Console.WriteLine("Average Binary Search: {0} ticks", times[0]);
            Console.WriteLine("Average Linear Search: {0} ticks", times[1]);
            Console.ReadLine();
        }
    }
}
