using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControl : MonoBehaviour
{
    public enum Direction {North, East, South, West};
    public float carSpeed;
    public Direction dir;
    private Rigidbody2D rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        if (dir == Direction.North)
        {
            gameObject.transform.Rotate(new Vector3(0, 0, 270));
        } else if (dir == Direction.South)
        {
            gameObject.transform.Rotate(new Vector3(0, 0, 90));
        }
        else if (dir == Direction.West)
        {
            gameObject.transform.Rotate(new Vector3(0, 0, 180));
        }
    }

    void Update()
    {
        if (dir == Direction.North)
        {
            rb.velocity = new Vector2(0f, carSpeed * 1);  
        } else if (dir == Direction.East)
        {
            rb.velocity = new Vector2(carSpeed * 1, 0f);
        } else if (dir == Direction.South)
        {
            rb.velocity = new Vector2(0f, carSpeed * -1);
        } else if (dir == Direction.West)
        {
            rb.velocity = new Vector2(carSpeed * -1, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().Dead();
        }
    }
}
