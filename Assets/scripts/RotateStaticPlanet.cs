using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateStaticPlanet : MonoBehaviour
{
    public float angle;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, angle);
    }
}
