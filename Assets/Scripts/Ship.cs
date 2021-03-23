using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public KeyCode up;
    public KeyCode down;
    public KeyCode attack;


    private Rigidbody2D rb;
    public GameObject beam;
    private GameManager gm;

    private Boolean touching = false;
    private Boolean pause = false;

    private float ySpeed = 3.5f;
    private float helium = 50;

    private float seconds = 0;
    private float minutes = 0;
    private float hours = 0;
    private float lifeTimer = 0;





    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        gm = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
     
        if(!pause)
        {
            
            //Ship Movement
            Vector2 newVelocity = rb.velocity;


            if (Input.touchCount > 0 && !touching)
            {
                Instantiate(beam, new Vector3(transform.position.x - 1, transform.position.y, 0), Quaternion.identity);
                touching = true;
            }

            if (Input.touchCount == 0)
            {
                touching = false;
            }

           /* if (Input.GetKeyDown(attack))
            {
                Instantiate(beam, new Vector3(transform.position.x - 1, transform.position.y, 0), Quaternion.identity);
            }
            if (Input.GetKey(up))
            {
                newVelocity.y = ySpeed;
            }
            else if (Input.GetKey(down))
            {
                newVelocity.y = -ySpeed;
            }
            else
            {
                newVelocity.y = 0;
            }*/

            //GYRO MOVEMENT
            newVelocity.y = Input.acceleration.y * 5f;
            rb.velocity = newVelocity;

            if (lifeTimer >= 10) {

                helium -= 5f;
                lifeTimer = 0;
            }

        

            if (helium <= 0) {

                Destroy(gameObject);
                gm.finishGame();
            }

            seconds += Time.deltaTime;
            lifeTimer += Time.deltaTime;
            if (seconds > 60) {

                minutes += 1;
                seconds = 0;
            }

            if (minutes > 60) {

                hours += 1;
                minutes = 0;
            }

            String time = hours + ":" + minutes + ":" + (int)seconds;

            gm.updateTimer(time);
            gm.updateHp(helium.ToString());

        }


        
    }

    public void applyHelium(float ox) {

        this.helium += ox;
        if(helium > 50) helium = 50;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Collision found");
        if (collision.CompareTag("BgHigh") || collision.CompareTag("BgLow"))
        {
            Destroy(gameObject);
            //TODO MAINSCREEN GAME OVER 
            gm.finishGame();
        }
    }

    public void Pause(Boolean pause)
    {
        this.pause = pause;
    }


}
