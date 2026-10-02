using UnityEngine;
using UnityEngine.SceneManagement;

public class HowtoManager : MonoBehaviour
{
    //public GameObject howToPanel;

    //private void Start()
    //{
    //    //howToPanel.SetActive(false);
    //}

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void OpenHowTo()
    {
        SceneManager.LoadScene("Howto");
    }
}