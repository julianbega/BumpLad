using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFlowController : MonoBehaviour
{
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
    public void GoToShop()
    {
        SceneManager.LoadScene("Shop", LoadSceneMode.Single);
    }
    public void GoToGame()
    {
        SceneManager.LoadScene("Gameplay", LoadSceneMode.Single);
    }
    public void GoToLogs()
    {
        SceneManager.LoadScene("Logs", LoadSceneMode.Single);
    }
    public void UnPause()
    {
        Time.timeScale = 1;
    }
    public void Exit()
    {
        Application.Quit();
    }
}
