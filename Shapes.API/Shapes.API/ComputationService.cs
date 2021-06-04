using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Z.Expressions;

namespace Shapes.API
{
    public class ComputationService
    {
        private readonly string _formula;
        private readonly Dictionary<string, object> _variables;

        public ComputationService(string formula, Dictionary<string, object> variables)
        {
            _formula = formula;
            _variables = variables;
        }

        public float Compute()
        {
            return Eval.Execute<float>(_formula, _variables);
        }


    }
}
