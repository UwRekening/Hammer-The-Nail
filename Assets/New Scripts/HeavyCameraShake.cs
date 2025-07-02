using System.Collections;
using UnityEngine;

namespace New_Scripts
{
    /// <summary>
    /// Triggers a heavy camera shake effect by applying strong random offsets.
    /// </summary>
    public class HeavyCameraShake : MonoBehaviour, ICameraEffect
    {
        [SerializeField] private float duration = 0.4f;   // Total duration of the shake
        [SerializeField] private float magnitude = 0.5f;  // Intensity of the shake

        /// <summary>
        /// Starts the shake coroutine.
        /// </summary>
        public void TriggerEffect()
        {
            StartCoroutine(DoShake());
        }

        /// <summary>
        /// Applies shake to Camera.main using random offsets.
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