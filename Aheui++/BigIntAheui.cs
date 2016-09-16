using System;
using System.Text;
using System.Numerics;

namespace Aheui__
{
    public class BigIntAheui : Aheui<BigInteger>
    {
        #region static
        public static string Execute(string script, params string[] args)
        {
            StringBuilder result = new StringBuilder();
            int index = 0;
            var a = new IntAheui(script);
            a.InputNeeded += (type) => {
                if (type == InputType.Number) return args[index++];
                else if (type == InputType.Char) return args[index++][0].ToString();
                else throw new AheuiException();
            };
            a.OutputReleased += (output) => result.Append(output);
            a.RunAll();

            return result.ToString();
        }
        #endregion

        public BigIntAheui(string script, bool debug = false) : base(script, debug)
        {

        }

        protected override BigInteger StringToType(string val)
        {
            return BigInteger.Parse(val);
        }

        protected override string TypeToInt(BigInteger val)
        {
            return val.ToString();
        }

        protected override string TypeToChar(BigInteger val)
        {
            int a = (int)val;
            char c = (char)a;
            return c.ToString();
        }

        protected override BigInteger Add(BigInteger a, BigInteger b)
        {
            return a + b;
        }
        protected override BigInteger Sub(BigInteger a, BigInteger b)
        {
            return a - b;
        }
        protected override BigInteger Mul(BigInteger a, BigInteger b)
        {
            return a * b;
        }
        protected override BigInteger Div(BigInteger a, BigInteger b)
        {
            return a / b;
        }
        protected override BigInteger Per(BigInteger a, BigInteger b)
        {
            return a % b;
        }

        protected override bool IsBiggerOrEqual(BigInteger a, BigInteger b)
        {
            return a <= b;
        }
    }
}
