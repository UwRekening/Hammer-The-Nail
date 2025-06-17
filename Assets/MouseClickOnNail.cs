using UnityEngine;

public class MouseClickOnNail : MonoBehaviour
{
    private void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject clickedObject = hit.collider.gameObject;
                IInteractable[] interactable = clickedObject.GetComponents<IInteractable>();
                RemoveTimer removeTimer = clickedObject.GetComponent<RemoveTimer>();
                
                if (interactable != null)
                {
                    foreach (IInteractable onHit in interactable) {
                        onHit.OnHit();
                    }
                    if (removeTimer != null) {
                        removeTimer.RemoveTime();
                    }
                }
            }
        }
    }
}
