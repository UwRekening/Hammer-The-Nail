using UnityEngine;

namespace DefaultNamespace
{
    /// <summary>
    /// Interface for manually managed collision interactions.
    /// </summary>
    public interface ICollider
    {
        /// <summary>
        /// Called when another collider enters the trigger zone.
        /// </summary>
        /// <param name="other">The Collider that entered.</param>
        void OnTriggerEnter(Collider other);
    }
}