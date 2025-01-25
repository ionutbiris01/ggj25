using _Project._Scripts.Managers;
using UnityEngine;
using UnityEngine.VFX;

namespace _Project._Scripts.CoffeCupSystem
{
    public class CoffeeCupIntensityController : MonoBehaviour
    {
        [SerializeField] private VisualEffect coffeeVFX;
        [SerializeField] private CoffeeCupVFXPropertyConfig propertyConfig; // Reference to the ScriptableObject

        private float _lastIntensity = -1f; // Cache the last intensity value
        
        private void OnEnable()
        {
            EventManager.OnCoffeCupIntensityChanged += SetIntensity;
        }
        
        private void OnDisable()
        {
            EventManager.OnCoffeCupIntensityChanged -= SetIntensity;
        }

        private void SetIntensity(float newIntensity)
        {
            // Clamp intensity between 0 and 1
            var intensity = Mathf.Clamp01(newIntensity);

            // Only update if intensity has changed
            if (Mathf.Approximately(intensity, _lastIntensity)) return;
            UpdateVFXProperties(intensity);
            _lastIntensity = intensity; // Update the cached intensity
        }

        private void UpdateVFXProperties(float intensity)
        {
            foreach (var property in propertyConfig.properties)
            {
                var value = Mathf.Lerp(property.range.x, property.range.y, intensity);

                coffeeVFX.SetFloat(property.propertyName, value);
            }
        }
    }
}
