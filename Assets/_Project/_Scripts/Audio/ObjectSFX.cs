using System;
using _Project._Scripts.Managers;
using UnityEngine;

namespace _Project._Scripts.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class ObjectSFX : MonoBehaviour
    {
        private AudioSource _audioSource;

        private float _globalVolume = 1f; // SFX volume from SoundManager
        private float _intensity = 0.01f;   // Local intensity (0 to 1)
        private float _targetVolume = 0f;  // Target volume after applying global and intensity
        private Coroutine _volumeLerpCoroutine; // Coroutine for smooth volume transition

        [SerializeField] private float lerpSpeed = 2f; // Speed of the volume lerp

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            EventManager.OnSetSFXVolume += SetGlobalVolume;
            EventManager.OnCoffeCupIntensityChanged += SetIntensity;
            EventManager.OnToggleSFXMute += ToggleMute;
        }

        private void OnDisable()
        {
            EventManager.OnSetSFXVolume -= SetGlobalVolume;
            EventManager.OnCoffeCupIntensityChanged -= SetIntensity;
            EventManager.OnToggleSFXMute -= ToggleMute;
        }

        private void Start()
        {
            // Set initial volume based on current settings
            UpdateVolume();
        }

        private void SetGlobalVolume(float volume)
        {
            _globalVolume = Mathf.Clamp01(volume);
            UpdateVolume();
        }

        private void SetIntensity(float newIntensity)
        {
            _intensity = Mathf.Clamp01(newIntensity);
            UpdateVolume();
        }
        
        private void ToggleMute(bool isMuted)
        {
            _audioSource.mute = isMuted;
        }
        
        private void UpdateVolume()
        {
            // Calculate the new target volume
            _targetVolume = _globalVolume * _intensity;

            // Stop the current lerp coroutine if one is running
            if (_volumeLerpCoroutine != null)
            {
                StopCoroutine(_volumeLerpCoroutine);
            }

            // Start a new lerp coroutine
            _volumeLerpCoroutine = StartCoroutine(LerpVolume(_targetVolume));
        }

        private System.Collections.IEnumerator LerpVolume(float targetVolume)
        {
            float initialVolume = _audioSource.volume;

            // Smoothly transition the volume over time
            while (!Mathf.Approximately(_audioSource.volume, targetVolume))
            {
                _audioSource.volume = Mathf.Lerp(initialVolume, targetVolume, lerpSpeed * Time.deltaTime);
                initialVolume = _audioSource.volume; // Update initialVolume for smooth progression
                yield return null; // Wait for the next frame
            }

            // Ensure the final value matches the target
            _audioSource.volume = targetVolume;
        }
    }
}