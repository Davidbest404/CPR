using CalculatorSystem.Data;
using System;
using System.Collections.Generic;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace CalculatorSystem
{
    public class FormulaSlot : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI formulaText;
        [SerializeField] private RectTransform argsRoot;
        [SerializeField] private ArgView argPrefab;
        [SerializeField] private Button resultButton;
        [SerializeField] private TextMeshProUGUI resultText;
        [SerializeField] private ResultButtonController buttonController;

        private List<ArgView> _argViews = new List<ArgView>();
        private Func<double> _onCalculate;

        public void Init(string formulaString, List<Arg> args, Func<double> onCalculate)
        {
            formulaText.text = formulaString;
            _onCalculate = onCalculate;
            for (int i = 0; i < args.Count; i++)
            {
                var argView = Instantiate(argPrefab, argsRoot);
                argView.Init(args[i].Name, buttonController);
                _argViews.Add(argView);

            }
            buttonController.Init(resultButton, _argViews);
            resultButton.onClick.AddListener(OnCalculatePrssed);

        }

        private void OnCalculatePrssed()
        {
            double? value = _onCalculate?.Invoke();
            if (value != null)
                resultText.text = RoundUpResult.RoundUp(value.Value);
        }

        public List<float> GetArgs()
        {
            List<float> argsList = new List<float>();
            foreach (var arg in _argViews)
            {
                argsList.Add(arg.GetIputValue());
            }
            return argsList;
        }
    }
}