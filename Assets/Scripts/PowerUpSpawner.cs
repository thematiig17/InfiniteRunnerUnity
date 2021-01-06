using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject[] PowerUps;
    public int difficulty;
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
        if (GameHandler.GameSpeed == 4)
        {
            delay = 3;
        }
        if (GameHandler.GameSpeed == 2)
        {
            delay = 6;
        }
        if (rnd.Next(0, 1000) <= difficulty && timeFromSpawn >= delay)
        {
            Instantiate(PowerUps[rnd.Next(0,PowerUps.Length)], new Vector2(transform.position.x, spawnpoints[rnd.Next(0, spawnpoints.Length)]), transform.rotation);
            timeFromSpawn = 0;
        }
        timeFromSpawn += Time.deltaTime;

    }
}
