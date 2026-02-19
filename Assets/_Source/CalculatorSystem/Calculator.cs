using CalculatorSystem.Data;
using System;
using UnityEngine;

namespace CalculatorSystem
{
    public static class Calculator
    {
        private static string _dataPath = "Const/ConstDataSO";
        private static ConstDataSO _constData;
        public static ConstDataSO ConstData
        {
            get
            {
                if (_constData == null)
                {
                    _constData = Resources.Load(_dataPath) as ConstDataSO;
                }
                return _constData;
            }
        }
        public static double GetFallHeight(float time)
        {
            return ConstData.GravityAcceleration * Math.Pow(time, 2) * .5f;
        }
        public static double GetWeightWhileMoveUp(float mass, float acceleration)
        {
            return mass * (ConstData.GravityAcceleration + acceleration);
        }
        public static double GetUniversalGravitationForce(float mass1, float mass2, float radius)
        {
            return (ConstData.GravitationalConstant * mass1 * mass2) / Math.Pow(radius, 2);
        }
        public static double GetWiensDisplacementLaw(float temp)
        {
            return temp * ConstData.WiensConstant;
        }
        public static double GetJouleLenzLaw(float amperage, float resist, float time)
        {
            return Math.Pow(amperage, 2) * time * resist;
        }
    }
}