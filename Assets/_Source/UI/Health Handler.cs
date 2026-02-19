using System.Collections.Generic;
using UnityEngine;

public class HealthDisplayHandler : MonoBehaviour
{
    [field: SerializeField]
    private GameObject HPReference;
    [field: SerializeField]
    private Transform UIHPParent;
    [field: SerializeField]
    private string playerTag;
    private PlayerHandler handler;
    private List<GameObject> healthGameObjects;
    private int playerMaxHealth;
    void Start()
    {
        healthGameObjects = new();
        handler = PlayerInvoker.GetPlayerHandler(playerTag);
        if (handler != null)
        {
            playerMaxHealth = handler.Health;
            handler.OnDamaged += OnPlayerDamaged;
            for (int _ = 0; _ < playerMaxHealth; _++)
            {
                GameObject newHP = Instantiate(HPReference, UIHPParent);
                healthGameObjects.Add(newHP);
            }
        }
    }
    void OnPlayerDamaged()
    {
        int currentHealth = handler.Health;
        int diff = healthGameObjects.Count - currentHealth;
        if (diff > 0 && healthGameObjects.Count > 0)
        {
            for (int _ = 0; _ < diff; _++)
            {
                int index = healthGameObjects.Count - 1;
                Destroy(healthGameObjects[^1]);
                healthGameObjects.RemoveAt(index);
            }
        }
        else if (diff < 0)
        {
            diff = Mathf.Abs(diff);
            for (int _ = 0; _ < diff; _++)
            {
                GameObject newHP = Instantiate(HPReference, UIHPParent);
                healthGameObjects.Add(newHP);
            }
        }
    }
}
