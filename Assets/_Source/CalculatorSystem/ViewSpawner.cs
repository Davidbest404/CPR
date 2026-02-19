using CalculatorSystem.Data;
using UnityEngine;

namespace CalculatorSystem
{
    public class ViewSpawner
    {
        private readonly FormulaSlot _formulaPrefab;
        private readonly RectTransform _root;
        private readonly FormulaContainerSO _formulaContainer;

        public ViewSpawner(
            FormulaSlot formulaPrefab, 
            RectTransform root, 
            FormulaContainerSO formulaContainer)
        {
            _formulaPrefab = formulaPrefab;
            _root = root;
            _formulaContainer = formulaContainer;
        }

        public void Spawn()
        {
            Clear();
            foreach (var formula in _formulaContainer.Formulas)
            {
                var formulaSlot = Object.Instantiate(_formulaPrefab, _root);
                formulaSlot.Init(formula.Formula, formula.Args, onCalculate: () =>
                {
                    return formula.GetValue(formulaSlot.GetArgs());
                });

            }
        }

        private void Clear()
        {
            for (int i = 0; i < _root.childCount; i++)
            {
                Object.Destroy(_root.GetChild(i).gameObject);
            }
        }
    }
}