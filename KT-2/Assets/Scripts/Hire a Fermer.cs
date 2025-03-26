using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HireaFermer : MonoBehaviour
{
    [SerializeField] public Image imageFarmerTimer;
    [SerializeField] float _timerFillSpeed;
    [SerializeField] private Button hireFarmerButton;
    Wheat_Timer wheatScript;


    void Start()
    {
        hireFarmerButton.onClick.AddListener(Hire_Farmer);
        wheatScript = FindFirstObjectByType<Wheat_Timer>();
    }

    public void Hire_Farmer()
    {
            wheatScript.wheat--;
            StartCoroutine(FarmerTimer());
    }

    IEnumerator FarmerTimer()
    {
        while (imageFarmerTimer.fillAmount < 1)
        {
            imageFarmerTimer.fillAmount += _timerFillSpeed;
            yield return new WaitForSeconds(0.25f);
            if (imageFarmerTimer.fillAmount == 1)
            {
                imageFarmerTimer.fillAmount = 0;
                wheatScript.civilians++;
                yield break;
            }
        }
    }
    private void Update()
    {
        if (wheatScript.wheat != 0 & imageFarmerTimer.fillAmount == 0)
        {
            hireFarmerButton.interactable = true;
        }
        else
        {
            hireFarmerButton.interactable = false;
        }
    }
}
