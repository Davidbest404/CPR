using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class ScoreConnector : MonoBehaviour
{
    private TMP_Text textLabel;
    private ScoreManager scoreManager;
    void Start()
    {
        scoreManager = FindAnyObjectByType<ScoreManager>();
        textLabel = GetComponent<TMP_Text>();
    }
    void Update()
    {
        textLabel.text = "SCORE: "+scoreManager.CurrentScore.ToString();
    }
}
