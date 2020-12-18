using System;
using System.IO;
using System.Collections.Generic;

namespace day1
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = ReadInput(@"/home/codespace/workspace/day1/input.txt");
            numbers.Sort();
            Console.WriteLine(numbers.Count);
            for(int i = 0; i < numbers.Count - 1; i++)
            {
                for(int x = i; x < numbers.Count - 1; x++)
                {
                    for(int j = numbers.Count - 1; j >= 0; j--)
                    {
                        var sum = numbers[i] + numbers[j] + numbers[x];
                        if(sum == 2020)
                        {
                            Console.WriteLine(numbers[i] * numbers[j] * numbers[x]);
                            return;
                        }
                        if(sum < 2020)
                        { 
                            break;
                        }
                    }
                }
            }
        }

        public static List<int> ReadInput(string path)
        {
            var numbers = new List<int>();
            using var reader = new StreamReader(path);
            var value = reader.ReadLine();
            while(value != null)
            {
                numbers.Add(Convert.ToInt32(value));
                value = reader.ReadLine();
            }

            return numbers;
        }
    }
}
