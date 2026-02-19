using System.Collections.Generic;
using UnityEngine;

namespace CalculatorSystem.Data
{
    public abstract class AFormulaViewDataSO : ScriptableObject
    {
        [field: SerializeField] public string Formula { get; private set; }
        [field: SerializeField] public List<Arg> Args { get; private set; }

        public abstract double GetValue(List<float> argList);
    }
}