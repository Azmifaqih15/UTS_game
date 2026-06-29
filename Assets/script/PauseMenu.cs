using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;

    private bool isPaused = false;

    void Start()
    {
        pausePanel.SetActive(false);
    }

    public void PauseGame()
    {
        mobil player = FindObjectOfType<mobil>();

        if (player != null)
        {
            player.enabled = false;
        }
        
        pausePanel.SetActive(true);

        Time.timeScale = 0f;

        isPaused = true;
    }

    public void ResumeGame()
    {
        mobil player = FindObjectOfType<mobil>();

        if (player != null)
        {
            player.enabled = true;
        }

        pausePanel.SetActive(false);

        Time.timeScale = 1f;

        isPaused = false;
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("MainMenu");
    }
}