using UnityEngine;
using Unity.InputSystem;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private Vector2 movementInput;
    [SerializeField] private bool isJumping;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed && !isJumping)
            Jump();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 moveDir = new Vector3(movementInput.x, 0, movementInput.y);
        transform.Translate(moveDir.normalized * moveSpeed * Time.deltaTime, Space.World);
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isJumping = true;
    }
}