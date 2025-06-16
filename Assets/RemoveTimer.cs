using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveTimer : MonoBehaviour, IInteractable {
    public int removeTime = 0;
    private GameLogic gameLogic;
    
    private void Start() {
        gameLogic = FindObjectOfType<GameLogic>();
    }

    public void RemoveTime() {
        gameLogic.timeRemaining -= removeTime;
    }
}
