using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Timers;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class GameLogic : MonoBehaviour {
    [SerializeField] private TMP_Text time;
    [SerializeField] private float gameDuration = 60f;
    
    public float timeRemaining;
    private SoundManager soundManager;
    private bool gameOver;
    private bool gameStarted;
    
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] private ScoreManager scoreManager;

    [SerializeField] private Volume _volume;

    private void Start() {
        soundManager = GetComponent<SoundManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
        timeRemaining = gameDuration;
    }

    public void StartGame() {
        gameStarted = true;
    }
    
    private void Update() {
        if (gameStarted) {
            timeRemaining -= Time.deltaTime;
            timeRemaining = Mathf.Max(0, timeRemaining);
            time.text = timeRemaining.ToString("F2") + "s";
        
            if (timeRemaining <= 0 && !gameOver) {
                soundManager.PlaySound(SoundType.TimerOver);
                gameOver = true;
                gameStarted = false;
            }
        } else if (gameOver) {
            Time.timeScale = 0;
            gameOverScreen.SetActive(true);
            scoreText.text = scoreManager.GetScore().ToString();

            if (_volume.profile.TryGet<DepthOfField>(out DepthOfField depthOfField)) {
                depthOfField.active = true;
            }
        }
    }
}
