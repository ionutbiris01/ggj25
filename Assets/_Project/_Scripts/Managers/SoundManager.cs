using _Project._Scripts;
using _Project._Scripts.Managers;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioSource dialogueSource;

    [Header("Volume Settings")]
    private float musicVolume = 1f;
    private float sfxVolume = 1f;
    private float dialogueVolume = 1f;
    
    [Header("Audio Clips")]
    [SerializeField] private AudioClip buttonHoverSFX;
    [SerializeField] private AudioClip buttonClickSFX;

    private bool musicMuted = false;
    private bool sfxMuted = false;
    private bool dialogueMuted = false;

    private static SoundManager _instance;
    
    private void OnEnable()
    {
        // Subscribe to events
        EventManager.OnPlayButtonHoverSFX += PlayButtonHoverSFX;
        EventManager.OnPlayButtonClickSFX += PlayButtonClickSFX;
        EventManager.OnPlayMusic += PlayMusic;
        EventManager.OnPlaySFX += PlaySFX;
        EventManager.OnPlayDialogue += PlayDialogue;

        EventManager.OnSetMusicVolume += SetMusicVolume;
        EventManager.OnSetSFXVolume += SetSFXVolume;
        EventManager.OnSetDialogueVolume += SetDialogueVolume;

        EventManager.OnToggleMusicMute += ToggleMusicMute;
        EventManager.OnToggleSFXMute += ToggleSFXMute;
        EventManager.OnToggleDialogueMute += ToggleDialogueMute;
    }

    private void OnDisable()
    {
        // Unsubscribe from events
        EventManager.OnPlayMusic -= PlayMusic;
        EventManager.OnPlaySFX -= PlaySFX;
        EventManager.OnPlayDialogue -= PlayDialogue;

        EventManager.OnSetMusicVolume -= SetMusicVolume;
        EventManager.OnSetSFXVolume -= SetSFXVolume;
        EventManager.OnSetDialogueVolume -= SetDialogueVolume;

        EventManager.OnToggleMusicMute -= ToggleMusicMute;
        EventManager.OnToggleSFXMute -= ToggleSFXMute;
        EventManager.OnToggleDialogueMute -= ToggleDialogueMute;
    }

    private void Awake()
    {
        // Check if an instance already exists
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject); // Destroy the duplicate instance
            return;
        }

        // Set this as the singleton instance
        _instance = this;
        
        DontDestroyOnLoad(gameObject); // Make this GameObject persist across scenes
        
        UpdateDialogueSource();
        LoadSettings();
        ApplyVolumeSettings();
    }
    
    private void UpdateDialogueSource()
    {
        if (dialogueSource == null && NpCReference.Instance != null)
        {
            dialogueSource = NpCReference.Instance.GetComponent<AudioSource>();
        }
    }

    private void PlayMusic(AudioClip clip)
    {
        if (clip == null) return;
        musicSource.clip = clip;
        musicSource.Play();
    }

    private void PlaySFX(AudioClip clip)
    {
        if (clip == null) return;
        sfxSource.PlayOneShot(clip, sfxVolume);
    }
    
    private void PlayButtonHoverSFX()
    {
        PlaySFX(buttonHoverSFX);
    }
    
    private void PlayButtonClickSFX()
    {
        PlaySFX(buttonClickSFX);
    }

    private void PlayDialogue(AudioClip clip)
    {
        if (clip == null) return;
        dialogueSource.Stop(); // Stop any previous dialogue
        dialogueSource.clip = clip;
        dialogueSource.Play();
    }

    private void SetMusicVolume(float volume)
    {
        musicVolume = Mathf.Clamp01(volume);
        SaveSettings();
        ApplyVolumeSettings();
    }

    private void SetSFXVolume(float volume)
    {
        sfxVolume = Mathf.Clamp01(volume);
        SaveSettings();
        ApplyVolumeSettings();
    }

    private void SetDialogueVolume(float volume)
    {
        dialogueVolume = Mathf.Clamp01(volume);
        SaveSettings();
        ApplyVolumeSettings();
    }

    private void ToggleMusicMute(bool mute)
    {
        musicMuted = mute;
        SaveSettings();
        ApplyVolumeSettings();
    }

    private void ToggleSFXMute(bool mute)
    {
        sfxMuted = mute;
        SaveSettings();
        ApplyVolumeSettings();
    }

    private void ToggleDialogueMute(bool mute)
    {
        dialogueMuted = mute;
        SaveSettings();
        ApplyVolumeSettings();
    }

    private void ApplyVolumeSettings()
    {
        UpdateDialogueSource();
        
        musicSource.volume = musicVolume;
        sfxSource.volume = sfxVolume;
        
        if (dialogueSource != null)
        {
            dialogueSource.volume = dialogueVolume;
        }
        
        musicSource.mute = musicMuted;
        sfxSource.mute = sfxMuted;
        
        if (dialogueSource != null)
        {
            dialogueSource.mute = dialogueMuted;
        }
    }

    private void SaveSettings()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
        PlayerPrefs.SetFloat("DialogueVolume", dialogueVolume);

        PlayerPrefs.SetInt("MusicMuted", musicMuted ? 1 : 0);
        PlayerPrefs.SetInt("SFXMuted", sfxMuted ? 1 : 0);
        PlayerPrefs.SetInt("DialogueMuted", dialogueMuted ? 1 : 0);

        PlayerPrefs.Save();
    }

    private void LoadSettings()
    {
        musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);
        dialogueVolume = PlayerPrefs.GetFloat("DialogueVolume", 1f);

        musicMuted = PlayerPrefs.GetInt("MusicMuted", 0) == 1;
        sfxMuted = PlayerPrefs.GetInt("SFXMuted", 0) == 1;
        dialogueMuted = PlayerPrefs.GetInt("DialogueMuted", 0) == 1;
    }
}
