using UnityEngine;
public enum AudioClipNames
{
    None,
    ButtonClick,
    PlayerJump,
    PlayerDeath,
    PlayerHurt,
    PlayerAttack,
    EnemyDeath,
    EnemyHurt,
    CollectiblePickup,
    LevelComplete,
    GameOver,
    BackgroundMusic
}

public enum AudioCategory
{
    SoundEffect,
    Music,
    UI,
    Environment
}

[CreateAssetMenu(fileName = "New Audio Clip", menuName = "Audio/Audio Clip")]
public class AudioClipSO : ScriptableObject
{
    public AudioClipNames AudioClipName;
    public AudioCategory Category;
    public AudioClip Clip;
    public bool Loop = false;
    [Range(0f, 1f)]
    public float Volume = 1f;
    [Range(-3f, 3f)]
    public float Pitch = 1f;

    [HideInInspector]
    public AudioSource Source { get; set; }
}


