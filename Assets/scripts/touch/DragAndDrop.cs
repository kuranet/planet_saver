using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    bool moveAlloved;
    Collider2D col;

    public GameObject selectionEffect;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.touches[i];
                Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

                if (touch.phase == TouchPhase.Began)
                {
                    Collider2D tochedCollider2D = Physics2D.OverlapPoint(touchPosition);
                    if (col == tochedCollider2D)
                    {
                        Instantiate(selectionEffect, transform.position, Quaternion.identity);
                        moveAlloved = true;
                    }
                }
                if (touch.phase == TouchPhase.Moved)
                {
                    if (moveAlloved)
                    {
                        transform.position = new Vector2(touchPosition.x, touchPosition.y);
                    }
                }
                if (touch.phase == TouchPhase.Ended)
                {
                    moveAlloved = false;
                }
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Planets")
        {
            Instantiate(selectionEffect, transform.position, Quaternion.identity);
            GameController.Instance.GameOver();
            LevelTime.Instance.updateTime = false;
        }
    }
}
