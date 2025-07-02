using System;
using New_Scripts;
using New_Scripts.Interface;
using UnityEngine;

/// <summary>
/// Represents a nail that can move up/down, trigger effects, and has a limited lifetime.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class Nail : MonoBehaviour, IInteractable
{
    [SerializeField] private float moveStep = 0.2f;
    [SerializeField] private float lifeTime = 60f;

    private Rigidbody _rigidbody;
    private PrefabsSpawner _prefabSpawner;
    private SoundManager _soundManager;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _prefabSpawner = FindObjectOfType<PrefabsSpawner>();
        _soundManager = FindObjectOfType<SoundManager>();
    }

    /// <summary>
    /// Moves the nail slightly downward, plays sound, and triggers camera/time effects.
    /// </summary>
    public void MoveDown()
    {
        GetComponent<ICameraEffect>()?.TriggerEffect();
        GetComponent<ITimeEffect>()?.ApplyTimeEffect();

        _soundManager?.PlaySound(SoundType.NailHit);

        Vector3 target = _rigidbody.position + Vector3.down * moveStep;
        _rigidbody.MovePosition(target);
    }

    /// <summary>
    /// Moves the nail upward (e.g. when "MoveUp" nail is triggered).
    /// </summary>
    public void MoveUp()
    {
        _soundManager?.PlaySound(SoundType.NailHit);

        Vector3 target = _rigidbody.position + Vector3.up * 20f;
        _rigidbody.MovePosition(target);
    }

    /// <summary>
    /// Destroys the nail object.
    /// </summary>
    public void DeleteObject()
    {
        Destroy(gameObject);
    }

    
    /// <summary>
    /// Checks the lifetime of the nail
    /// </summary>
    private void Update()
    {
        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0f)
        {
            Destroy(gameObject);
            _prefabSpawner?.SpawnRandomAmount(1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Avoid tag string by checking for a specific component like PlankIndicator
        if (!other.TryGetComponent<PlankIndicator>(out _)) return;

        if (TryGetComponent<BoxCollider>(out var boxCollider))
        {
            boxCollider.enabled = false;
        }

        _prefabSpawner?.SpawnRandomAmount(1);
        lifeTime = 3f;
    }
}
