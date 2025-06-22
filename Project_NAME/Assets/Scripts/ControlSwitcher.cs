using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlSwitcher : MonoBehaviour
{
    public PlayerInput playerInput;
    public InputActionAsset characterControls;
    public InputActionAsset vehicleControls;

    void Awake()
    {
        playerInput = FindObjectOfType<PlayerInput>();

        characterControls = Resources.Load<InputActionAsset>("PlayerControls");
        vehicleControls = Resources.Load<InputActionAsset>("VehicleControls");
    }

    public void EnterVehicle()
    {
        playerInput.SwitchCurrentActionMap("VehicleControl");
    }

    public void ExitVehicle()
    {
        playerInput.SwitchCurrentActionMap("CharacterControl");
    }
}
