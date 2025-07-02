using System.Collections;
using UnityEngine;

/// <summary>
/// Applies a brief camera shake effect when the nail is hit (MoveDown).
/// </summary>
public class CameraShakeNail : MonoBehaviour, IInteractable
{
    [Header("Shake Settings")]
    [SerializeField] private float duration = 0.2f;    // Duration of the shake
    [SerializeField] private float magnitude = 0.1f;   // Shake strength

    private Transform cameraToShake;
    private Vector3 originalPosition;

    public void MoveDown()
    {
        InitializeCameraReference();

        if (cameraToShake == null) return;

        originalPosition = cameraToShake.localPosition;

        StopAllCoroutines();
        StartCoroutine(DoShake());
    }

    public void MoveUp() { }

    public void DeleteObject() { }

    /// <summary>
    /// Manually triggers a shake (can be called from other scripts).
    /// </summary>
    public void Shake()
    {
        InitializeCameraReference();

        if (cameraToShake == null) return;

        originalPosition = cameraToShake.localPosition;

        StopAllCoroutines();
        StartCoroutine(DoShake());
    }

    /// <summary>
    /// Coroutine that performs the shaking motion.
    /// </summary>
    private IEnumerator DoShake()
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            cameraToShake.localPosition = originalPosition + new Vector3(x, y, 0f);

            elapsed += Time.deltaTime;
            yield return null;
        }

        cameraToShake.localPosition = originalPosition;
    }

    /// <summary>
    /// Caches the camera reference if it hasn't already been set.
    /// </summary>
    private void InitializeCameraReference()
    {
        if (cameraToShake == null && Camera.main != null)
        {
            cameraToShake = Camera.main.transform;
        }
    }
}