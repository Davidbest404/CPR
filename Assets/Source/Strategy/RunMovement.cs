using UnityEngine;

namespace Strategy
{
    public class RunMovement : IMovementStrategy
    {
        public void Move(Transform t, Vector3 dir, float speed) =>
            t.position += dir * (speed * Time.deltaTime);
    }
}