using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC._2019._08
{
    class Solver : AbstractSolver, ISolver
    {
        public void SolvePart1()
        {
            var layers = Parse(base.GetInput());
            var min0 = layers.Min(x => GetCount(x, 0));
            var layer = layers.First(x => GetCount(x, 0) == min0);
            Console.WriteLine(GetCount(layer, 1) * GetCount(layer, 2));
        }

        int GetCount(int[,] grid, int val)
        {
            var count = 0;
            for (int i=0; i <grid.GetLength(0); i++)
                for(int j=0; j<grid.GetLength(1); j++)
                {
                    if(grid[i,j] == val)
                    {
                        count++;
                    }
                }
            return count;

        }

        public void SolvePart2()
        {
            var layers = Parse(base.GetInput());
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    if(IsBlack(layers,j,i))
                    {
                        Console.Write("X");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }

        bool IsBlack(List<int[,]> layers, int i, int j)
        {
            foreach(var layer in layers)
            {
                if (layer[i, j] == 0) return true;
                if (layer[i, j] == 1) return false;
            }
            return false;
        }

        List<int[,]> Parse(string ints)
        {
            var layers = new List<int[,]>();
            for(int i =0; i<ints.Length; i+=150)
            {
                var layer = new int[25, 6];
                for(int j=0; j< 6; j++)
                {
                    for(int k=0; k<25; k++)
                    {
                        layer[k, j] = ints[i + 25*j + k]-48;
                    }
                }
                layers.Add(layer);
            }
            return layers;
        }

        public void TestPart1()
        {
            throw new NotImplementedException();
        }

        public void TestPart2()
        {
            throw new NotImplementedException();
        }
    }
}
