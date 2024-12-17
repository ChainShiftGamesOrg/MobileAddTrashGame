using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    [Header("Pause Menu References")]
    public GameObject pauseMenuUI;
    public Button resumeButton;
    public Button RestartButton;
    public Button optionsButton;
    public Button quitButton;

    [Header("Blur Settings")]
    public Image blurOverlay;
    public float blurAmount = 0.5f;

    private bool isPaused = false;

    private void Start()
    {
        // Ensure pause menu is hidden at start
        pauseMenuUI.SetActive(false);

        // Add listeners to buttons
        resumeButton.onClick.AddListener(ResumeGame);
        RestartButton.onClick.AddListener(RestartGame);
        optionsButton.onClick.AddListener(OpenOptions);
        quitButton.onClick.AddListener(QuitGame);
        
    }

    

    private void Update()
    {
        // Check for pause input (typically Escape key)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void PauseGame()
    {
        // Pause the game
        Time.timeScale = 0f;
        isPaused = true;

        // Show pause menu
        pauseMenuUI.SetActive(true);

        // Apply blur effect
        if (blurOverlay != null)
        {
            blurOverlay.gameObject.SetActive(true);
            blurOverlay.color = new Color(0, 0, 0, blurAmount);
        }
    }

    private void ResumeGame()
    {
        // Resume the game
        Time.timeScale = 1f;
        isPaused = false;

        // Hide pause menu
        pauseMenuUI.SetActive(false);

        // Remove blur effect
        if (blurOverlay != null)
        {
            blurOverlay.gameObject.SetActive(false);
        }
    }

    private void OpenOptions()
    {
        // Placeholder for options menu logic
        Debug.Log("Open Options Menu");
    }

    private void QuitGame()
    {
        // Quit application or return to main menu
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}

