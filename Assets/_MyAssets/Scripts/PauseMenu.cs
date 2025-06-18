using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public CanvasGroup pauseMenuGroup;

    private bool isPaused = false;

    public void TogglePause()
    {
        if (isPaused)
            ResumeGame();
        else
            PauseGame();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
        ShowPauseMenu();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        HidePauseMenu();
    }

    public void GoHome()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("SceneMenu");
    }

    void ShowPauseMenu()
    {
        pauseMenuGroup.alpha = 1;
        pauseMenuGroup.interactable = true;
        pauseMenuGroup.blocksRaycasts = true;
    }

    void HidePauseMenu()
    {
        pauseMenuGroup.alpha = 0;
        pauseMenuGroup.interactable = false;
        pauseMenuGroup.blocksRaycasts = false;
    }
}
