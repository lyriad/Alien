using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideDeath : MonoBehaviour
{

    private BoxCollider2D lowCollide;
    private BoxCollider2D highCollide;
    // Start is called before the first frame update
    private void Awake()
    {
        lowCollide = gameObject.GetComponentInChildren<BoxCollider2D>();
        highCollide = gameObject.GetComponentInChildren<BoxCollider2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
