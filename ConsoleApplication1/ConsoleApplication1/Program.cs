using System;
using static System.Console;

namespace CSharp7DemoKV
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             *  General notes: 
             *  Tuple type -> System.ValueTuple
             *  You are not allowed to change the order of Item1, Item2 etc.
             */

            WriteLine("---- Step 1 ----");
            step1.Run();
            WriteLine("\n");

            WriteLine("---- Step 2 ----");
            step2.Run();
            WriteLine("\n");

            WriteLine("---- Step 3 ----");
            step3.Run();
            WriteLine("\n");

            WriteLine("---- Step 4 ----");
            step4.Run();
            WriteLine("\n");

            WriteLine("---- Step 5 ----");
            step5.Run();
            WriteLine("\n");

            WriteLine("---- Step 6 ----");
            step6.Run();
            WriteLine("\n");
        }
    }

    static class step1
    {
        public static void Run()
        {
            // 1. Binary literals mode in C# 7
            int[] numbers = { 0b1, 0b10, 0b100, 0b1000, 0b1_0000, 0b10_0000 };
            
            // 2. Deep analysis, count the numbers and add them up
            var t = Tally(numbers);
            WriteLine($"sum: {t.Item1}, count: {t.Item2}");
        }
        
        private static (int, int) Tally(Int32[] numbers)
        {
            return (0, 0);
        }
    }

    static class step2
    {
        public static void Run()
        {
            int[] numbers = { 0b1, 0b10, 0b100, 0b1000, 0b1_0000, 0b10_0000 };
            var t = Tally(numbers);
            WriteLine($"sum: {t.Item1}, count: {t.Item2}");
        }
        
        private static (int, int) Tally(Int32[] numbers)
        {
            return (s:0, C:0);
        }
    }

    static class step3
    {
        public static void Run()
        {
            int[] numbers = { 0b1, 0b10, 0b100, 0b1000, 0b1_0000, 0b10_0000 };
            var t = Tally(numbers);
            WriteLine($"sum: {t.Item1}, count: {t.Item2}");
        }

        private static (int, int) Tally(Int32[] numbers)
        {
            return (s: 0, C: 0);
        }
    }

    static class step4
    {
        public static void Run()
        {
            int[] numbers = { 0b1, 0b10, 0b100, 0b1000, 0b1_0000, 0b10_0000 };
            var t = Tally(numbers);
            WriteLine($"sum: {t.sum}, count: {t.count}");
        }

        private static (int sum, int count) Tally(Int32[] numbers)
        {
            var r = (s: 0, c: 0);
            return r;
        }
    }

    static class step5
    {
        public static void Run()
        {
            int[] numbers = { 0b1, 0b10, 0b100, 0b1000, 0b1_0000, 0b10_0000 };

            // Deconstrution of tuples
            var (sum, count) = Tally(numbers);

            // Using variables from deconstructed tuple
            WriteLine($"sum: {sum}, count: {count}");
        }

        private static (int sum, int count) Tally(Int32[] numbers)
        {
            var r = (s: 0, c: 0);
            foreach (var v in numbers)
            {
                //r = (r.s + v, r.c + 1);
                // Because s and c are just public fields
                r.s += v; r.c++;
            }
            return r;
        }
    }

    static class step6
    {
        public static void Run()
        {
            int[] numbers = { 0b1, 0b10, 0b100, 0b1000, 0b1_0000, 0b10_0000 };

            // Deconstrution of tuples
            var (sum, count) = Tally(numbers);

            // Using variables from deconstructed tuple
            WriteLine($"sum: {sum}, count: {count}");
        }

        private static (int sum, int count) Tally(Int32[] numbers)
        {
            var r = (s: 0, c: 0);
            foreach (var v in numbers)
            {
                // Local method use
                Add(v, 1);
            }
            return r;

            // Local method
            void Add(int s, int c) { r = (r.s + s, r.c + c); }
        }
    }

    static class step7
    {
        public static void Run()
        {
            // Making number an array of objects
            object[] numbers = { 0b1, 0b10, new object[] { 0b100, 0b1000, 0b1_0000 }, null, 0b10_0000 };

            var (sum, count) = Tally(numbers);
            WriteLine($"sum: {sum}, count: {count}");
        }

        private static (int sum, int count) Tally(object[] numbers)
        {
            var r = (s: 0, c: 0);
            foreach(var v in numbers)
            {
                // Pattern matching: Checking type and assigning value to variable
                // If it is an int, I can extract the value
                if (v is int i)
                {
                    Add(i, 1);
                }
            }
            return r;
            void Add(int s, int c) { r = (r.s + s, r.c + c); }
        }
    }

    static class step8
    {
        public static void Run()
        {
            // Making number an array of objects
            object[] numbers = { 0b1, 0b10, new object[] { 0b100, 0b1000, 0b1_0000 }, null, 0b10_0000 };

            var (sum, count) = Tally(numbers);
            WriteLine($"sum: {sum}, count: {count}");
        }

        private static (int sum, int count) Tally(object[] numbers)
        {
            var r = (s: 0, c: 0);
            foreach (var v in numbers)
            {
                // Pattern matching in switch
                switch(v)
                {
                    case int i:
                        Add(i, 1);
                        break;
                    case object[] a when a.Length > 0:
                        var t = Tally(a);
                        Add(t.sum, t.count);
                        break;
                }
            }
            return r;
            void Add(int s, int c) { r = (r.s + s, r.c + c); }
        }
    }
}
