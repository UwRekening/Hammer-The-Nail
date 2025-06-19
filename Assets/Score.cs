using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour, IInteractable
{
    public int score = 0;
    public int scoreForNail = 2;
    public int minScoreForNail = 0;
    
    public void MoveDown() {
        if (scoreForNail == 0) {
            score -= minScoreForNail;
        }
        else {
            score += scoreForNail;
        }
    }

    public void MoveUp() {
    }

    public void DeleteObject()
    {
        
    }
}
