using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleRacer : MonoBehaviour
{
    Vector3 direction;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        if (bullet.CompareTag("Ammo"))
        {
            bullet.GetComponent<BulletScript>().SetVessel(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float xMove = 0, yMove = 0;
        if (Input.GetMouseButton(0))
        {
            Instantiate(bullet);
        }
        if (Input.GetKey(KeyCode.A))
        {
            xMove = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            xMove = 1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            yMove = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            yMove = -1;
        }

        gameObject.transform.Translate(new Vector3(xMove * Time.deltaTime, yMove * Time.deltaTime));
    }
}

