using CalculatorSystem.Data;
using CalculatorSystem;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeightWhileMoveUpFormula", menuName = "SO/WeightWhileMoveUpFormulaSO")]
public class WeightWhileMoveUpFormula : AFormulaViewDataSO
{
    public override double GetValue(List<float> argList)
    {
        if (argList.Count < 2)
            return 0;
        return Calculator.GetWeightWhileMoveUp(argList[0], argList[1]);
    }
}

