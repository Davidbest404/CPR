using CalculatorSystem;
using CalculatorSystem.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private FormulaSlot formulaPrefab;
        [SerializeField] private RectTransform formulaRoot;
        [SerializeField] private FormulaContainerSO formulaContainer;

        private void Awake()
        {
            InputManager.Init();
            new ViewSpawner(formulaPrefab, formulaRoot, formulaContainer).Spawn();
        }

        private void Start()
        {
            for (int i = 0; i < 4; i++)
            {
                LayoutRebuilder.ForceRebuildLayoutImmediate(formulaRoot);
            }
        }
    }
}