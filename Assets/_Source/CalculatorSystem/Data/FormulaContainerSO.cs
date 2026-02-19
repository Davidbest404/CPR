using System.Collections.Generic;
using UnityEngine;

namespace CalculatorSystem.Data
{
    [CreateAssetMenu(fileName = "FormulaContainerSO", menuName = "SO/NewFormulaContainer")]
    public class FormulaContainerSO : ScriptableObject
    {
        [field: SerializeField] public List<AFormulaViewDataSO> Formulas { get; private set; }
    }
}