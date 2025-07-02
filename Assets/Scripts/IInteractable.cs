using UnityEngine;

/// <summary>
/// Interface for objects that respond to interaction-based movement or deletion.
/// Used by nails, buttons, and other game elements.
/// </summary>
public interface IInteractable
{
    /// <summary>
    /// Moves the object downward.
    /// </summary>
    void MoveDown();

    /// <summary>
    /// Moves the object upward.
    /// </summary>
    void MoveUp();

    /// <summary>
    /// Deletes or removes the object from the scene.
    /// </summary>
    void DeleteObject();
}