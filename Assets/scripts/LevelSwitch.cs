using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitch : MonoBehaviour
{
    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level + 1);
    }
}
