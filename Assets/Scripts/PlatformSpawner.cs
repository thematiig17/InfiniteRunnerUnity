using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;
    System.Random rnd = new System.Random();
    public float delay;
    float timeFromSpawn;
    public float[] spawnpoints;

    // Start is called before the first frame update
    void Start()
    {
        timeFromSpawn = Time.fixedTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeFromSpawn >= delay)
        {
            Instantiate(platform, new Vector2(transform.position.x, spawnpoints[rnd.Next(0, spawnpoints.Length)]), transform.rotation);
            timeFromSpawn = 0;
        }
        timeFromSpawn += Time.deltaTime;

    }
}
