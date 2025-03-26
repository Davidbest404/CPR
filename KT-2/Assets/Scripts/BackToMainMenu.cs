using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackToMainMenu : MonoBehaviour
{
    [SerializeField] Button backToMenuButton;
    [SerializeField] Canvas mainMenuCanvas;
    [SerializeField] Canvas LoreCanvas;
    void Start()
    {
        backToMenuButton.onClick.AddListener(ComeBackToMainMenu);
    }

    void ComeBackToMainMenu()
    {
        mainMenuCanvas.gameObject.SetActive(true);
        LoreCanvas.gameObject.SetActive(false);
    }
}
