using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour, IINITIALIZABLE
{
    [field: SerializeField]
    private float tickDuration = 0.25f;
    [field:SerializeField]
    public GameStates CurrentGameState { get; private set; }
    internal static GameManager instance;
    private event Action onTickEvents;
    float tickTimer = 0;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        instance = this;
        CurrentGameState = GameStates.OnHold;
    }
    void Update()
    {
        if (CurrentGameState != GameStates.Playing) return;
        tickTimer += Time.deltaTime;
        if (tickTimer >= tickDuration)
        {
            tickTimer = 0;
            onTickEvents?.Invoke();
        }
    }
    void OnDestroy()
    {
        UpdateState(GameStates.OnHold);
        onTickEvents = null;    
    }
    void Initialize()
    {
        Debug.Log("Game manager have been initialized!");
        CurrentGameState = GameStates.Playing;
    }
    void IINITIALIZABLE.Initialize()
    {
        Initialize();
    }
    internal void ConnectEvent(Action action)
    {
        if (action != null)
        {
            onTickEvents += action;
        }
    }
    internal void RemoveEvent(Action action)
    {
        if (action != null)
        {
            onTickEvents -= action;
        }
    }
    internal void ResetScene()
    {
        UpdateState(GameStates.OnHold);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex,LoadSceneMode.Single);
        UpdateState(GameStates.Playing);
    }
    internal void UpdateState(GameStates newState)
    {
        CurrentGameState = newState;
    }

}

public enum GameStates
{
    Playing,
    Paused,
    OnHold,
}