using System.Collections.Generic;
using UnityEngine;

public class EnemiesInvoker
{
    private int MoveStepDelay = 2;
    private float MoveStepAmount = 15;
    private int ShootingDelay = 6;
    private ProjectileData dataForProjectiles;
    private int tickTimerForNextStep = 0;
    private int tickTimerForNextFire = 0;
    private List<EnemyHandler> enemies;
    protected internal void OnDestroy()
    {
        enemies = null;   
    }
    void OnTick()
    {
        if (enemies == null) return;
        if (tickTimerForNextFire >= ShootingDelay)
        {
            tickTimerForNextFire = 0;
            ShootFromRandomEnemy();
        }
        else
        {
            tickTimerForNextFire++;
        }

        if (tickTimerForNextStep >= MoveStepDelay)
        {
            tickTimerForNextStep = 0;
            MoveEnemiesOneStep();
        }
        else
        {
            tickTimerForNextStep++;
        }
        if (enemies.Count == 0 && enemies != null) 
        {
            enemies = null;
        }
    }
    void ShootFromRandomEnemy()
    {
        if (enemies == null || enemies.Count == 0) return;
        int randomNumber = Random.Range(0, enemies.Count);
        if (enemies[randomNumber] != null)
        {
            enemies[randomNumber].ShootFromEnemy(dataForProjectiles);
        }
    }
    void MoveEnemiesOneStep()
    {
        if (enemies == null || enemies.Count == 0) return;
        foreach (EnemyHandler enemy in enemies)
        {
            if (enemy == null || enemy.gameObject == null ||enemy.Health <= 0) continue;
            enemy.gameObject.transform.position += Vector3.down * MoveStepAmount;
        }
    }
    public EnemiesInvoker(List<EnemyHandler> list, int moveStepDelay, float moveStepAmount, int shootingDelay, ProjectileData projectileData)
    {
        enemies = list;
        MoveStepDelay = moveStepDelay;
        MoveStepAmount = moveStepAmount;
        ShootingDelay = shootingDelay;
        dataForProjectiles = projectileData;
        GameManager.instance.ConnectEvent(OnTick);
    }
}
