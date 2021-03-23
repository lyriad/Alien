using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    public float speed = 2f;
    private Rigidbody2D rb;
    private GameManager gm;



    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        gm = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();
        Quaternion rotation = Quaternion.Euler(-1, 0, -90);
        transform.rotation = rotation;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector2(-speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.CompareTag("Balloon") )
        {
            Balloon blon = collision.gameObject.GetComponent<Balloon>();
            Ship ship = GameObject.FindGameObjectWithTag("Ship").GetComponent<Ship>();
            ship.applyHelium(blon.helium);
            blon.playSound();
            Destroy(collision.gameObject);
            Destroy(gameObject);
            gm.applyPoints((int)blon.helium);
            //Debug.Log("i hit");
        }
    }
}
