using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class CountDown : MonoBehaviour
{
    private PrefabsSpawner spawner;
    private SoundManager soundManager;
    private GameLogic gameLogic;
    
    [SerializeField] private AudioSource countDownAudio;
    [SerializeField] private AudioClip backgroundclip;
    [SerializeField] private GameObject scoreAndTimer;
    [SerializeField] private TMP_Text countDownText;
    [SerializeField] private Volume volume;

    private bool countdownRunning;
    private bool hasStarted;
    
    private float countDownTimer = 5;
    private int previousSecond = 6;
    
    void Start() {
        spawner = GetComponent<PrefabsSpawner>();
        soundManager = GetComponent<SoundManager>();
        gameLogic = GetComponent<GameLogic>();
        
        countDownText.text = "CLICK TO START";
        countDownAudio.Play();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) {
            countDownAudio.Stop();
            hasStarted = true;
            countdownRunning = true;
        }

        if (countdownRunning) {
            if (countDownTimer > 0f) {

                if (volume.profile.TryGet<DepthOfField>(out DepthOfField depthOfField)) {
                    depthOfField.active = true;
                }
                
                countDownTimer -= Time.deltaTime;
                int currentSecond = Mathf.CeilToInt(countDownTimer);

                if (currentSecond != previousSecond) {
                    previousSecond = currentSecond;
                    soundManager.PlaySound(SoundType.CountdownStart);
                }

                countDownText.text = currentSecond.ToString();
            }
            else {
                
                if (volume.profile.TryGet<DepthOfField>(out DepthOfField depthOfField)) {
                    depthOfField.active = false;
                }
                
                countdownRunning = false;
                countDownText.text = "";
                countDownAudio.clip = backgroundclip;
                countDownAudio.Play();
                
                scoreAndTimer.SetActive(true);
                spawner.SpawnRandomAmount(5);
                gameLogic.StartGame();
                soundManager.PlaySound(SoundType.CountdownStop);
                GetComponent<CountDown>().enabled = false;
            }
        }
    }
}
