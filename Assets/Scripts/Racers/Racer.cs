using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public abstract class Racer
{
    Color myColor { set; get; }
    Color particleColor { set; get; }
    GameObject gameObject;
    public float acceleration = 8f;
    public float gravityMod = 0.1f;
    public float drag = 2f;
    private bool gliding = false;
    private float speedInput = 0f;
    private Rigidbody theRB;
    
    public Racer(string racer)
    {
        gameObject = new GameObject(racer);
        theRB = gameObject.GetComponent<Rigidbody>();
    }

    //Establish classes to inherit/override
    protected Racer()
    {
        Update();
        Accelerate();
        Turn();
        Glide();
        Move();
    }

    //TODO: Assign keypress for float and check
    private void Update()
    {
        float forward = Input.GetAxis("Vertical");
        float right = Input.GetAxis("Horizontal");

        if (Mathf.Abs(forward) > 0)
        {
            Move();
        }
        if(Mathf.Abs(right) > 0)
        {
            Turn();
        }
    }
    
    public void Accelerate()
    {
        theRB.drag = .1f;
        theRB.AddForce(-Vector3.up * gravityMod * 100f);
    }

    public Vector3 Turn()
    {
        //turnInput = Input.GetAxis("Horizontal");
        return Vector3.zero;
    }
    
    //TODO: Implement glide feature
    public Vector3 Glide()
    {
        return Vector3.zero;
    }
    
    public virtual Vector3 Move()
    {
        int xMove = 0, zMove = 0;

        if(Input.GetKey(KeyCode.A))
        {
            speedInput = Input.GetAxis("Vertical") * acceleration;
            //zMove += 1 * (int) Mathf.Sign(gameObject.transform.position.z);
        }
        //TODO: Gliding implementation
        if (!gliding)
        {
            //theRB.drag = dragOnGround;
            //theRB.AddForce(transform.forward * speedInput * 1000f);
        }
        else
        {
           
        }
        return Vector3.back;
    }
}
