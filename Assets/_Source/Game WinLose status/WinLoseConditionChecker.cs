using System;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseConditionChecker : MonoBehaviour
{
    [field: SerializeField]
    private Transform guiParent;
    [field: SerializeField]
    private GameObject winFrame;
    [field: SerializeField]
    private GameObject looseFrame;
    [field: SerializeField]
    private float limitYPosition = -2.5f;
    private GameObject currentFrame;
    private PlayerHandler player;
    private List<EnemyHandler> enemyListReference;
    void Start()
    {
        player = FindAnyObjectByType<PlayerHandler>();
        player.OnDamaged += OnPlayerDamaged;
    }
    void Update()
    {
        if (enemyListReference != null)
        {
            CheckMoveloseConditionAndNulls();
            if (enemyListReference.Count <= 0)
            {
                SetCurrentState(true);
                enemyListReference = null;                
            }
        }
    }
    internal void OnEnemiesSpawnInitialize(List<EnemyHandler> newlist)
    {
        enemyListReference = newlist;
    }
    void CheckMoveloseConditionAndNulls()
    {
        if (enemyListReference == null) return;
        List<EnemyHandler> cloned = enemyListReference;
        for (int i = 0; i < cloned.Count; i++)
        {
            EnemyHandler enemyHandler = cloned[i];
            if (enemyHandler == null || enemyHandler.gameObject == null || enemyHandler.Health <= 0)
            {
                cloned.RemoveAt(i);
            }
            else if (enemyHandler != null && enemyHandler.transform != null)
            {
                if (enemyHandler.transform.position.y <= limitYPosition)
                {
                    SetCurrentState(false);
                }
            }
        }
        enemyListReference = cloned;
    }
    void OnPlayerDamaged()
    {
        if (player != null && player.Health <= 0)
        {
            Destroy(player.gameObject);
            SetCurrentState(false);
        }
    }
    void SetCurrentState(bool wonOrLost = true)
    {
        GameManager.instance.UpdateState(GameStates.Paused);
        Debug.Log(wonOrLost);
        if (currentFrame != null) Destroy(currentFrame);
        currentFrame = Instantiate(wonOrLost ? winFrame : looseFrame, guiParent);
    }
}
