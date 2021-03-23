using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public enum gColor
{
    Blue = 0,
    Green,
    Orange,
    Purple,
    Red,
    Yellow
}

public class Balloon : MonoBehaviour
{
    public GameObject balloon;
    public static Boolean pausa = false;
    private Dictionary<gColor, Color> colores;
    private Rigidbody2D rb;
    private AudioSource audio;
    public float helium = 1;
   
    // Start is called before the first frame update
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        audio = gameObject.GetComponent<AudioSource>();


        colores = new Dictionary<gColor, Color>
        {
            {gColor.Blue, Color.blue},
            {gColor.Green, Color.green},
            {gColor.Orange, new Color(1,0.4f,0)},
            {gColor.Purple, new Color(0.6f,0,0.6f)},
            {gColor.Red, Color.red},
            {gColor.Yellow, Color.yellow}
        };

        
    }

    void Start()
    {
        if (Random.Range(0, 100f) < 20f)
        {
            gameObject.GetComponent<SpriteRenderer>().color = colores[0];
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = colores[(gColor)Random.Range(1, 6)];
        }

        if(gameObject.GetComponent<SpriteRenderer>().color == colores[0])
        {
            helium = 10;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newVelocity = rb.velocity;
      

        newVelocity.y = (gameObject.GetComponent<SpriteRenderer>().color != colores[0]) ?
            Random.Range(2f, 4.5f) : 
            6.0f
            ;

        rb.velocity = newVelocity;

        if(transform.position.y > 7)
        {
            Destroy(gameObject);
        }
    }

    public IEnumerator playSound()
    {
        audio.gameObject.SetActive(true);
        audio.Play();
        yield return new WaitForSeconds(1);
        
    }

}
