using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndDestory : MonoBehaviour
{
    public GameObject selectionEffect;
    public bool levelEnd = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!levelEnd)
        {
            if (collision.tag == "Planets" || collision.tag == "Bullet")
            {
                Instantiate(selectionEffect, transform.position, Quaternion.identity);
                GameController.Instance.GameOver();
                LevelTime.Instance.updateTime = false;
            }
        }
    }

    public void playEffect()
    {
        Instantiate(selectionEffect, transform.position, Quaternion.identity);
    }

}
