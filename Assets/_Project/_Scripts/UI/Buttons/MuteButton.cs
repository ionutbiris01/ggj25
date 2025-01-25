using System;
using _Project._Scripts.Managers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Project._Scripts.UI.Buttons
{
    public class MuteButton : MonoBehaviour, IPointerClickHandler
    {
        [Header("Sprites")]
        [SerializeField] private Sprite[] sprites; // 0: Unmuted, 1: Muted
        
        [Header("Mute Type")]
        [SerializeField] private MuteType muteType; // Choose between Music, SFX, or Dialogue

        private Image _image;
        private bool _isMuted;

        private void Start()
        {
            _image = GetComponent<Image>();
            InitializeState();
        }

        private void InitializeState()
        {
            // Set the initial state based on the current mute status
            _isMuted = muteType switch
            {
                MuteType.Music => PlayerPrefs.GetInt("MusicMuted", 0) == 1,
                MuteType.SFX => PlayerPrefs.GetInt("SFXMuted", 0) == 1,
                MuteType.Dialogue => PlayerPrefs.GetInt("DialogueMuted", 0) == 1,
                _ => throw new ArgumentOutOfRangeException()
            };

            UpdateSprite();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            // Toggle mute state and trigger appropriate event
            _isMuted = !_isMuted;

            switch (muteType)
            {
                case MuteType.Music:
                    EventManager.TriggerToggleMusicMute(_isMuted);
                    break;
                case MuteType.SFX:
                    EventManager.TriggerToggleSFXMute(_isMuted);
                    break;
                case MuteType.Dialogue:
                    EventManager.TriggerToggleDialogueMute(_isMuted);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            UpdateSprite();
        }

        private void UpdateSprite()
        {
            // Update the sprite based on the mute state
            _image.sprite = _isMuted ? sprites[1] : sprites[0];
        }
    }

    // Enum to differentiate between different mute types
    public enum MuteType
    {
        Music,
        SFX,
        Dialogue
    }
}
