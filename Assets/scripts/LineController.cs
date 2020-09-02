using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    [SerializeField] Transform start;
    [SerializeField] Transform end;
    
    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<LineRenderer>().SetPosition(0, start.position);
        gameObject.GetComponent<LineRenderer>().SetPosition(1, end.position);
    }
}
