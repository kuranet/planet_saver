using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMethod : MonoBehaviour
{
    public void Levels()
    {
        SceneManager.LoadScene("Levels");
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
