using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    // TODO: THINK ABOUT BEING MONOBEHAIVOR. AND REMEMBER IT.
    [field: SerializeField]
    public int ScoreGainFromEnemy { get; private set; } = 1;
    public int CurrentScore { get; private set; } = 0;
    void Awake()
    {
        CurrentScore = 0;
    }
    internal void AddScore()
    {
        CurrentScore += ScoreGainFromEnemy;
    }
}