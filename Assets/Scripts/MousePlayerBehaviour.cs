using DefaultNamespace;
using UnityEngine;

public class MousePlayerBehaviour : MonoBehaviour, IPlayerBehaviour
{
    public void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                GameObject clickedObject = hit.collider.gameObject;
                IInteractable[] interactables = clickedObject.GetComponents<IInteractable>();

                foreach (IInteractable item in interactables)
                {
                    if (clickedObject.GetComponent<MoveDown>()) item.MoveDown();
                    if (clickedObject.GetComponent<MoveUp>()) item.MoveUp();
                    if (clickedObject.GetComponent<Delete>()) item.DeleteObject();
                }
            }
        }
    }
}