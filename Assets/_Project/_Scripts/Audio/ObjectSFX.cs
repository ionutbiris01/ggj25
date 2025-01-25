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
        private float _intensity = 0f;   // Local intensity (0 to 1)

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
            _audioSource.volume = _globalVolume * _intensity;
        }
    }
}