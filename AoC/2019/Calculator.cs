using System;
using System.Collections.Generic;
using System.Text;

namespace AoC._2019
{
    public class Calculator
    {
        public static List<long> Process(long[] ins, long input = 1, long? phase = null)
        {
            if (!phase.HasValue)
                phase = input;
            var inputs = new Dictionary<long, long>();
            for(int j =0; j<ins.Length; j++)
            {
                inputs.Add(j, ins[j]);
            }
            int i = 0;
            long opcode = -1;
            bool phaseUsed = false;
            long relativeShift = 0;
            var outputs = new List<long>();
            while (opcode != 99)
            {
                opcode = inputs[i] % 100;
                var parm1mode = (inputs[i] / 100 % 10);
                var parm2mode = (inputs[i] / 1000 % 10);
                var parm3mode = (inputs[i] / 10000 % 10);
                if (opcode == 1)
                {
                    var parm1 = GetParm(inputs, parm1mode, i + 1, relativeShift);
                    var parm2 = GetParm(inputs, parm2mode, i + 2, relativeShift);
                    inputs[GetReferenceLocation(inputs, parm3mode, i + 3, relativeShift)] = parm1 + parm2;
                    i += 4;
                }
                if (opcode == 2)
                {
                    var parm1 = GetParm(inputs, parm1mode, i + 1, relativeShift);
                    var parm2 = GetParm(inputs, parm2mode, i + 2, relativeShift);
                    inputs[GetReferenceLocation(inputs, parm3mode, i + 3, relativeShift)] = parm1 * parm2;
                    i += 4;
                }
                if (opcode == 3)
                {
                    inputs[GetReferenceLocation(inputs, parm1mode, i + 1, relativeShift)] = phaseUsed ? input : phase.Value;
                    phaseUsed = true;
                    i += 2;
                }
                if (opcode == 4)
                {
                    var parm1 = GetParm(inputs, parm1mode, i + 1, relativeShift);
                    outputs.Add(parm1);
                    i += 2;
                }
                if (opcode == 5)
                {
                    var parm1 = GetParm(inputs, parm1mode, i + 1, relativeShift);
                    if (parm1 != 0)
                    {
                        var parm2 = GetParm(inputs, parm2mode, i + 2, relativeShift);
                        i = (int)parm2;
                    }
                    else
                    {
                        i += 3;
                    }
                }
                if (opcode == 6)
                {
                    var parm1 = GetParm(inputs, parm1mode, i + 1, relativeShift);
                    if (parm1 == 0)
                    {
                        var parm2 = GetParm(inputs, parm2mode, i + 2, relativeShift);
                        i = (int)parm2;
                    }
                    else
                    {
                        i += 3;
                    }
                }
                if (opcode == 7)
                {
                    var parm1 = GetParm(inputs, parm1mode, i + 1, relativeShift);
                    var parm2 = GetParm(inputs, parm2mode, i + 2, relativeShift);
                    inputs[GetReferenceLocation(inputs, parm3mode, i + 3, relativeShift)] = parm1 < parm2 ? 1 : 0;
                    i += 4;
                }
                if (opcode == 8)
                {
                    var parm1 = GetParm(inputs, parm1mode, i + 1, relativeShift);
                    var parm2 = GetParm(inputs, parm2mode, i + 2, relativeShift);
                    inputs[GetReferenceLocation(inputs, parm3mode, i + 3, relativeShift)] = parm1 == parm2 ? 1 : 0;
                    i += 4;
                }
                if (opcode == 9)
                {
                    var parm1 = GetParm(inputs, parm1mode, i + 1, relativeShift);
                    relativeShift += parm1;
                    i += 2;
                }
            }
            for(int ct = 0; ct < ins.Length; ct++)
            {
                ins[ct] = inputs[ct];
            }
            return outputs;
        }

        private static long GetParm(Dictionary<long, long> inputs, long parmMode, int index, long relativeShift)
        {
            if (parmMode == 1) return inputs[index];
            long ix = GetReferenceLocation(inputs, parmMode, index, relativeShift);
            return inputs.ContainsKey(ix) ? inputs[ix] : 0;
        }

        private static long GetReferenceLocation(Dictionary<long, long> inputs, long parmMode, int index, long relativeShift)
        {
            return parmMode == 0 ? inputs[index] : (inputs[index] + relativeShift);
        }
    }
}