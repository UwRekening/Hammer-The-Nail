using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour, IInteractable
{
    public float forceToStepsMultiplier = 1f; // How many steps per unit of swing spblob:https://www.bing.com/a47e3128-c4f5-4e95-8779-c4bfdccc3b7deed
    public float minSwingSpeed = 0.5f; 
    
    private Vector3 currentPosition;
    private Vector3 previousPosition;
    private Vector3 velocity;
    
    private void Start() {
        currentPosition = transform.position;
        previousPosition = currentPosition;
    }

    private void Update() {
        previousPosition = currentPosition;
        currentPosition = transform.position;
        velocity = (currentPosition - previousPosition) / Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other) {
        IInteractable interactable = other.gameObject.GetComponent<IInteractable>();
        if (interactable == null) return;

        float swingSpeed = velocity.magnitude;
        if (swingSpeed < minSwingSpeed) return;

        int steps = Mathf.FloorToInt(swingSpeed * forceToStepsMultiplier);
        steps = Mathf.Clamp(steps, 1, 10);

        for (int i = 0; i < steps; i++)
        {
            interactable.OnHit();
        }

        Debug.Log($"Hit with speed {swingSpeed:F2}, moved nail {steps} step(s) down");
    }
}
