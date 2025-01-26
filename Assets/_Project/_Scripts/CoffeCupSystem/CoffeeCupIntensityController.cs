using System.Collections;
using _Project._Scripts.Managers;
using UnityEngine;
using UnityEngine.VFX;

namespace _Project._Scripts.CoffeCupSystem
{
    public class CoffeeCupIntensityController : MonoBehaviour
    {
        [SerializeField] private VisualEffect coffeeVFX;
        [SerializeField] private CoffeeCupVFXPropertyConfig propertyConfig;
        [SerializeField] private float lerpSpeed = 0.2f; // Speed of the transition

        private float _currentIntensity = 0f; // Current intensity value
        private Coroutine _lerpCoroutine; // Reference to the active coroutine
        
        private void OnEnable()
        {
            EventManager.OnCoffeCupIntensityChanged += SetIntensity;
        }
        
        private void OnDisable()
        {
            EventManager.OnCoffeCupIntensityChanged -= SetIntensity;
        }

        private void SetIntensity(float targetIntensity)
        {
            // Clamp intensity between 0 and 1
            targetIntensity = Mathf.Clamp01(targetIntensity);

            // If a coroutine is already running, stop it
            if (_lerpCoroutine != null)
            {
                StopCoroutine(_lerpCoroutine);
            }

            // Start a new coroutine to smoothly lerp to the target intensity
            _lerpCoroutine = StartCoroutine(LerpToIntensity(targetIntensity));
        }

        private IEnumerator LerpToIntensity(float targetIntensity)
        {
            // Smoothly transition to the target intensity
            while (!Mathf.Approximately(_currentIntensity, targetIntensity))
            {
                _currentIntensity = Mathf.Lerp(_currentIntensity, targetIntensity, lerpSpeed * Time.deltaTime);
                UpdateVFXProperties(_currentIntensity);
                yield return null; // Wait until the next frame
            }

            // Ensure the final value matches exactly
            _currentIntensity = targetIntensity;
            UpdateVFXProperties(_currentIntensity);
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
