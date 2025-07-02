using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

/// <summary>
/// Responsible for handling the countdown before the game starts.
/// Manages UI, audio, post-processing, and triggers game start logic.
/// </summary>
public class Countdown : MonoBehaviour
{
    [Header("UI & Audio References")]
    [SerializeField] private AudioSource countDownAudio;
    [SerializeField] private AudioClip backgroundClip;
    [SerializeField] private GameObject scoreAndTimer;
    [SerializeField] private TMP_Text countDownText;
    [SerializeField] private TMP_Text instructionText;

    [Header("Post-processing")]
    [SerializeField] private Volume postProcessingVolume;

    [Header("Countdown Settings")]
    [SerializeField] private float countdownDuration = 5f;

    // References to other components on this GameObject
    private PrefabsSpawner spawner;
    private SoundManager soundManager;
    private GameLogic gameLogic;

    private bool countdownRunning = false;
    private bool hasStarted = false;

    private float countdownTimer;
    private int previousSecond;

    /// <summary>
    /// Initializes component references when loaded.
    /// </summary>
    private void Awake()
    {
        spawner = GetComponent<PrefabsSpawner>();
        soundManager = GetComponent<SoundManager>();
        gameLogic = GetComponent<GameLogic>();
    }

    /// <summary>
    /// Sets up initial UI state and plays intro audio.
    /// </summary>
    private void Start()
    {
        countdownTimer = countdownDuration;
        previousSecond = Mathf.CeilToInt(countdownDuration) + 1;

        countDownText.text = "CLICK TO START";
        countDownAudio.Play(); // Plays intro sound
    }

    /// <summary>
    /// Waits for input and handles countdown logic.
    /// </summary>
    private void Update()
    {
        if (!hasStarted && (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)))
        {
            StartCountdown();
        }

        if (countdownRunning)
        {
            UpdateCountdown();
        }
    }

    /// <summary>
    /// Begins the countdown, stops intro audio, and enables depth of field effect.
    /// </summary>
    private void StartCountdown()
    {
        countDownAudio.Stop();
        hasStarted = true;
        countdownRunning = true;

        EnableDepthOfField(true);
    }

    /// <summary>
    /// Updates the countdown timer, displays the current second,
    /// and plays a sound when the number changes.
    /// </summary>
    private void UpdateCountdown()
    {
        if (countdownTimer > 0f)
        {
            countdownTimer -= Time.deltaTime;
            int currentSecond = Mathf.CeilToInt(countdownTimer);

            if (currentSecond != previousSecond)
            {
                previousSecond = currentSecond;
                soundManager.PlaySound(SoundType.CountdownStart);
            }

            countDownText.text = currentSecond.ToString();
        }
        else
        {
            FinishCountdown(); // Countdown finished
        }
    }

    /// <summary>
    /// Ends the countdown, starts the game, and switches UI and visual states.
    /// </summary>
    private void FinishCountdown()
    {
        countdownRunning = false;

        EnableDepthOfField(false); // Disable depth of field

        countDownText.text = "";
        instructionText.text = "";
        countDownAudio.clip = backgroundClip;
        countDownAudio.Play();

        scoreAndTimer.SetActive(true);
        spawner.SpawnRandomAmount(5); // Spawn initial objects
        gameLogic.StartGame();        // Trigger game start

        soundManager.PlaySound(SoundType.CountdownStop);

        enabled = false; // Disable script (no more Update calls)
    }

    /// <summary>
    /// Enables or disables the Depth of Field post-processing effect on the camera.
    /// </summary>
    /// <param name="enabled">True to enable, false to disable</param>
    private void EnableDepthOfField(bool enabled)
    {
        if (postProcessingVolume.profile.TryGet(out DepthOfField depthOfField))
        {
            depthOfField.active = enabled;
        }
    }
}
