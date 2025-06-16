using System;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private List<SoundEntry> soundEntries;

    private Dictionary<SoundType, AudioClip> soundDict;

    private void Start() {
        soundEntries.AddRange(FindObjectsOfType<SoundEntry>());
        BuildSoundDictionary();
        
    }


    private void BuildSoundDictionary()
    {
        soundDict = new Dictionary<SoundType, AudioClip>();
        foreach (var entry in soundEntries)
        {
            if (!soundDict.ContainsKey(entry.soundType))
                soundDict.Add(entry.soundType, entry.clip);
        }
    }

    public void PlaySound(SoundType type) {
        if (soundDict.TryGetValue(type, out AudioClip clip)) {
            sfxSource.clip = clip;
            sfxSource.Play();
        }
    }
}