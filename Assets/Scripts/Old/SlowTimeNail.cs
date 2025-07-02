using System.Collections;
using UnityEngine;

/// <summary>
/// Temporarily slows down time when this nail is hit.
/// </summary>
public class SlowTimeNail : MonoBehaviour, IInteractable
{
    [Header("Time Settings")]
    [SerializeField] private float slowDuration = 3f;    // How long the time stays slowed
    [SerializeField] private float timeScale = 0.5f;     // How much to slow down time

    public void MoveDown()
    {
        StartCoroutine(SlowTimeRoutine());
    }

    /// <summary>
    /// Applies the slow-motion effect for the configured duration.
    /// </summary>
    private IEnumerator SlowTimeRoutine()
    {
        Time.timeScale = timeScale;
        yield return new WaitForSecondsRealtime(slowDuration); // Wait in real time to avoid being affected by timeScale
        Time.timeScale = 1f;
    }

    public void MoveUp() { }

    public void DeleteObject() { }
}