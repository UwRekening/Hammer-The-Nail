using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages and plays sound effects based on SoundType.
/// </summary>
public class SoundManager : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioSource sfxSource;

    [Header("Sound Database")]
    [SerializeField] private List<SoundEntry> soundEntries = new();

    private readonly Dictionary<SoundType, AudioClip> soundDict = new();
    private readonly HashSet<SoundEntry> knownEntries = new();

    private void Start()
    {
        InitializeSoundDictionary();
    }

    /// <summary>
    /// Populates the internal dictionary from the entry list.
    /// </summary>
    private void InitializeSoundDictionary()
    {
        // Optionally find all SoundEntries in the scene
        SoundEntry[] sceneEntries = FindObjectsOfType<SoundEntry>();
        foreach (var entry in sceneEntries)
        {
            AddSoundEntry(entry);
        }

        // Also add manually assigned ones from Inspector
        foreach (var entry in soundEntries)
        {
            AddSoundEntry(entry);
        }
    }

    /// <summary>
    /// Adds a SoundEntry to the dictionary and internal cache.
    /// </summary>
    private void AddSoundEntry(SoundEntry entry)
    {
        if (entry == null || knownEntries.Contains(entry)) return;

        knownEntries.Add(entry);

        if (!soundDict.ContainsKey(entry.soundType))
        {
            soundDict.Add(entry.soundType, entry.clip);
        }
    }

    /// <summary>
    /// Plays a sound effect corresponding to the specified type.
    /// </summary>
    public void PlaySound(SoundType type)
    {
        if (sfxSource != null && soundDict.TryGetValue(type, out AudioClip clip) && clip != null)
        {
            sfxSource.PlayOneShot(clip); // PlayOneShot is safer
        }
    }
}