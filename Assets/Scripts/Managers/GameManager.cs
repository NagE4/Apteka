using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton instance for global access
    public static GameManager Instance { get; private set; }

    // Game states
    public enum GameState
    {
        MainMenu,
        Playing,
        Paused,
        EndGame
    }

    // Current game state
    private GameState currentState;

    // Event invoked when the game state changes
    public event Action<GameState> OnGameStateChanged;

    // Day management
    public int day = 1;
    public int maxDays = 10;

    // References to other managers
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private EventManager eventManager;

    // Properties for accessing managers
    public AudioManager AudioManager => audioManager;
    public UIManager UIManager => uiManager;
    public EventManager EventManager => eventManager;

    void Awake()
    {
        // Ensure only one instance of GameManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject); // Prevent duplicate instances
        }

        // Initialize default game state
        SetGameState(GameState.MainMenu);
    }

    /// <summary>
    /// Change the current game state and notify listeners.
    /// </summary>
    /// <param name="newState">The new game state.</param>
    public void SetGameState(GameState newState)
    {
        currentState = newState;

        // Notify all listeners about the state change
        OnGameStateChanged?.Invoke(currentState);

        Debug.Log($"Game State Changed: {currentState}");
    }

    /// <summary>
    /// Handle cleanup when transitioning between scenes.
    /// </summary>
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log($"Scene Loaded: {scene.name}");

        // Update game state based on the loaded scene
        if (scene.name == "MainMenuScene")
        {
            SetGameState(GameState.MainMenu);

            // Play main menu music
            if (audioManager != null && !audioManager.IsMusicPlaying())
            {
                audioManager.PlayMusic("MainMenuMusic");
            }
        }
        else if (scene.name == "SampleScene")
        {
            SetGameState(GameState.Playing);

            // Stop music when entering the game scene
            if (audioManager != null && audioManager.IsMusicPlaying())
            {
                audioManager.StopMusic();
            }
        }
        else if (scene.name == "EndGameScene")
        {
            SetGameState(GameState.EndGame);

            // Optionally stop music in the end game scene
            if (audioManager != null && audioManager.IsMusicPlaying())
            {
                audioManager.StopMusic();
            }
        }
    }

    /// <summary>
    /// Get the current game state.
    /// </summary>
    /// <returns>The current game state.</returns>
    public GameState GetGameState()
    {
        return currentState;
    }

    /// <summary>
    /// Load a specific scene by name.
    /// </summary>
    /// <param name="sceneName">Name of the scene to load.</param>
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// Restart the current scene.
    /// </summary>
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Quit the application.
    /// </summary>
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // For editor testing
#else
        Application.Quit(); // For standalone builds
#endif
    }

    /// <summary>
    /// Pause the game (set time scale to 0).
    /// </summary>
    public void PauseGame()
    {
        Time.timeScale = 0f;
        SetGameState(GameState.Paused);
    }

    /// <summary>
    /// Resume the game (set time scale back to 1).
    /// </summary>
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        SetGameState(GameState.Playing);
    }

    /// <summary>
    /// End the current day and progress to the next day.
    /// </summary>
    public void EndDay()
    {
        day++;
        if (day > maxDays)
        {
            Debug.Log("Game Over!");
            SetGameState(GameState.EndGame);
            LoadScene("EndGameScene");
        }
        else
        {
            Debug.Log("Starting Day " + day);
            // Optionally trigger events or update UI here
            eventManager?.TriggerEvent("NewDayStarted");
        }
    }

    /// <summary>
    /// Reset the game to its initial state (e.g., restart from day 1).
    /// </summary>
    public void ResetGame()
    {
        day = 1;
        SetGameState(GameState.Playing);
        RestartScene();
    }

    private void OnEnable()
    {
        // Subscribe to scene-loaded events
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // Unsubscribe from scene-loaded events
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}