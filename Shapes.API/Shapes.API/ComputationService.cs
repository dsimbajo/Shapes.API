using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Z.Expressions;

namespace Shapes.API
{
    public class ComputationService
    {
        /// <summary>
        /// Computes the formula and returns float value
        /// </summary>
        /// <param name="formula">Specified formula to be evaluated and executed</param>
        /// <param name="variables">Values of the variables to be used in the formula</param>
        /// <returns></returns>
        public float Compute(string formula, Dictionary<string, object> variables)
        {
            return Eval.Execute<float>(formula, variables);
        }


    }
}
