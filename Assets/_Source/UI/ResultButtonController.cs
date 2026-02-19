using CalculatorSystem;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultButtonController : MonoBehaviour
{
    private Button resultButton;
    private List<ArgView> _argViews;

    public void Init(Button button, List<ArgView> argViews)
    {
        resultButton = button;
        _argViews = argViews;
        resultButton.interactable = false;
    }

    public void CheckCanInteract()
    {
        int count = 0;
        foreach (var item in _argViews)
        {
            if (item.IsFilled())
                count++;
        }
        if (count == _argViews.Count)
            resultButton.interactable = true;
    }
}
