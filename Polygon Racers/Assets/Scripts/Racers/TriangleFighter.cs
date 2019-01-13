using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleFighter : MonoBehaviour
{
    Vector3 direction;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        if (bullet.CompareTag("Ammo"))
        {
            bullet.GetComponent<BulletScript>().SetVessel("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        float xMove = 0, yMove = 0;
        if (Input.GetMouseButton(0))
        {
            Instantiate(bullet, gameObject.transform, true);
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

        gameObject.transform.Translate(new Vector3(0, yMove * Time.deltaTime, -(xMove * Time.deltaTime)));
    }
}

