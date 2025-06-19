using System;
using UnityEngine;

public class MoveUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        IInteractable[] interactables = other.GetComponents<IInteractable>();

        if (other.CompareTag("Player"))
        {
            foreach (IInteractable hit in interactables)
            {
                hit.MoveUp();
            }
        }
    }
}
