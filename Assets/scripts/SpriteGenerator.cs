using System.Collections.Generic;
using UnityEngine;

public class SpriteGenerator : MonoBehaviour
{
    [SerializeField] List<Sprite> sprites;
    void Start()
    {
        int i = Random.Range(0, sprites.Count);
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[i];
    }

}
