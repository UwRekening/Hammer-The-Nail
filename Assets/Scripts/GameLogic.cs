using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.SceneManagement;
using DefaultNamespace;

/// <summary>
/// Central game controller for managing game state, timer, end screen, and player input.
/// </summary>
public class GameLogic : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private TMP_Text timeDisplay;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TMP_Text finalScoreText;

    [Header("Game Settings")]
    [SerializeField] private float gameDuration = 60f;

    [Header("Dependencies")]
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private Volume postProcessingVolume;

    private SoundManager soundManager;
    private IPlayerBehaviour[] playerBehaviours;
    private Nail[] nails;

    public float timeRemaining;
    private bool gameOver;
    private bool gameStarted;

    /// <summary>
    /// Initializes references and collects all active player behaviours.
    /// </summary>
    private void Start()
    {
        Time.timeScale = 1f;
        
        soundManager = GetComponent<SoundManager>();
        if (scoreManager == null)
        {
            scoreManager = FindObjectOfType<ScoreManager>();
        }

        timeRemaining = gameDuration;
    }

    /// <summary>
    /// Starts the game and resets all state.
    /// </summary>
    public void StartGame()
    {
        gameStarted = true;
        gameOver = false;
        timeRemaining = gameDuration;
        
        playerBehaviours = FindObjectsOfType<MonoBehaviour>().OfType<IPlayerBehaviour>().ToArray();
        foreach (var behaviour in playerBehaviours)
        {
            if (behaviour is MonoBehaviour mono)
            {
                Debug.unityLogger.Log(behaviour.GetType());
            }
        }
    }

    /// <summary>
    /// Handles the game loop and checks for game over condition.
    /// </summary>
    private void Update()
    {
        if (gameStarted)
        {
            timeRemaining -= Time.deltaTime;
            timeRemaining = Mathf.Max(0, timeRemaining);

            timeDisplay.text = $"{timeRemaining:F2}s";

            if (timeRemaining <= 0 && !gameOver)
            {
                HandleGameOver();
            }
        }
        else if (gameOver)
        {
            Time.timeScale = 0;
        }
    }

    /// <summary>
    /// Triggers game over logic, disables player input, and shows the end screen.
    /// </summary>
    private void HandleGameOver()
    {
        gameOver = true;
        gameStarted = false;

        soundManager.PlaySound(SoundType.TimerOver);

        nails = FindObjectsOfType<Nail>().ToArray();
        
        foreach (Nail nail in nails)
        {
            Destroy(nail.gameObject);
        }

        gameOverScreen.SetActive(true);
        finalScoreText.text = scoreManager.GetTotalScore().ToString();

        if (postProcessingVolume.profile.TryGet(out DepthOfField depthOfField))
        {
            depthOfField.active = true;
        }
    }

    /// <summary>
    /// Reloads the current scene and resets time scale.
    /// </summary>
    public void StartAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// Loads the main menu scene (scene index 0).
    /// </summary>
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
