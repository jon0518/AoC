using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC._2019._06
{
    class Solver : AbstractSolver, ISolver
    {
        public void SolvePart1()
        {
            var n = GetTree(base.GetInputLines());
            Console.WriteLine(n.Values.Sum(CountPaths));
        }

        public void SolvePart2()
        {
            var n = GetTree(base.GetInputLines());
            var min = int.MaxValue;
            foreach(var node in n.Values)
            {
                var youVal = CountToDestination(node, "YOU", 0);
                var sanVal = CountToDestination(node, "SAN", 0);
                if(youVal != -1 && sanVal != -1)
                {
                    min = Math.Min(min, youVal + sanVal -2);
                }
            }
            Console.WriteLine(min);
        }

        public void TestPart1()
        {
            var input = @"COM)B
B)C
C)D
D)E
E)F
B)G
G)H
D)I
E)J
J)K
K)L";
            var n = GetTree(input.Split(Environment.NewLine).ToList());
            Console.WriteLine(n.Values.Sum(CountPaths));
        }

        int CountToDestination(TreeNode<string> node, string target, int steps)
        {
            if (node.Value == target)
            {
                return steps;
            }
            if(!node.ConnetedNodes.Any())
            {
                return -1;
            }
            var min = 1000000;
            foreach(var n in node.ConnetedNodes)
            {
                var val = CountToDestination(n, target, steps+1);
                if(val != -1)
                {
                    min = Math.Min(min, val);
                }
            }
            return min;
        }

        int CountPaths(TreeNode<string> node)
        {
            if(!node.ConnetedNodes.Any())
            {
                return 0;
            }
            return node.ConnetedNodes.Sum(x => 1 + CountPaths(x));
        }
        
        Dictionary<string, TreeNode<string>> GetTree(List<string> input)
        {
            var nodes = new Dictionary<string, TreeNode<string>>();
            foreach(var str in input)
            {
                var vals = str.Split(')');
                TreeNode<string> baseNode, orbitingNode;
                if (nodes.ContainsKey(vals[0]))
                {
                    baseNode = nodes[vals[0]];
                }
                else
                {
                    baseNode = new TreeNode<string> { Value = vals[0] };
                    nodes.Add(vals[0], baseNode);
                }
                if (nodes.ContainsKey(vals[1]))
                {
                    orbitingNode = nodes[vals[1]];
                }
                else
                {
                    orbitingNode = new TreeNode<string> { Value = vals[1] };
                    nodes.Add(vals[1], orbitingNode);
                }
                baseNode.ConnetedNodes.Add(orbitingNode);
            }
            return nodes;
        }

        public void TestPart2()
        {
            throw new NotImplementedException();
        }
    }
}
