using UnityEngine;
using UnityEngine.InputSystem;

namespace Strategy
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;
        private IMovementStrategy _current;
        private GameplayInput input;

        private void Awake()
        {
            input = new GameplayInput();
            input.Gameplay.Enable();
        }

        private void OnDisable() => input.Gameplay.Disable();

        public void SetStrategy(IMovementStrategy s) => _current = s;

        private void Update()
        {
            Vector3 dir = Vector3.zero;

            if (input.Gameplay.MoveForward.IsPressed()) dir += transform.forward;
            if (input.Gameplay.MoveBackward.IsPressed()) dir -= transform.forward;
            if (input.Gameplay.MoveLeft.IsPressed()) dir -= transform.right;
            if (input.Gameplay.MoveRight.IsPressed()) dir += transform.right;

            if (dir.sqrMagnitude > 0.01f && _current != null)
                _current.Move(transform, dir.normalized, speed);
        }
    }
}