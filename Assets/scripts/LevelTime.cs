using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTime : MonoBehaviour
{
    #region SingleTon
    public static LevelTime Instance { get; private set; }
    #endregion

    [SerializeField] float timeFinish;

    [SerializeField] Text time;

    public bool updateTime = true;

    float timePlayed = 0;
    private void Start()
    {
        Instance = this;
        StartCoroutine(UpDate());
    }
    
    IEnumerator UpDate()
    {
        while (updateTime)
        {
            timePlayed += Time.deltaTime;
            float timeLeft = timeFinish - timePlayed;
            if (timeLeft > 0)
                time.text = timeLeft.ToString("F0");
            else
            {
                GameObject[] planets = GameObject.FindGameObjectsWithTag("Planets");
                foreach (GameObject pl in planets)
                {
                    pl.GetComponent<MoveAndDestory>().levelEnd = true;
                }
                GameController.Instance.NextLevel();
                updateTime = false;
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
