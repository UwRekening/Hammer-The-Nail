using UnityEngine;

/// <summary>
/// Reduces the remaining game time when interacted with.
/// </summary>
public class RemoveTime : MonoBehaviour, IInteractable
{
    [SerializeField] private int removeTime = 5; // Time to subtract in seconds

    private GameLogic gameLogic;

    private void Awake()
    {
        // Cache reference to GameLogic at start
        gameLogic = FindObjectOfType<GameLogic>();
    }

    public void MoveDown()
    {
        if (gameLogic == null) return;

        gameLogic.timeRemaining -= removeTime;
    }

    public void MoveUp()
    {
        // Not used in this context
    }

    public void DeleteObject()
    {
        // Not used in this context
    }
}