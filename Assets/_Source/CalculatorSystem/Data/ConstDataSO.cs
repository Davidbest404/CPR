using UnityEngine;

namespace CalculatorSystem.Data
{
    [CreateAssetMenu(fileName = "ConstDataSO", menuName = "SO/NewConstData")]
    public class ConstDataSO : ScriptableObject
    {
        [field:SerializeField] public float GravityAcceleration {  get; private set; }
        [field: SerializeField] public float GravitationalConstant { get; private set; }
        [field: SerializeField] public float WiensConstant { get; private set; }
    }
}