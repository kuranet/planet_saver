using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CometaSpawn : MonoBehaviour
{
    [SerializeField] GameObject cometaPrefab;

    [SerializeField] float Y;
    [SerializeField] float minX;
    [SerializeField] float maxX;

    [SerializeField] float speed;

    [SerializeField] float deltaTime;
    int numOfCom = 1;

    private void Start()
    {
        StartCoroutine(Spawn(2));
    }
    private void Update()
    {
        
    }
    public IEnumerator Spawn(float time)
    {
        yield return new WaitForSeconds(time);

        float X = Random.Range(minX, maxX);
        Vector2 spawnpoint = new Vector2(X, Y);

        GameObject cometa =  Instantiate(cometaPrefab, spawnpoint, Quaternion.identity);

        float distance = (X - minX) / (maxX - minX);
        float angle = Mathf.Lerp(-60, -120, distance);
        float radians = angle * Mathf.Deg2Rad;
        Debug.Log("ANGLE IS : "+angle + "   RADIANS : " + radians);

        Vector2 velocity = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians));
        Debug.Log("SPAWN VELOCITY : "+velocity.x + "   " + velocity.y);
        cometa.GetComponent<Rigidbody2D>().velocity = velocity*speed;

        cometa.GetComponent<Arrow>().Spawn(360+angle);

        numOfCom++; 
        float newTime = deltaTime / numOfCom;
        Debug.LogWarning("NEW TIME ^ " + newTime);
        if(newTime > 2)
            StartCoroutine(Spawn(newTime));
        else
            StartCoroutine(Spawn(2));
        yield return null;
    }
}
