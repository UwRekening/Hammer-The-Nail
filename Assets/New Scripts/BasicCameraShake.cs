using System.Collections;
using UnityEngine;

namespace New_Scripts
{
    /// <summary>
    /// Applies a basic camera shake effect using random offset on Camera.main.
    /// </summary>
    public class BasicCameraShake : MonoBehaviour, ICameraEffect
    {
        [SerializeField] private float duration = 0.2f;   // Duration of the shake in seconds
        [SerializeField] private float magnitude = 0.1f;  // How far the camera moves per shake step

        /// <summary>
        /// Public method to trigger the shake effect.
        /// </summary>
        public void TriggerEffect()
        {
            StartCoroutine(DoShake());
        }

        /// <summary>
        /// Coroutine that shakes the camera by applying random offsets, then resets position.
        /// </summary>
        private IEnumerator DoShake()
        {
            Transform cam = Camera.main.transform;
            Vector3 originalPos = cam.localPosition;

            float elapsed = 0f;

            while (elapsed < duration)
            {
                float x = Random.Range(-1f, 1f) * magnitude;
                float y = Random.Range(-1f, 1f) * magnitude;

                cam.localPosition = originalPos + new Vector3(x, y, 0);

                elapsed += Time.deltaTime;
                yield return null;
            }

            cam.localPosition = originalPos;
        }
    }
}