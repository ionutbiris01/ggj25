using _Project._Scripts.Managers;
using _Project._Scripts.UI.Buttons;
using UnityEngine;
using UnityEngine.UI;

namespace _Project._Scripts
{
    public class AudioSettingsController : MonoBehaviour
    {
        [SerializeField] private Slider musicSlider;
        [SerializeField] private Slider sfxSlider;
        [SerializeField] private Slider dialogueSlider;
        
        private void Start()
        {
            musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
            sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);
            dialogueSlider.value = PlayerPrefs.GetFloat("DialogueVolume", 1f);

            // Add listeners to update settings
            musicSlider.onValueChanged.AddListener(EventManager.TriggerSetMusicVolume);
            sfxSlider.onValueChanged.AddListener(EventManager.TriggerSetSFXVolume);
            dialogueSlider.onValueChanged.AddListener(EventManager.TriggerSetDialogueVolume);
        }
    }
}