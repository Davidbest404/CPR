using UnityEngine;
using UnityEngine.InputSystem;

namespace TemplateMethod
{
    public class PlayerShooting : MonoBehaviour
    {
        [SerializeField] private Transform firePoint;
        private Weapon weapon;

        private GameplayInput input;

        private void Awake()
        {
            input = new GameplayInput();
            input.Gameplay.Fire.performed += _ => TryFire();
            input.Gameplay.Enable();
        }

        private void OnDisable() => input.Gameplay.Disable();

        public void Equip(Weapon w) => weapon = w;

        private void TryFire()
        {
            if (weapon != null) weapon.Fire(firePoint);
        }
    }
}