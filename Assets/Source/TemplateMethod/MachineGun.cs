using UnityEngine;

namespace TemplateMethod
{
    [CreateAssetMenu(menuName = "Weapons/MachineGun")]
    public class MachineGun : Weapon
    {
        protected override Vector3 ComputeDirection(Transform spawnPoint) =>
            spawnPoint.forward;
    }
}