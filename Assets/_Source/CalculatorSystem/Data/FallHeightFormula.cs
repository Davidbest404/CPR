using System.Collections.Generic;
using UnityEngine;

namespace CalculatorSystem.Data
{
    [CreateAssetMenu(fileName = "FallHeightFormula", menuName = "SO/FallHeightFormulaSO")]
    public class FallHeightFormula : AFormulaViewDataSO
    {
        public override double GetValue(List<float> argList)
        {
            if (argList.Count < 1)
                return 0;
            return Calculator.GetFallHeight(argList[0]);
        }
    }
}

