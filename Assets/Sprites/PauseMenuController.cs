using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseMenuUI; // Reference to the Pause Menu UI
    public GameObject confirmMenuUI; // Reference to the Confirmation Menu UI

    private bool isPaused = false;

    void Update()
    {
        // Toggle Pause Menu with the Space bar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isPaused)
                ShowConfirmMenu();
            else
                PauseGame();
        }
    }

    public void ShowConfirmMenu()
    {
        // Show confirmation dialog instead of directly resuming
        pauseMenuUI.SetActive(false);  // Hide Pause Menu
        confirmMenuUI.SetActive(true); // Show Confirm Menu
    }

    public void ConfirmResume()
    {
        // Resume the game when "Yes" is clicked
        confirmMenuUI.SetActive(false); // Hide Confirm Menu
        pauseMenuUI.SetActive(false);   // Hide Pause Menu
        Time.timeScale = 1f;            // Resume game
        isPaused = false;
    }

    public void CancelResume()
    {
        // Return to Pause Menu if "No" is clicked
        confirmMenuUI.SetActive(false); // Hide Confirm Menu
        pauseMenuUI.SetActive(true);    // Show Pause Menu
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);   // Show Pause Menu
        confirmMenuUI.SetActive(false); // Ensure Confirm Menu is hidden
        Time.timeScale = 0f;            // Freeze the game
        isPaused = true;
    }
}
