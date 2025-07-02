using DefaultNamespace;
using New_Scripts;
using UnityEngine;

/// <summary>
/// When the player enters the trigger, all IInteractable components on the object will receive a MoveUp() call.
/// </summary>
public class MoveUp : MonoBehaviour, ICollider
{
    public void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponent<PlayerIndicator>()) return;

        IInteractable[] interactables = other.GetComponents<IInteractable>();
        foreach (IInteractable target in interactables)
        {
            target.MoveUp();
        }
    }

}