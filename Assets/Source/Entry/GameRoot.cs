using UnityEngine;
using UnityEngine.InputSystem;
using Strategy;
using TemplateMethod;

public class GameRoot : MonoBehaviour
{
    [SerializeField] private MovementController mover;
    [SerializeField] private PlayerShooting shooting;
    [SerializeField] private Weapon machineGunAsset;
    [SerializeField] private Weapon grenadeAsset;

    private GameplayInput input;

    private void Awake()
    {
        input = new GameplayInput();

        input.Gameplay.Switch1.performed += _ => mover.SetStrategy(new RunMovement());
        input.Gameplay.Switch2.performed += _ => mover.SetStrategy(new FlyMovement());
        input.Gameplay.Switch3.performed += _ => shooting.Equip(machineGunAsset);
        input.Gameplay.Switch4.performed += _ => shooting.Equip(grenadeAsset);

        input.Gameplay.Enable();
    }

    private void OnDisable() => input.Gameplay.Disable();
}