using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Tracks and displays the total score from all active Score components.
/// </summary>
public class ScoreManager : MonoBehaviour
{
    [Header("UI Reference")]
    [SerializeField] private TMP_Text scoreText;

    private PrefabsSpawner spawner;
    private readonly List<Score> scores = new();

    private void Start()
    {
        scores.AddRange(FindObjectsOfType<Score>());

        spawner = FindObjectOfType<PrefabsSpawner>();
        if (spawner != null)
        {
            spawner.OnSpawn += CheckForNewScores;
        }
    }

    private void Update()
    {
        scoreText.text = GetTotalScore().ToString();
    }

    /// <summary>
    /// Returns the sum of all active Score objects.
    /// </summary>
    public int GetTotalScore()
    {
        int total = 0;
        foreach (Score score in scores)
        {
            total += score.GetScore();
        }
        return total;
    }

    /// <summary>
    /// Adds new Score objects when spawned by the spawner.
    /// </summary>
    private void CheckForNewScores(GameObject obj)
    {
        Score newScore = obj.GetComponent<Score>();
        if (newScore != null && !scores.Contains(newScore))
        {
            scores.Add(newScore);
        }
    }

    private void OnDestroy()
    {
        if (spawner != null)
        {
            spawner.OnSpawn -= CheckForNewScores;
        }
    }
}