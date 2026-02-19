using System;
using System.Collections;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    [field: SerializeField]
    private GameObject projectilePrefab;
    internal static ProjectileManager Instance;
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    public void Shoot(Vector3 origin, ProjectileData projectileData)
    {
        if (origin == null || projectileData == null || projectilePrefab == null) return;

        GameObject projectile = Instantiate(projectilePrefab, origin, Quaternion.identity);

        Vector3 convertedVelocity = new Vector3(
            projectileData.Velocity.x,
            projectileData.Velocity.y,
            0);

        if (projectile.TryGetComponent(out SpriteRenderer renderer))
        {
            renderer.color = projectileData.ProjectileColor;
        }

        int ticks = 0;
        bool moving = true;

        void localTickEvent()
        {
            if (!moving || projectile == null || ticks > projectileData.LifeTime)
            {
                if (projectile != null)
                {
                    Destroy(projectile);                    
                }
                GameManager.instance.RemoveEvent(localTickEvent);
                return;
            }

            ticks++;

            projectile.transform.Translate(convertedVelocity);

            RaycastHit2D[] hit2D = Physics2D.BoxCastAll(
                projectile.transform.position,
                projectileData.HitboxSize,
                0,
                Vector2.zero,
                0,
                projectileData.IncludedMask.value);
            if (hit2D != null && hit2D.Length > 0)
            {

                foreach (RaycastHit2D hit in hit2D)
                {
                    if (hit.collider != null
                    && hit.collider.gameObject != null
                    && hit.collider.gameObject.TryGetComponent(out IDamagable damagable))
                    {
                        Debug.Log("Hit!");
                        damagable.Damage(projectileData.Damage);
                        moving = false;
                        Destroy(projectile);
                        return;
                    }
                }
            }
        }
        GameManager.instance.ConnectEvent(localTickEvent);
    }
}

[Serializable]
public class ProjectileData
{
    [field: SerializeField]
    public Vector2 Velocity { get; private set; } = new Vector2(0, 5);
    [field: SerializeField]
    public Vector2 HitboxSize { get; private set; } = new Vector2(0.5f, 1);
    [field: SerializeField]
    public int LifeTime { get; private set; } = 10;
    [field: SerializeField]
    public int Damage { get; private set; } = 1;
    [field: SerializeField]
    public LayerMask IncludedMask { get; private set; }
    [field: SerializeField]
    public Color ProjectileColor { get; private set; }
    public ProjectileData(Vector2 velocity, Vector2 hitboxsize, int lifetime, int damage, LayerMask mask, Color color)
    {
        this.Velocity = velocity;
        this.HitboxSize = hitboxsize;
        this.LifeTime = lifetime;
        this.Damage = damage;
        this.IncludedMask = mask;
        this.ProjectileColor = color;
    }
}