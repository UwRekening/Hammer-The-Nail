using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    private PrefabsSpawner spawner;
    private List<Score> scores = new List<Score>();
    
    void Start() {
        scores.AddRange(FindObjectsOfType<Score>());
        spawner = FindObjectOfType<PrefabsSpawner>();

        spawner.OnSpawn += CheckForNewScores;
    }

    private void CheckForNewScores(GameObject obj) {
        Score newScore = obj.GetComponent<Score>();
        if (newScore != null && !scores.Contains(newScore)) {
            scores.Add(newScore);
        }
    }

    public int GetScore() {
        int totalScore = 0;
        foreach (Score score in scores) {
            totalScore += score.score;
        }
        return totalScore;
    }

    private void Update() {
        scoreText.text = GetScore().ToString();
    }
    
    private void OnDestroy()
    {
        if (spawner != null)
        {
            spawner.OnSpawn -= CheckForNewScores;
        }
    }
}
