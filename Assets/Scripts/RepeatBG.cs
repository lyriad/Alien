using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBG : MonoBehaviour
{

    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;

    private float width;

    private float speed = -3f;

    private void Awake()
    {
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        rb = gameObject.GetComponent<Rigidbody2D>();

        width = boxCollider.size.x;
    }

    // Start is called before the first frame update
    void Start()
    {

        rb.velocity = new Vector2(speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -width)
        {
            reposition();
        }
    }

    private void reposition()
    {
        Vector2 vector = new Vector2(width * 2f, 0);
        transform.position = (Vector2)transform.position + vector;
    }
}
