using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDestroyer : MonoBehaviour
{
    public GameObject ground;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(ground, new Vector2(17.94f, -5f), transform.rotation);
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="ground")
        {
            Instantiate(ground, new Vector2(17.94f, -5f), transform.rotation);
        }
        Destroy(collision.gameObject, 0);
    }
}
