using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;
    System.Random rnd = new System.Random();
    int i;
    public float speed;
    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = platform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        i++;
        if(i == 200)
        {
            Instantiate(platform, new Vector2(15, (rnd.Next(-5, 5))), transform.rotation);
            i = 0;
            rb.AddForce(new Vector2(-speed, 0f));
        }
        
        
    }
}
