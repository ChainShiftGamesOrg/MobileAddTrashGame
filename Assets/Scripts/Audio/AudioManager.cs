using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public AudioClipSO[] AudioClips;

    // Global volume controls
    public FloatVariable MasterVolume;
    public FloatVariable MusicVolume;
    public FloatVariable SFXVolume;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        InitializeAudioSources();
    }
    private void Start()
    {
        PlayAudio(AudioClipNames.BackgroundMusic);
    }

    private void InitializeAudioSources()
    {
        foreach (var audio in AudioClips)
        {
            audio.Source = gameObject.AddComponent<AudioSource>();
            audio.Source.clip = audio.Clip;
            audio.Source.loop = audio.Loop;
            audio.Source.pitch = audio.Pitch;
            UpdateAudioSourceVolume(audio);
        }
    }

    public void PlayAudio(AudioClipNames name)
    {
        AudioClipSO audioClipSO = Array.Find(AudioClips, audio => audio.AudioClipName == name);
        if (audioClipSO == null)
        {
            Debug.LogWarning("AudioClipSO: " + name + " not found!");
            return;
        }
        audioClipSO.Source.Play();
    }

    public void PauseAudio(AudioClipNames name)
    {
        AudioClipSO audioClipSO = Array.Find(AudioClips, audio => audio.AudioClipName == name);
        if (audioClipSO != null)
        {
            audioClipSO.Source.Pause();
        }
    }

    public void PauseAllAudio()
    {
        foreach (var audioClip in AudioClips)
        {
            audioClip.Source.Pause();
        }
    }
    public void ResumeAudio(AudioClipNames name)
    {
        AudioClipSO audioClipSO = Array.Find(AudioClips, audio => audio.AudioClipName == name);
        if (audioClipSO != null)
        {
            audioClipSO.Source.UnPause();
        }
    }

    public void StopAudio(AudioClipNames name)
    {
        AudioClipSO audioClipSO = Array.Find(AudioClips, audio => audio.AudioClipName == name);
        if (audioClipSO != null)
        {
            audioClipSO.Source.Stop();
        }
    }

    public void StopAllAudio()
    {
        foreach (var audioClip in AudioClips)
        {
            audioClip.Source.Stop();
        }
    }

    public IEnumerator FadeAudio(AudioClipNames name, float duration, float targetVolume)
    {
        AudioClipSO audioClipSO = Array.Find(AudioClips, audio => audio.AudioClipName == name);
        if (audioClipSO == null) yield break;

        float startVolume = audioClipSO.Source.volume;
        float time = 0;

        while (time < duration)
        {
            time += Time.deltaTime;
            audioClipSO.Source.volume = Mathf.Lerp(startVolume, targetVolume, time / duration);
            yield return null;
        }

        audioClipSO.Source.volume = targetVolume;
    }

    public void UpdateAllAudioVolumes()
    {
        foreach (var audio in AudioClips)
        {
            UpdateAudioSourceVolume(audio);
        }
    }

    private void UpdateAudioSourceVolume(AudioClipSO audioClip)
    {
        Debug.Log("UpdateAudioSourceVolume");
        // Determine volume based on audio type and global volume settings
        float finalVolume = audioClip.Volume * MasterVolume.Value;

        // Adjust volume based on audio category
        switch (audioClip.Category)
        {
            case AudioCategory.SoundEffect:
                finalVolume *= SFXVolume.Value;
                break;
            case AudioCategory.Music:
                finalVolume *= MusicVolume.Value;
                break;
        }

        audioClip.Source.volume = finalVolume;
    }
}
