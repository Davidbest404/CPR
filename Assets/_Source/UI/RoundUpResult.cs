using System;

namespace UI
{
    public static class RoundUpResult
    {
        public static string RoundUp(double value)
        {
            if (value >= 1000000000000)
            {
                return $"Result: {Math.Round(value / 1000000000000, 2)} * 10<sup>12</sup>";
            }
            else if (value >= 1000000000)
            {
                return $"Result: {Math.Round(value / 1000000000, 2)} * 10<sup>9</sup>";
            }
            else if (value >= 1000000)
            {
                return $"Result: {Math.Round(value / 1000000, 2)} * 10<sup>6</sup>";
            }
            else if (value >= 1000)
            {
                return $"Result: {Math.Round(value / 1000, 2)} * 10<sup>3</sup>";
            }
            if (value <= 0.000000000001)
            {
                return $"Result: {Math.Round(value * 1000000000000, 2)} * 10<sup>-12</sup>";
            }
            else if (value <= 0.000000001)
            {
                return $"Result: {Math.Round(value * 1000000000, 2)} * 10<sup>-9</sup>";
            }
            else if (value <= 0.000001)
            {
                return $"Result: {Math.Round(value * 1000000, 2)} * 10<sup>-6</sup>";
            }
            else if (value <= 0.00001)
            {
                return $"Result: {Math.Round(value * 100000, 2)} * 10<sup>-5</sup>";
            }
            else if (value <= 0.0001)
            {
                return $"Result: {Math.Round(value * 10000, 2)} * 10<sup>-4</sup>";
            }
            else if (value <= 0.001)
            {
                return $"Result: {Math.Round(value * 1000, 2)} * 10<sup>-3</sup>";
            }
            else
            {
                return $"Result: {Math.Round(value, 2)}";
            }
        }
    }
}