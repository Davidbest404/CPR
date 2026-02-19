using UnityEngine;
using UnityEngine.InputSystem;

public class InputControllerHandler : MonoBehaviour
{
    [field: SerializeField]
    private string playerTag = "Player";
    private PlayerHandler playerHandler;
    private InputSystem_Actions inputActions;
    private GameObject playerObject;
    private float moveVector = 0;
    bool active = true;
    int shootingCoolDown;
    void Start()
    {
        shootingCoolDown = 0;
        inputActions = new();
        inputActions.Player.Attack.performed += OnAttackPress;
        inputActions.Player.Move.performed += OnMovement;
        inputActions.Player.Move.canceled += OnMovement;
        inputActions.Player.Reset.performed += OnResetButtonPress;
        inputActions.Player.Enable();
        GetPlayerObject();
        GameManager.instance.ConnectEvent(OnTick);
    }
    void OnDestroy()
    {
        moveVector = 0;
        inputActions.Player.Attack.performed -= OnAttackPress;
        inputActions.Player.Move.performed -= OnMovement;
        inputActions.Player.Move.canceled -= OnMovement;
        inputActions.Player.Reset.performed -= OnResetButtonPress;
        inputActions.Player.Disable();
    }
    void OnTick()
    {
        if (active)
        {
            GetPlayerObject();
            PlayerInvoker.MovePlayer(playerObject, moveVector);
            active = PlayerInvoker.CheckIfCanControlPlayer(playerObject);
            if (shootingCoolDown > 0)
            {
                shootingCoolDown--;
            }
        }
        else
        {
            active = PlayerInvoker.CheckIfCanControlPlayer(playerObject);
            return;
        }
    }
    void GetPlayerObject()
    {
        if (playerObject != null) return;
        GameObject[] potentials = GameObject.FindGameObjectsWithTag(playerTag);
        foreach (GameObject go in potentials)
        {
            if (go.TryGetComponent(out PlayerHandler _))
            {
                playerObject = go;
                break;
            }
        }
        playerHandler = PlayerInvoker.GetPlayerHandler(playerObject);
    }
    void OnResetButtonPress(InputAction.CallbackContext callbackContext)
    {
        if (!callbackContext.ReadValueAsButton()) return;
        Debug.Log("Reset!");
        GameManager.instance.ResetScene();
    }
    void OnAttackPress(InputAction.CallbackContext callbackContext)
    {
        if (!callbackContext.ReadValueAsButton() || !active || shootingCoolDown > 0) return;
        if (playerHandler == null)
        {
            GetPlayerObject();
            return;
        }
        shootingCoolDown = playerHandler.PlayerShootCooldown;
        PlayerInvoker.ShootFromPlayer(playerObject);
    }
    void OnMovement(InputAction.CallbackContext callbackContext)
    {
        if (active == false) return;
        Vector2 _moveVector = callbackContext.ReadValue<Vector2>();
        moveVector = _moveVector.x;
    }
}
