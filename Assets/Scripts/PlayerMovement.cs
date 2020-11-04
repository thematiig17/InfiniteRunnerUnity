﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpPower;
    public float liftingForce;
    public bool jumped;
    public bool doublejumped;
    private Rigidbody2D rb;
    public float startingY;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        startingY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (jumped && transform.position.y<=startingY)
        {
            jumped = false;
            doublejumped = false;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (!jumped)
            {
                rb.velocity = (new Vector2(0f, jumpPower));
                jumped = true;
            }
            if (!doublejumped)
            {
                rb.velocity = (new Vector2(0f, jumpPower));
                doublejumped = true;
            }
        }
        if (Input.GetMouseButton(0))
        {
            rb.AddForce(new Vector2(0f, liftingForce * Time.deltaTime));
        }
    }
}