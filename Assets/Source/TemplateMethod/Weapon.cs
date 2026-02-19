using UnityEngine;

namespace TemplateMethod
{
    public abstract class Weapon : ScriptableObject
    {
        [Header("Common")]
        public GameObject projectilePrefab;
        public float projectileSpeed = 20f;
        public int damage = 10;

        public void Fire(Transform spawnPoint)
        {
            Vector3 dir = ComputeDirection(spawnPoint);
            GameObject go = CreateProjectile(spawnPoint.position, dir);
            AddVelocity(go, dir);
            PlayEffects(spawnPoint);
        }

        protected abstract Vector3 ComputeDirection(Transform spawnPoint);
        protected virtual GameObject CreateProjectile(Vector3 pos, Vector3 dir) =>
            Instantiate(projectilePrefab, pos, Quaternion.LookRotation(dir));

        protected virtual void AddVelocity(GameObject bullet, Vector3 dir) =>
            bullet.GetComponent<Rigidbody>().linearVelocity = dir * projectileSpeed;

        protected virtual void PlayEffects(Transform spawnPoint) { }
    }
}