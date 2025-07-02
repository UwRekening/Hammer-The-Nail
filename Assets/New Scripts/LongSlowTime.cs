using System.Collections;
using UnityEngine;
using New_Scripts.Interface;

namespace New_Scripts
{
    /// <summary>
    /// Applies a temporary slow-motion effect by adjusting Time.timeScale.
    /// Implements ITimeEffect so it can be triggered by nails or events.
    /// </summary>
    public class LongSlowTime : MonoBehaviour, ITimeEffect
    {
        [SerializeField] private float duration = 2f;       // How long the slow effect lasts (in real time)
        [SerializeField] private float timeScale = 0.2f;     // How slow the time becomes

        /// <summary>
        /// Starts the slow-motion effect.
        /// </summary>
        public void ApplyTimeEffect()
        {
            StartCoroutine(ApplySlowTime());
        }

        /// <summary>
        /// Sets Time.timeScale to a slower value, waits in real time, then resets it to normal.
        /// </summary>
        private IEnumerator ApplySlowTime()
        {
            Time.timeScale = timeScale;

            // Wait using unscaled time to avoid being affected by the slowdown
            yield return new WaitForSecondsRealtime(duration);

            Time.timeScale = 1f;
        }
    }
}