using UnityEngine;

public class planetMove : MonoBehaviour
{
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    Vector2 target;
    public float minSpeed;
    public float maxSpeed;

    float speed;

    // Start is called before the first frame update
    void Start()
    {
        target = NewDirection();
        speed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Vector2)transform.position != target)
        {
            float newSpeed = speed;
            newSpeed += speed * Time.timeSinceLevelLoad / 50;
            //Debug.Log("NEW SPEED : "+newSpeed);
            transform.position = Vector2.MoveTowards(transform.position, target, newSpeed * Time.deltaTime);
        }
        else
            target = NewDirection();
    }

    Vector2 NewDirection()
    {
        float X = Random.Range(minX, maxX);
        float Y = Random.Range(minY, maxY);
        return new Vector2(X,Y);
        
    }

    
}
