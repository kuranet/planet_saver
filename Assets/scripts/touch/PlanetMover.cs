using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMover : MonoBehaviour
{
    GameObject[] planets;
    List<touchLocation> touches = new List<touchLocation>();

    // Start is called before the first frame update
    void Start()
    {
        planets = GameObject.FindGameObjectsWithTag("Planets");
    }

    // Update is called once per frame
    void Update()
    {
        int i = 0;
        while(i < Input.touchCount)
        {
            Touch t = Input.GetTouch(i);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(t.position);

            if (t.phase == TouchPhase.Began)
            {
                Collider2D tochedCollider2D = Physics2D.OverlapPoint(touchPosition);
                foreach (GameObject pl in planets)
                {
                    if (pl.GetComponent<Collider2D>() == tochedCollider2D)
                    {
                        touches.Add(new touchLocation(t.fingerId, pl));
                        pl.GetComponent<MoveAndDestory>().playEffect();
                    }
                }
            }
            else if (t.phase == TouchPhase.Moved)
            {
                touchLocation thisTouch = touches.Find(touchLocation => touchLocation.touchID == t.fingerId);
                thisTouch.planet.transform.position = touchPosition; 
            }
            else if (t.phase == TouchPhase.Ended)
            {
                touchLocation thisTouch = touches.Find(touchLocation => touchLocation.touchID == t.fingerId);
                touches.RemoveAt(touches.IndexOf(thisTouch));
            }
            i++;
        }
    }
}
