using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleFighter : MonoBehaviour
{
    Vector3 direction;
    public GameObject bullet;
    float zMovement = 0;
    public static float MAX_SPEED_Z = 5.0f;
    Vector3 currentEulerAngles;

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
        float zMove = Time.deltaTime;

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
        /*if (Input.GetKey(KeyCode.W))
        {
            yMove = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            yMove = -1;
        }*/
        if (zMovement < 5.0f) {
            zMovement += zMove;
        }

        //gameObject.transform.Translate(new Vector3(0, yMove * Time.deltaTime, (zMove * Time.deltaTime)));
        currentEulerAngles += new Vector3(0, xMove, 0) * Time.deltaTime * 45.0f;
        gameObject.transform.eulerAngles = currentEulerAngles;
        gameObject.transform.Translate(zMovement * Time.deltaTime, 0,0 );
    }
}

