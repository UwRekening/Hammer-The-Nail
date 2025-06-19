using System;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private List<SoundEntry> soundEntries = new();

    private Dictionary<SoundType, AudioClip> soundDict = new();
    
    private void Update()
    {
        AddNewSoundEntries();
    }

    private void AddNewSoundEntries()
    {
        foreach (var entry in FindObjectsOfType<SoundEntry>())
        {
            if (!soundEntries.Contains(entry))
            {
                soundEntries.Add(entry);
                if (!soundDict.ContainsKey(entry.soundType))
                    soundDict.Add(entry.soundType, entry.clip);
            }
        }
    }
    
    public void PlaySound(SoundType type)
    {
        if (sfxSource != null && soundDict.TryGetValue(type, out AudioClip clip))
        {
            sfxSource.clip = clip;
            sfxSource.Play();
        }
    }
}