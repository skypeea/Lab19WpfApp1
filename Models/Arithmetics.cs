using Microsoft.CodeAnalysis.CSharp.Scripting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab19WpfApp1.Models
{
    static class Arithmetics
    {
        public static double GetLenght(double r)
        {
            return 2 * r * Math.PI;
        }

        public static double Parse(string expression)
        {
            try
            {
                return CSharpScript.EvaluateAsync<double>(expression).Result;
            }
            catch (Exception)
            {

                return double.NaN;
            }
            
        }
    }
}
