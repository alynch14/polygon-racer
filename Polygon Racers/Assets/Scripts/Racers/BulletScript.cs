using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    Vector3 myDirection;
    Vector3 shipPosition;
    public GameObject vessel;
    Color myColor;

    public void SetVessel(GameObject vessel)
    {
        this.vessel = vessel;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (vessel.CompareTag("Enemy"))
        {
            myColor = Color.red;
        }
        if (vessel.CompareTag("Player"))
        {
            myColor = Color.blue;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
