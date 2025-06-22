using UnityEngine;
using Unity.InputSystem;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float distance = 10f;
    public float rotationSpeed = 5f;
    public float zoomSpeed = 1f;

    [SerializeField] private Vector2 currentRotation;
    [SerializeField] private InputAction rotateHorizAction;
    [SerializeField] private InputAction rotateVertAction;
    [SerializeField] private InputAction zoomAction;

    void Awake()
    {
        var controls = new InputActionAsset("CameraControls");
        rotateHorizAction = controls.FindAction("RotateHorizontal");
        rotateVertAction = controls.FindAction("RotateVertical");
        zoomAction = controls.FindAction("Zoom");

        rotateHorizAction.performed += RotateHorizontal;
        rotateVertAction.performed += RotateVertical;
        zoomAction.performed += Zoom;
    }

    void LateUpdate()
    {
        ApplyRotation();
        SetPosition();
    }

    void RotateHorizontal(InputAction.CallbackContext ctx)
    {
        currentRotation.x += ctx.ReadValue<float>() * rotationSpeed;
    }

    void RotateVertical(InputAction.CallbackContext ctx)
    {
        currentRotation.y -= ctx.ReadValue<float>() * rotationSpeed;
    }

    void Zoom(InputAction.CallbackContext ctx)
    {
        distance -= ctx.ReadValue<float>() * zoomSpeed;
        distance = Mathf.Clamp(distance, 5f, 20f);
    }

    void ApplyRotation()
    {
        Quaternion xRot = Quaternion.AngleAxis(currentRotation.x, Vector3.up);
        Quaternion yRot = Quaternion.AngleAxis(currentRotation.y, Vector3.right);
        transform.rotation = xRot * yRot;
    }

    void SetPosition()
    {
        transform.position = target.position + transform.forward * -distance;
    }

    void OnDisable()
    {
        rotateHorizAction.Disable();
        rotateVertAction.Disable();
        zoomAction.Disable();
    }
}