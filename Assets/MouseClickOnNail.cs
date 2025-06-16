using System;
using System.Collections;
using System.Collections.Generic;
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
                Nail nail = clickedObject.GetComponent<Nail>();
                IInteractable interactable = clickedObject.GetComponent<IInteractable>();
                Score score = clickedObject.GetComponent<Score>();
                RemoveTimer removeTimer = clickedObject.GetComponent<RemoveTimer>();
                
                if (nail != null)
                {
                    interactable.OnHit();
                    score.OnHit();
                    if (removeTimer != null) {
                        removeTimer.RemoveTime();
                    }
                }
            }
        }
    }
}
