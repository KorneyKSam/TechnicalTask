using UnityEngine;

public class UIMenu : MonoBehaviour
{
    private void Start()
    {
        PauseGame();
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
