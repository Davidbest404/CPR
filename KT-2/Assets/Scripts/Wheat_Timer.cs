using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Wheat_Timer : MonoBehaviour
{
    [SerializeField] public Image image; // image that's used as a WheatProductiontimer
    [SerializeField] private float _imageFillSpeed = 0.1f;
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    [SerializeField] private TextMeshProUGUI _textMeshPro2;
    [SerializeField] private TextMeshProUGUI _textMeshPro3;
    [SerializeField] CoroutineRunner CoroutineRunnerScript;
    private int amountOfPeopleTotal = 0;
    public int civilians;
    public int warriors;
    public int wheat;

    private float _currTime;

    private void WheatTimer()
    {
        if (image.fillAmount == 1)
        {
            image.fillAmount = 0;
            wheat = wheat + civilians;
        }
        else
        {
            image.fillAmount = image.fillAmount + _imageFillSpeed;
        }
    }


    public IEnumerator WheatGive()
    {
        while (true)
        {
            WheatTimer();
            yield return new WaitForSeconds(0.5f);
        }   
    }

    private void Update()
    {
        CheckNegative();
        Victory();
        ShowingNumbers();
    }
    private void CheckNegative()
    {
        if (civilians <= 0 && warriors <= 0)
        {
            CoroutineRunnerScript.StopCoroutines();
        }
    }
    private void Victory()
    {
        if (civilians >= 50 & wheat >= 100)
        {
            CoroutineRunnerScript.StopCoroutines();
        }
    }
    private void ShowingNumbers()
    {
        _textMeshPro.text = wheat.ToString();
        _textMeshPro2.text = civilians.ToString();
        _textMeshPro3.text = warriors.ToString();
    }
}
