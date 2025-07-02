namespace DefaultNamespace
{
    /// <summary>
    /// Interface for handling player input behavior.
    /// Allows switching between different input methods like mouse or motion.
    /// </summary>
    public interface IPlayerBehaviour
    {
        /// <summary>
        /// Handles player input each frame.
        /// Should be called from a controller (e.g., PlayerBehaviourSwitcher).
        /// </summary>
        void HandleInput();
    }
}