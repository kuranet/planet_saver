using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] GameObject arrowPref;
    Vector2 direction;

    public void Spawn(float angle)
    {
        
        direction = gameObject.GetComponent<Rigidbody2D>().velocity;
        Vector2 vec = transform.position;
        int layerMask = 1 << 9;
        RaycastHit2D hit = Physics2D.Raycast(vec, direction, 100f, layerMask);        

        GameObject arrow = Instantiate(arrowPref);
       
        arrow.transform.Rotate(0, 0, angle);
        arrow.transform.position = hit.point;
        Destroy(arrow, 2.7f);
        
    }

}
