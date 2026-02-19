using System.Collections.Generic;
using UnityEngine;

namespace CalculatorSystem.Data
{
    [CreateAssetMenu(fileName = "UniversalGravitationForceFormula", menuName = "SO/UniversalGravitationForceFormulaSO")]
    public class UniversalGravitationForceFormula : AFormulaViewDataSO
    {
        public override double GetValue(List<float> argList)
        {
            if (argList.Count < 3)
                return 0;
            return Calculator.GetUniversalGravitationForce(argList[0], argList[1], argList[2]);
        }
    }
}

