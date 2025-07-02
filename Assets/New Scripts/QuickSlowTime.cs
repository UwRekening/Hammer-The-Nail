using System.Collections;
using UnityEngine;
using New_Scripts.Interface;

namespace New_Scripts
{
    /// <summary>
    /// Applies a short slow-motion effect by modifying Time.timeScale temporarily.
    /// Implements ITimeEffect so it can be triggered by nails or events.
    /// </summary>
    public class QuickSlowTime : MonoBehaviour, ITimeEffect
    {
        [SerializeField] private float duration = 1f;       // Duration of the slow-motion effect (in real time)
        [SerializeField] private float timeScale = 0.5f;    // Time slowdown factor

        /// <summary>
        /// Public method to trigger the time-slowing effect.
        /// </summary>
        public void ApplyTimeEffect()
        {
            StartCoroutine(ApplySlowTime());
        }

        /// <summary>
        /// Temporarily slows down time, waits, then resets time to normal.
        /// </summary>
        private IEnumerator ApplySlowTime()
        {
            Time.timeScale = timeScale;

            // Waits using unscaled time to ensure real-time duration
            yield return new WaitForSecondsRealtime(duration);

            Time.timeScale = 1f;
        }
    }
}