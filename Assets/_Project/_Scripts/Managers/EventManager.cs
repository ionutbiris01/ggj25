using System;
using UnityEngine;
using static Enums;

namespace _Project._Scripts.Managers
{
    public static class EventManager
    {
        
        public static event Action<float> OnCoffeCupIntensityChanged;
        public static event Action<bool> OnCursorVisibilityChanged, OnOptionsPanelToggle, OnMainMenuPanelToggle;

        // Sound Events
        public static event Action<AudioClip> OnPlayMusic, OnPlaySFX, OnPlayDialogue;
        public static event Action<float> OnSetMusicVolume, OnSetSFXVolume, OnSetDialogueVolume;
        public static event Action<bool> OnToggleMusicMute, OnToggleSFXMute, OnToggleDialogueMute;

        // Convai
        public static event Action<ConvaiTriggerType> OnConvaiTriggered;
        
        public static void ChangeCoffeCupIntensity(float intensity) => OnCoffeCupIntensityChanged?.Invoke(intensity);
        public static void ChangeCursorVisibility(bool visible) => OnCursorVisibilityChanged?.Invoke(visible);
        public static void ToggleOptionsPanel(bool value) => OnOptionsPanelToggle?.Invoke(value);
        public static void ToggleMainMenuPanel(bool value) => OnMainMenuPanelToggle?.Invoke(value);

        
        public static void TriggerPlayMusic(AudioClip clip) => OnPlayMusic?.Invoke(clip);
        public static void TriggerPlaySFX(AudioClip clip) => OnPlaySFX?.Invoke(clip);
        public static void TriggerPlayDialogue(AudioClip clip) => OnPlayDialogue?.Invoke(clip);

        public static void TriggerSetMusicVolume(float volume) => OnSetMusicVolume?.Invoke(volume);
        public static void TriggerSetSFXVolume(float volume) => OnSetSFXVolume?.Invoke(volume);
        public static void TriggerSetDialogueVolume(float volume) => OnSetDialogueVolume?.Invoke(volume);

        public static void TriggerToggleMusicMute(bool mute) => OnToggleMusicMute?.Invoke(mute);
        public static void TriggerToggleSFXMute(bool mute) => OnToggleSFXMute?.Invoke(mute);
        public static void TriggerToggleDialogueMute(bool mute) => OnToggleDialogueMute?.Invoke(mute);

        public static void TriggerConvaiTriggered(ConvaiTriggerType triggerType) => OnConvaiTriggered?.Invoke(triggerType);
    }
}
