using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HireaWarrior : MonoBehaviour
{
    [SerializeField] public Image imageWarriorTimer;
    [SerializeField] float _timerFillSpeed;
    [SerializeField] Button hireWarriorButton;
    Wheat_Timer wheatScript;

    void Start()
    {
        wheatScript = FindObjectOfType<Wheat_Timer>();
        hireWarriorButton.onClick.AddListener(HireWarrior);
    }

    public void HireWarrior()
    {
            wheatScript.wheat--;
        StartCoroutine(FarmerTimer());
    }
    IEnumerator FarmerTimer()
    {
        while (imageWarriorTimer.fillAmount < 1)
        {
            imageWarriorTimer.fillAmount += _timerFillSpeed;
            yield return new WaitForSeconds(0.25f);
            if (imageWarriorTimer.fillAmount == 1)
            {
                imageWarriorTimer.fillAmount = 0;
                wheatScript.warriors++;
                yield break;
            }
        }
    }
    private void Update()
    {
        InteractableButton();
    }
    private void InteractableButton()
    {
        if (wheatScript.wheat != 0 & imageWarriorTimer.fillAmount == 0)
        {
            hireWarriorButton.interactable = true;
        }
        else
        {
            hireWarriorButton.interactable = false;
        }
    }
}
