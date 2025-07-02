using UnityEngine;

/// <summary>
/// Plays a particle and sound effect when the nail is hit (MoveDown).
/// </summary>
public class NailParticleEmitter : MonoBehaviour, IInteractable
{
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private SoundType soundToPlay = SoundType.NailExplosion;

    private SoundManager soundManager;

    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

    /// <summary>
    /// Called when the nail is hit. Plays particle and sound effect.
    /// </summary>
    public void MoveDown()
    {
        if (particle != null)
        {
            particle.Play();
        }

        if (soundManager != null)
        {
            soundManager.PlaySound(soundToPlay);
        }

        Debug.Log("NailParticleEmitter: MoveDown triggered.");
    }

    public void MoveUp() { }
    public void DeleteObject() { }
}