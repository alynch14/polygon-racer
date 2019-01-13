using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SceneController : MonoBehaviour
{
    GameObject player;
    GameObject[] enemies = new GameObject[10];
    public GameObject[] spawners = new GameObject[3];
    System.Random random;
    float spawnTime;
    int counter;
    int[] emptyElements;

    // Start is called before the first frame update
    void Start()
    {
        random = new System.Random();
        spawnTime = 0.0f;
        counter = 0;
        emptyElements = new int[10];
    }

    // Update is called once per frame
    void Update()
    {
        float currentTime = Time.time;
        if(currentTime-spawnTime > 10.0f && counter <10)
        {
            for(int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i] == null) emptyElements[enemies.Length - i] = i;
            }
            enemies[counter] = spawners[random.Next(2)].GetComponent<Spawner>().Spawn();
            counter++;
            spawnTime = currentTime;
        }
        if (currentTime - spawnTime < 10.0f && enemies[9] != null)
        {
            bool haveNewSpawn = true;
            for(int i = 9; i>-1 && haveNewSpawn; i--)
            {
                if (emptyElements[i] != 0)
                {
                    enemies[emptyElements[i]] = spawners[random.Next(2)].GetComponent<Spawner>().Spawn();
                    haveNewSpawn = false;
                }
            }
        }
    }
}
