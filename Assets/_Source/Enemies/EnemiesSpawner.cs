using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [Header("Base Enemy Settings")]
    [field: SerializeField]
    private GameObject enemyReference;
    [field: SerializeField]
    private int enemiesMaxHealth = 2;
    [Header("Settings")]
    [field: SerializeField]
    private int rowCount = 3;
    [field: SerializeField]
    private int collumnCount = 3;
    [field: SerializeField]
    private float verticalGap = 15;
    [field: SerializeField]
    private float horizontalGap = 15;
    [field: SerializeField]
    [Space]
    [Header("Following settings are pass-throught, and not handled in this script.")]
    [Header("Moving Settings")]
    private int MoveStepDelay = 2;
    [field: SerializeField]
    private float MoveStepAmount = 15;
    [field: SerializeField]
    [Header("Shooting Settings")]
    private int ShootingDelay = 6;
    [field: SerializeField]
    private ProjectileData dataForProjectiles;
    private List<EnemyHandler> enemies;
    private EnemiesInvoker invoker;
    void Start()
    {
        if (enemyReference == null)
        {
            Debug.LogWarning("Error, the enemy reference is missing in enemy pivot controller.");
            return;
        }
        enemies = new();
        for (int y = -Mathf.FloorToInt(rowCount / 2); y <= Mathf.CeilToInt(rowCount / 2); y++)
        {
            for (int x = -Mathf.FloorToInt(collumnCount / 2); x <= Mathf.CeilToInt(collumnCount / 2); x++)
            {
                Vector3 newPosition = new Vector3(
                    x * horizontalGap + enemyReference.transform.localScale.x + transform.position.x,
                    y * verticalGap + enemyReference.transform.localScale.y + transform.position.y
                );
                GameObject newEnemy = Instantiate(enemyReference, newPosition, Quaternion.identity);
                if (newEnemy.TryGetComponent(out EnemyHandler handler))
                {
                    enemies.Add(handler);
                    handler.Init(enemiesMaxHealth);
                }
                else
                {
                    Debug.LogWarning("EnemyHandler was missing in new enemy. destroying to prevent bugs.");
                    Destroy(newEnemy);
                }
            }
        }
        if (enemies.Count > 0)
        {
            invoker = new(enemies, MoveStepDelay, MoveStepAmount, ShootingDelay, dataForProjectiles);
            WinLoseConditionChecker checker = FindAnyObjectByType<WinLoseConditionChecker>();
            if (checker != null)
            {
                checker.OnEnemiesSpawnInitialize(enemies);
            }
        }
    }
    void Oestroy()
    {
        invoker.OnDestroy();
        invoker = null;              
    }
}
