using System;
using UnityEngine;

namespace _Project._Scripts
{
    public static class EventManager
    {
        public static event Action<float> OnCoffeCupIntensityChanged;
        
        public static void ChangeCoffeCupIntensity(float intensity)
        {
            OnCoffeCupIntensityChanged?.Invoke(intensity);
        }
    }
}
