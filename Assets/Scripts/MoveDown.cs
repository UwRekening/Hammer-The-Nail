using New_Scripts;
using UnityEngine;

/// <summary>
/// Triggers MoveDown on all IInteractable components when the player enters the trigger zone.
/// </summary>
[RequireComponent(typeof(Collider))]
public class MoveDown : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponent<PlayerIndicator>()) return;

        IInteractable[] interactables = other.GetComponents<IInteractable>();

        foreach (IInteractable target in interactables)
        {
            target.MoveDown();
        }
    }
}