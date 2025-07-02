using UnityEngine;

/// <summary>
/// Manages the score for a single interactable object (like a nail).
/// Adjusts score based on the type of nail interaction.
/// </summary>
public class Score : MonoBehaviour, IInteractable
{
    [SerializeField] private int scoreForNail = 2;
    [SerializeField] private int minScoreForNail = 0;

    private int score = 0;

    /// <summary>
    /// Called when this object is hit or moved down.
    /// Increases or decreases the score based on the nail configuration.
    /// </summary>
    public void MoveDown()
    {
        if (scoreForNail == 0)
        {
            score -= minScoreForNail;
        }
        else
        {
            score += scoreForNail;
        }
    }

    public void MoveUp()
    {
        // Not implemented
    }

    public void DeleteObject()
    {
        // Not implemented
    }

    /// <summary>
    /// Gets the current score for this object.
    /// </summary>
    public int GetScore()
    {
        return score;
    }
}