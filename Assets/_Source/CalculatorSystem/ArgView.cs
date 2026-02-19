using CalculatorSystem.Data;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CalculatorSystem
{
    public class ArgView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI labelText;
        [SerializeField] private TMP_InputField inputField;
        private ResultButtonController _resultButtonController;

        public void Init(string label, ResultButtonController resultButton)
        {
            labelText.text = $"{label}";
            _resultButtonController = resultButton;
            
        }
        public float GetIputValue()
        {
            return float.Parse(inputField.text);
        }

        public bool IsFilled()
        {
            return (inputField.text != "") ? true : false;
        }

        public void IsChange()
        {
            _resultButtonController.CheckCanInteract();
        }
    }

}