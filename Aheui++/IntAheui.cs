using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aheui__
{
    public class IntAheui  : Aheui<int>
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

        public IntAheui(string[] script, bool debug = false) : base(script, debug)
        {

        }

        public IntAheui(string script, bool debug = false) : base(script, debug)
        {

        }

        protected override int StringToType(string val)
        {
            return Convert.ToInt32(val);
        }

        protected override int Add(int a, int b)
        {
            return a + b;
        }

        protected override int Mul(int a, int b)
        {
            return a * b;
        }

        protected override int Sub(int a, int b)
        {
            return a - b;
        }
        protected override int Div(int a, int b)
        {
            return a / b;
        }
        protected override int Per(int a, int b)
        {
            return a % b;
        }
    }
}
