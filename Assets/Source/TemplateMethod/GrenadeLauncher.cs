using UnityEngine;

namespace TemplateMethod
{
    [CreateAssetMenu(menuName = "Weapons/GrenadeLauncher")]
    public class GrenadeLauncher : Weapon
    {
        [SerializeField] private float arcAngle = 30f;

        protected override Vector3 ComputeDirection(Transform spawnPoint)
        {
            return (spawnPoint.forward + Vector3.up * Mathf.Tan(arcAngle * Mathf.Deg2Rad)).normalized;
        }

        protected override void AddVelocity(GameObject bullet, Vector3 dir)
        {
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.useGravity = true;
            rb.linearVelocity = dir * projectileSpeed;
        }
    }
}