using _Project._Scripts.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace _Project._Scripts
{
    public class AudioSettingsController : MonoBehaviour
    {
        [SerializeField] private Slider musicSlider;
        [SerializeField] private Toggle musicMuteToggle;

        [SerializeField] private Slider sfxSlider;
        [SerializeField] private Toggle sfxMuteToggle;

        [SerializeField] private Slider dialogueSlider;
        [SerializeField] private Toggle dialogueMuteToggle;

        private void Start()
        {
            // Initialize UI elements with saved settings
            musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
            musicMuteToggle.isOn = PlayerPrefs.GetInt("MusicMuted", 0) == 1;

            sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);
            sfxMuteToggle.isOn = PlayerPrefs.GetInt("SFXMuted", 0) == 1;

            dialogueSlider.value = PlayerPrefs.GetFloat("DialogueVolume", 1f);
            dialogueMuteToggle.isOn = PlayerPrefs.GetInt("DialogueMuted", 0) == 1;

            // Add listeners to update settings
            musicSlider.onValueChanged.AddListener(EventManager.TriggerSetMusicVolume);
            musicMuteToggle.onValueChanged.AddListener(EventManager.TriggerToggleMusicMute);

            sfxSlider.onValueChanged.AddListener(EventManager.TriggerSetSFXVolume);
            sfxMuteToggle.onValueChanged.AddListener(EventManager.TriggerToggleSFXMute);

            dialogueSlider.onValueChanged.AddListener(EventManager.TriggerSetDialogueVolume);
            dialogueMuteToggle.onValueChanged.AddListener(EventManager.TriggerToggleDialogueMute);
        }
    }
}