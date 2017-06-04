using UnityEngine;
using Klak.Wiring;

namespace SimpleScript
{
    [System.Serializable]
    public class VariableUtility
    {
        public enum MathOperation
        {
            Add,
            Subtract,
            Multiply,
            Divide,
        }

        public static int PerformMathOperation(MathOperation mathOp, int valueA, int valueB)
        {
            switch(mathOp)
            {
                case MathOperation.Add:
                    return valueA + valueB;

                case MathOperation.Subtract:
                    return valueA - valueB;

                case MathOperation.Multiply:
                    return valueA * valueB;

                case MathOperation.Divide:
                    return valueA / valueB;
                default:
                    return valueA;
            }            
        }

        public static float PerformMathOperation(MathOperation mathOp, float valueA, float valueB)
        {
            switch (mathOp)
            {
                case MathOperation.Add:
                    return valueA + valueB;

                case MathOperation.Subtract:
                    return valueA - valueB;

                case MathOperation.Multiply:
                    return valueA * valueB;

                case MathOperation.Divide:
                    return valueA / valueB;

                default:
                    return valueA;
            }
        }
    }
}
