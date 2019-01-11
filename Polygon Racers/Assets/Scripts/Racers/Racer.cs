using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Racer
{
    Color myColor { set; get; }
    Color particleColor { set; get; }
    GameObject gameObject;

    public Racer(string racer)
    {
        gameObject = new GameObject(racer);
    }

    public abstract void Accelerate();
    public abstract Vector3 Turn();
    public abstract Vector3 Glide();
    public Vector3 Move()
    {
        int xMove = 0, zMove = 0;

        if(Input.GetKey(KeyCode.A))
        {
            zMove += 1 * (int) Mathf.Sign(gameObject.transform.position.z);
        }
        return Vector3.back;
    }
}
