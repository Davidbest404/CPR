using System.Collections.Generic;
using UnityEngine;

namespace CalculatorSystem.Data
{
    [CreateAssetMenu(fileName = "JouleLenzLawFormula", menuName = "SO/JouleLenzLawFormulaSO")]
    public class JouleLenzLawFormula : AFormulaViewDataSO
    {
        public override double GetValue(List<float> argList)
        {
            if (argList.Count < 3)
                return 0;
            return Calculator.GetJouleLenzLaw(argList[0], argList[1], argList[2]);
        }
    }
}

