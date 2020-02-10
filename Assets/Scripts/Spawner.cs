using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    GameObject enemySpawn;

    public GameObject Spawn()
    {
        Instantiate(enemySpawn);
        return enemySpawn;
    }
}
