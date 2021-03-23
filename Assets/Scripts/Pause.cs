using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    private Boolean touching;
    private GameManager gm;

    private void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.touchCount > 0 && !touching)
     {
         gm.Pause();
         touching = true;
     }

     if (Input.touchCount == 0)
     {
         touching = false;
     }

    }
}
