using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float jumpPower;
    public float liftingForce;
    public bool jumped;
    public bool doublejumped;
    private Rigidbody2D rb;
    public float startingY;
    public Text points;
    public static int numberOfPoints = 0;
    public GameObject player;
    public GameObject Stalker;
    private Animator anime;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        startingY = transform.position.y;
        points.text = "0";
        anime = Stalker.GetComponent<Animator>();
    }

    // Update is called once per frame

    /*private void FixedUpdate()
    {
        for (int i = 0; i < 100; i++)
        {
            if(i == 0)
            {
                startingY = transform.position.y;
            }
            else if (transform.position.y == startingY)
            {
                jumped = false;
                doublejumped = false;
            }
        }
    }*/
    void Update()
    {
        //if (jumped && transform.position.y<=startingY)
        //{
        //    jumped = false;
        //    doublejumped = false;
        //}
        if (Input.GetMouseButtonDown(0))
        {
            if (jumped && !doublejumped)
            {
                rb.velocity = (new Vector2(0f, jumpPower));
                doublejumped = true;
                anime.SetBool("isJumping", true);
            }
            if (!jumped)
            {
                rb.velocity = (new Vector2(0f, jumpPower));
                jumped = true;
                anime.SetBool("isJumping", true);
            }

        }
        if (Input.GetMouseButton(0))
        {
            rb.AddForce(new Vector2(0f, liftingForce * Time.deltaTime));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "coin")
        {
            numberOfPoints++;
            points.text = numberOfPoints.ToString();
            Destroy(collision.gameObject, 0);
        }
        if (collision.gameObject.tag == "ground")
        {
            jumped = false;
            doublejumped = false;
            anime.SetBool("isJumping", false);
        }
        if (collision.gameObject.tag == "trap")
        {
            GameHandler.trapHitted = true;
        }
        if (collision.gameObject.tag == "hp")
        {
            GameHandler.healthGained = true;
            Destroy(collision.gameObject, 0);
        }
    }
}

