using System;
using System.Collections.Generic;
using System.IO;

namespace day3_part1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            var slopeLines = ReadInput("/home/codespace/workspace/day3/part1/day3_part1/input.txt");
            Console.WriteLine(slopeLines.Count);
            var total_1 = NbTreeForSlope(1,1, slopeLines);
            var total_2 = NbTreeForSlope(1,3, slopeLines);
            var total_3 = NbTreeForSlope(1,5, slopeLines);
            var total_4 = NbTreeForSlope(1,7, slopeLines);
            var total_5 = NbTreeForSlope(2,1, slopeLines);
            
            Console.WriteLine(total_1);
            Console.WriteLine(total_2);
            Console.WriteLine(total_3);
            Console.WriteLine(total_4);
            Console.WriteLine(total_5);

            var total = total_1 * 
                        total_2 * 
                        total_3 * 
                        total_4 * 
                        total_5;
            

            Console.WriteLine(total);

        }

        public static List<SlopeLine> ReadInput(string path)
        {
            var slopeLines = new List<SlopeLine>();
            using var reader = new StreamReader(path);
            var value = reader.ReadLine();
            while(value != null)
            {
                slopeLines.Add(new SlopeLine{Squares = value.ToCharArray()} );
                value = reader.ReadLine();
            }

            return slopeLines;
        }

        public static int NbTreeForSlope(int down, int right, List<SlopeLine> slopes)
        {
            var slope = new Slope(down,right, slopes);

            while(slope.GoDown())
            {}          

            return slope.NbTrees;
        }
    }

    public class Slope
    {
        public Slope(int down, int right, List<SlopeLine> slopLines)
        {
            SlopLines = new List<SlopeLine>();
            X = 0;
            Y = 0;
            this.down = down;
            this.right = right;
            this.SlopLines = slopLines;
        }

        int down;
        int right;

        char tree = '#';

        public List<SlopeLine> SlopLines { get; set; }

        public int Y;
        public int X;

        public int NbTrees { get; set; }

        public bool GoDown()
        {
            Y+= down;
            X+= right;

            if(Y >= SlopLines.Count - 1)
                return false;

            var currentLine = SlopLines[Y];
            if(X > currentLine.Squares.Length - 1)
            {
                X = X - currentLine.Squares.Length;
            }
            if(currentLine.Squares[X] == tree)
            {
                NbTrees ++;
            }

            return true;
        }
    }

    public class SlopeLine
    {
        public char[] Squares {get; set; }
    }
}
