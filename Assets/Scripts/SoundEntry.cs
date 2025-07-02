using System;
using UnityEngine;

/// <summary>
/// Represents a pairing of a sound type and audio clip.
/// Can be used in lists or dictionaries.
/// </summary>
[Serializable]
public class SoundEntry : MonoBehaviour
{
    public SoundType soundType;
    public AudioClip clip;
}
