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
                
                MoveDown moveDown = clickedObject.GetComponent<MoveDown>();
                MoveUp moveUp = clickedObject.GetComponent<MoveUp>();
                Delete delete = clickedObject.GetComponent<Delete>();
                
                if (interactable != null)
                {
                    foreach (IInteractable onHit in interactable) {
                        if (moveDown != null)
                        {
                            onHit.MoveDown();
                        } else if (moveUp != null)
                        {
                            onHit.MoveUp();
                        } else if (delete != null)
                        {
                            onHit.DeleteObject();
                        }
                    }
                    if (removeTimer != null) {
                        removeTimer.RemoveTime();
                    }
                }
            }
        }
    }
}
