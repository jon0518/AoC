using System;
using System.Collections.Generic;
using System.Text;

namespace AoC
{
    class TreeNode<T>
    {
        public TreeNode()
        {
            ConnetedNodes = new List<TreeNode<T>>();
        }
        public T Value { get; set; }
        public List<TreeNode<T>> ConnetedNodes { get; set; }
    }
}
