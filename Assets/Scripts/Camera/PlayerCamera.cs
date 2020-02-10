using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public GameObject racer;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(gameObject.transform.position.x - racer.transform.position.x, 0, gameObject.transform.position.z - racer.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {

        gameObject.transform.position = racer.transform.position - offset;
    }
}
