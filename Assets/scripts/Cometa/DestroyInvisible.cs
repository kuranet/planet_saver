using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInvisible : MonoBehaviour
{
    [SerializeField] float Y;
    
    void Update()
    {
        if (transform.position.y < Y)
            Destroy(gameObject);
    }
}
