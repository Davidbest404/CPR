using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WheatContibution : MonoBehaviour
{
    [SerializeField] private Wheat_Timer wheatScript;
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    [SerializeField] public Image wheatContributionTimer;
    [SerializeField] private float _timerFillSpeed;
    private int _difference;
    private int amountOfPeople;


    public IEnumerator WheatContributionTimerWorking()
    {
        while (true)
        {
        yield return new WaitForSeconds(0.5f);
        WheatContrib();
        }
    }
    
    private void WheatContrib()
    {
        if (wheatContributionTimer.fillAmount == 1)
        {
            wheatContributionTimer.fillAmount = 0;
            _difference = (wheatScript.civilians + wheatScript.warriors) - wheatScript.wheat;
            if (wheatScript.wheat < (wheatScript.civilians + wheatScript.warriors) & wheatScript.warriors >= _difference)
            {
                wheatScript.warriors -= _difference;
            }
            else if (wheatScript.wheat < (wheatScript.civilians + wheatScript.warriors) & (wheatScript.warriors + wheatScript.civilians) >= _difference)
            {
                wheatScript.civilians -= _difference + wheatScript.warriors;
                wheatScript.warriors -= _difference;
            }
            else
            { 
            wheatScript.wheat -= wheatScript.civilians + wheatScript.warriors;
            }
        }
        else
        {
            wheatContributionTimer.fillAmount += _timerFillSpeed;
        }
    }
}
