using System;
using UnityEngine;

namespace CalculatorSystem.Data
{
    [Serializable]
    public class Arg
    {
        [field: SerializeField] public string Name { get; private set; }
    }
}