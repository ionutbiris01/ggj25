using System;
using _Project._Scripts;
using _Project._Scripts.Managers;
using UnityEngine;

public class CoffeeCupShake : MonoBehaviour
{
    [Header("Shake Settings")]
    public float shakeIntensity = 0f; // Current shake intensity (0 to 1)
    public float maxShakeAngle = 5f; // Maximum rotation angle (degrees)
    public float shakeSpeed = 20f; // Speed of the shake movement
    public float intensityThreshold = 0.5f; // Intensity required for the shake to start
    public float shakeRiseSpeed = 2f; // Speed at which the shake gradually increases

    private Quaternion _originalRotation;
    private float _currentShakeFactor = 0f; // Tracks the gradual rise of shake intensity

    private void OnEnable()
    {
        EventManager.OnCoffeCupIntensityChanged += SetShakeIntensity;
    }
    
    private void OnDisable()
    {
        EventManager.OnCoffeCupIntensityChanged -= SetShakeIntensity;
    }

    private void Start()
    {
        // Cache the original rotation of the coffee cup
        _originalRotation = transform.localRotation;
    }

    private void Update()
    {
        // Only shake if intensity is above the threshold
        if (shakeIntensity > intensityThreshold)
        {
            // Calculate the target shake factor based on normalized intensity
            var targetShakeFactor = (shakeIntensity - intensityThreshold) / (1f - intensityThreshold);

            // Smoothly increase the current shake factor towards the target
            _currentShakeFactor = Mathf.Lerp(_currentShakeFactor, targetShakeFactor, Time.deltaTime * shakeRiseSpeed);

            // Calculate rotational shake on X and Z axes
            var rotationX = Mathf.Sin(Time.time * shakeSpeed) * _currentShakeFactor * maxShakeAngle;
            var rotationZ = Mathf.Cos(Time.time * shakeSpeed) * _currentShakeFactor * maxShakeAngle;

            // Create the shake rotation using Quaternion.Euler
            var shakeRotation = Quaternion.Euler(rotationX, 0, rotationZ);

            // Combine the shake rotation with the original rotation
            transform.localRotation = _originalRotation * shakeRotation;
        }
        else
        {
            // Gradually reset the shake factor if below the threshold
            _currentShakeFactor = Mathf.Lerp(_currentShakeFactor, 0f, Time.deltaTime * shakeRiseSpeed);

            // Reset to the original rotation
            transform.localRotation = _originalRotation;
        }
    }

    // Method to update shake intensity dynamically
    private void SetShakeIntensity(float intensity)
    {
        shakeIntensity = Mathf.Clamp01(intensity); // Ensure intensity stays between 0 and 1
    }
}
