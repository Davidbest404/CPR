using System;
using UnityEngine;

public class PlayerHandler : MonoBehaviour, IDamagable
{
    [field: SerializeField]
    public float PlayerSpeed { get; private set; } = 1f;
    [field: SerializeField]
    public int PlayerShootCooldown { get; private set; }
    
    [SerializeField]
    public ProjectileData projectileData;
    [field: SerializeField]
    private int PlayerMaxHealth;
    private int PlayerCurrentHealth;

    public event Action OnDamaged;

    public int Health { get => PlayerCurrentHealth; }
    void Awake()
    {
        PlayerCurrentHealth = PlayerMaxHealth;
    }
    public void Damage()
    {
        PlayerCurrentHealth--;
        Debug.Log(PlayerCurrentHealth);
        OnDamaged.Invoke();
    }

    public void Damage(int Damage)
    {
        PlayerCurrentHealth -= Damage;
        Debug.Log(PlayerCurrentHealth);
        OnDamaged.Invoke();
    }
}
