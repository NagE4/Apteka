using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Singleton instance for global access
    public static AudioManager Instance { get; private set; }

    // Audio sources for music and SFX
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    // Dictionary to store AudioClip references
    private Dictionary<string, AudioClip> audioClips = new Dictionary<string, AudioClip>();

    // Volume settings
    private float musicVolume = 1f;
    private float sfxVolume = 1f;

    private void Awake()
    {
        // Ensure only one instance of AudioManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject); // Prevent duplicate instances
        }

        // Initialize audio sources if not assigned in the Inspector
        if (musicSource == null)
        {
            musicSource = gameObject.AddComponent<AudioSource>();
            musicSource.loop = true; // Music should loop by default
        }

        if (sfxSource == null)
        {
            sfxSource = gameObject.AddComponent<AudioSource>();
        }
    }

    /// <summary>
    /// Preload audio clips into the dictionary for quick access.
    /// </summary>
    /// <param name="clips">Array of AudioClips to load.</param>
    public void LoadAudioClips(AudioClip[] clips)
    {
        foreach (var clip in clips)
        {
            if (!audioClips.ContainsKey(clip.name))
            {
                audioClips[clip.name] = clip;
            }
        }
    }

    /// <summary>
    /// Play a specific background music track.
    /// </summary>
    /// <param name="clipName">Name of the AudioClip to play.</param>
    public void PlayMusic(string clipName)
    {
        if (audioClips.TryGetValue(clipName, out AudioClip clip))
        {
            musicSource.clip = clip;
            musicSource.Play();
            Debug.Log($"Playing music: {clipName}");
        }
        else
        {
            Debug.LogWarning($"Music clip '{clipName}' not found!");
        }
    }

    /// <summary>
    /// Stop the currently playing music.
    /// </summary>
    public void StopMusic()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Stop();
            Debug.Log("Stopped music.");
        }
    }

    /// <summary>
    /// Check if music is currently playing.
    /// </summary>
    /// <returns>True if music is playing, false otherwise.</returns>
    public bool IsMusicPlaying()
    {
        return musicSource.isPlaying;
    }
}