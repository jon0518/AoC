using System;
using System.Collections.Generic;
using System.Text;

namespace AoC._2019
{
    public class Calculator
    {
        public static List<int> Process(int[] inputs, int input = 1)
        {
            int i = 0;
            int opcode = -1;
            var outputs = new List<int>();
            while (opcode != 99)
            {
                opcode = inputs[i] % 100;
                if (opcode == 1)
                {
                    var parm1immediate = (inputs[i] / 100 % 10) == 1;
                    var parm2immediate = (inputs[i] / 1000 % 10) == 1;
                    var parm1 = inputs[i + 1];
                    var parm2 = inputs[i + 2];
                    inputs[inputs[i + 3]] = (parm1immediate ? parm1 : inputs[parm1]) + (parm2immediate ? parm2 : inputs[parm2]);
                    i += 4;
                }
                if (opcode == 2)
                {
                    var parm1immediate = (inputs[i] / 100 % 10) == 1;
                    var parm2immediate = (inputs[i] / 1000 % 10) == 1;
                    var parm1 = inputs[i + 1];
                    var parm2 = inputs[i + 2];
                    inputs[inputs[i + 3]] = (parm1immediate ? parm1 : inputs[parm1]) * (parm2immediate ? parm2 : inputs[parm2]);
                    i += 4;
                }
                if(opcode == 3)
                {
                    inputs[inputs[i + 1]] = input;
                    i += 2;
                }
                if (opcode == 4)
                {
                    var parm1immediate = (inputs[i] / 100 % 10) == 1;
                    var parm1 = inputs[i + 1];
                    outputs.Add(parm1immediate ? parm1 : inputs[parm1]);
                    i += 2;
                }
                if(opcode == 5)
                {
                    var parm1immediate = (inputs[i] / 100 % 10) == 1;
                    var parm1 = inputs[i + 1];
                    if((parm1immediate && parm1 != 0) || (!parm1immediate && inputs[parm1] != 0))
                    {
                        var parm2immediate = (inputs[i] / 1000 % 10) == 1;
                        var parm2 = inputs[i + 2];
                        i = parm2immediate ? parm2 : inputs[parm2];
                    }
                    else
                    {
                        i += 3;
                    }
                }
                if (opcode == 6)
                {
                    var parm1immediate = (inputs[i] / 100 % 10) == 1;
                    var parm1 = inputs[i + 1];
                    if ((parm1immediate && parm1 == 0) || (!parm1immediate && inputs[parm1] == 0))
                    {
                        var parm2immediate = (inputs[i] / 1000 % 10) == 1;
                        var parm2 = inputs[i + 2];
                        i = parm2immediate ? parm2 : inputs[parm2];
                    }
                    else
                    {
                        i += 3;
                    }
                }
                if(opcode == 7)
                {
                    var parm1immediate = (inputs[i] / 100 % 10) == 1;
                    var parm2immediate = (inputs[i] / 1000 % 10) == 1;
                    var parm1 = inputs[i + 1];
                    var parm2 = inputs[i + 2];
                    inputs[inputs[i + 3]] = (parm1immediate ? parm1 : inputs[parm1]) < (parm2immediate ? parm2 : inputs[parm2]) ? 1 : 0;
                    i += 4;
                }
                if (opcode == 8)
                {
                    var parm1immediate = (inputs[i] / 100 % 10) == 1;
                    var parm2immediate = (inputs[i] / 1000 % 10) == 1;
                    var parm1 = inputs[i + 1];
                    var parm2 = inputs[i + 2];
                    inputs[inputs[i + 3]] = (parm1immediate ? parm1 : inputs[parm1]) == (parm2immediate ? parm2 : inputs[parm2]) ? 1 : 0;
                    i += 4;
                }
            }
            return outputs;
        }
    }
}
