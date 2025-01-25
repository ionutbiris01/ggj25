using System;
using UnityEngine;

namespace _Project._Scripts.Managers
{
    public static class EventManager
    {
        
        public static event Action<float> OnCoffeCupIntensityChanged;
        public static event Action<bool> OnCursorVisibilityChanged, OnOptionsPanelToggle, OnMainMenuPanelToggle;

        // Sound Events
        public static event Action<AudioClip> OnPlayMusic, OnPlaySFX, OnPlayDialogue;
        public static event Action<AudioClip, Vector3> OnPlay3DSFXAtPosition;
        public static event Action<AudioClip, GameObject> OnPlay3DSFXAttached;
        public static event Action<float> OnSetMusicVolume, OnSetSFXVolume, OnSetDialogueVolume;
        public static event Action<bool> OnToggleMusicMute, OnToggleSFXMute, OnToggleDialogueMute;

        
        public static void ChangeCoffeCupIntensity(float intensity) => OnCoffeCupIntensityChanged?.Invoke(intensity);
        public static void ChangeCursorVisibility(bool visible) => OnCursorVisibilityChanged?.Invoke(visible);
        public static void ToggleOptionsPanel(bool value) => OnOptionsPanelToggle?.Invoke(value);
        public static void ToggleMainMenuPanel(bool value) => OnMainMenuPanelToggle?.Invoke(value);

        
        public static void TriggerPlayMusic(AudioClip clip) => OnPlayMusic?.Invoke(clip);
        public static void TriggerPlaySFX(AudioClip clip) => OnPlaySFX?.Invoke(clip);
        public static void TriggerPlayDialogue(AudioClip clip) => OnPlayDialogue?.Invoke(clip);
        public static void TriggerPlay3DSFXAtPosition(AudioClip clip, Vector3 position) => OnPlay3DSFXAtPosition?.Invoke(clip, position);
        public static void TriggerPlay3DSFXAttached(AudioClip clip, GameObject target) => OnPlay3DSFXAttached?.Invoke(clip, target);

        public static void TriggerSetMusicVolume(float volume) => OnSetMusicVolume?.Invoke(volume);
        public static void TriggerSetSFXVolume(float volume) => OnSetSFXVolume?.Invoke(volume);
        public static void TriggerSetDialogueVolume(float volume) => OnSetDialogueVolume?.Invoke(volume);

        public static void TriggerToggleMusicMute(bool mute) => OnToggleMusicMute?.Invoke(mute);
        public static void TriggerToggleSFXMute(bool mute) => OnToggleSFXMute?.Invoke(mute);
        public static void TriggerToggleDialogueMute(bool mute) => OnToggleDialogueMute?.Invoke(mute);
    }
}
