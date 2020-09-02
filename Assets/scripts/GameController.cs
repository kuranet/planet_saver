using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    #region SingleTon
    public static GameController Instance { get; private set; }
    #endregion

    [SerializeField] GameObject restartPanel;
    [SerializeField] GameObject nextLevelPanel;

    private void Start()
    {
        Instance = this;
    }

    public void GameOver()
    {
        Invoke("Delay", 0.25f);
    }

    void Delay()
    {
        restartPanel.SetActive(true);
    }

    public void NextLevel()
    {
        nextLevelPanel.SetActive(true);
    }
}
