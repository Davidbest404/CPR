using UnityEngine;

namespace Strategy
{
    public class FlyMovement : IMovementStrategy
    {
        public void Move(Transform t, Vector3 dir, float speed) =>
            t.position += Vector3.up * (speed * Time.deltaTime);
    }
}