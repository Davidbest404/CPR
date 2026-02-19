using System;
using UnityEngine;

public class EnemyHandler : MonoBehaviour, IDamagable
{
    public int Health { get; private set; } = -1;
    public void Damage(int Damage)
    {
        Health -= Damage;
        if (Health <= 0)
        {
            ScoreManager scoreManager = FindAnyObjectByType<ScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.AddScore();
            }
            Destroy(gameObject);
        }
    }
    internal void ShootFromEnemy(ProjectileData ProjectileData)
    {
        if (Health <= 0) return;
        ProjectileManager.Instance.Shoot(
            gameObject.transform.position,
            ProjectileData);
    }

    internal void Init(int MaxHealth)
    {
        if (Health == -1 && MaxHealth > 0)
        {
            Health = MaxHealth;
        }
    }
}
