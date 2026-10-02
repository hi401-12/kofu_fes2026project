using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject gameOverPanel;

    public GameObject clearPanel;

    private void Awake()
    {
        Instance = this;
    }

    public void GameOver()
    {
        Time.timeScale = 0f;

        gameOverPanel.SetActive(true);
    }

    public void Clear()
    {
        Time.timeScale = 0f;

        clearPanel.SetActive(true);
    }

    public void Retry()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }

    public void GoHome()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("Title");
    }
}