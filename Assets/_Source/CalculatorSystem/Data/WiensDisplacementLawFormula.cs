using System.Collections.Generic;
using UnityEngine;

namespace CalculatorSystem.Data
{
    [CreateAssetMenu(fileName = "WiensDisplacementLawFormula", menuName = "SO/WiensDisplacementLawFormulaSO")]
    public class WiensDisplacementLawFormula : AFormulaViewDataSO
    {
        public override double GetValue(List<float> argList)
        {
            if (argList.Count < 1)
                return 0;
            return Calculator.GetWiensDisplacementLaw(argList[0]);
        }
    }
}

