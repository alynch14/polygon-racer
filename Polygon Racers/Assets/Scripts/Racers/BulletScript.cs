 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    Vector3 myDirection;
    Vector3 shipPosition;
    string vessel;
    Color myColor;

    public void SetVessel(string vessel)
    {
        this.vessel = vessel;
    }

    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.GetComponentInParent<TriangleFighter>().gameObject.CompareTag("Enemy"))
        {
            myColor = Color.red;
        }
        if (gameObject.GetComponentInParent<TriangleFighter>().gameObject.CompareTag("Player"))
        {
            myColor = Color.blue;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponentInParent<TriangleFighter>().gameObject.CompareTag("Player"))
        {
            myDirection = new Vector3(0, 3.0f * Time.deltaTime, 0);
        }

        gameObject.transform.Translate(myDirection);
    }
}
