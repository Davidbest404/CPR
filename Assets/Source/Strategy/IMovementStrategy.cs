using UnityEngine;

namespace Strategy
{
    public interface IMovementStrategy
    {
        void Move(Transform t, Vector3 direction, float speed);
    }
}