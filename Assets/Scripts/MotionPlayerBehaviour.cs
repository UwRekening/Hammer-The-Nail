using DefaultNamespace;
using UnityEngine;

public class MotionPlayerBehaviour : MonoBehaviour, IPlayerBehaviour, ICollider
{
    private bool hasHit = false;

    public void OnTriggerEnter(Collider other)
    {
        if (hasHit) return;

        IInteractable[] interactables = other.GetComponents<IInteractable>();

        if (interactables.Length > 0)
        {
            foreach (IInteractable target in interactables)
            {
                if (other.GetComponent<MoveDown>()) target.MoveDown();
                if (other.GetComponent<MoveUp>()) target.MoveUp();
                if (other.GetComponent<Delete>()) target.DeleteObject();
            }

            hasHit = true; // Zorgt dat we niet meerdere keren triggeren
            Invoke(nameof(ResetHit), 0.5f); // Na 0.5s mag het opnieuw
        }
    }

    private void ResetHit()
    {
        hasHit = false;
    }

    public void HandleInput()
    {
        
    }
}