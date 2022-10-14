using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.PlayerLoop;

/**
 * This class establishes a baseline for the default movement of a racer
 * within this game. Each individual racer should inherit from this class
 * and override the appropriate functions to give them their own feel.
 */

public abstract class Racer: MonoBehaviour, IRacer
{
    Color myColor { set; get; }
    Color particleColor { set; get; }
    GameObject gameObject;
    // public float acceleration = 8f;
    public float gravityMod = 0.1f;
    public float drag = 2f;
    private bool gliding = false;
    private float speedInput = 0f;
    private Rigidbody theRB;
    private float baseTopSpeed = 5.0f;
    private float acceleration = 0.1f;
    
    public Racer(string racer)
    {
        gameObject = new GameObject(racer);
        theRB = gameObject.GetComponent<Rigidbody>();
    }

    //Establish classes to inherit/override
    protected Racer()
    {
        
    }

    //TODO: Assign keypress for float and check
    // public void Update()
    // {
    //     float forward = Input.GetAxis("Vertical");
    //     float right = Input.GetAxis("Horizontal");
    //
    //     if (Mathf.Abs(forward) > 0)
    //     {
    //         Move();
    //     }
    //     if(Mathf.Abs(right) > 0)
    //     {
    //         Turn();
    //     }
    // }
    //
    // public void FixedUpdate()
    // {
    //     throw new NotImplementedException();
    // }

    public virtual void Accelerate()
    {
        theRB.drag = .1f;
        theRB.AddForce(-Vector3.up * gravityMod * 100f);
    }

    public virtual Vector3 Turn()
    {
        //turnInput = Input.GetAxis("Horizontal");
        return Vector3.zero;
    }
    
    //TODO: Implement glide feature
    public virtual Vector3 Glide()
    {
        return Vector3.zero;
    }
    
    public virtual Vector3 Move()
    {
        int xMove = 0, zMove = 0;
        float currentSpeed = 1.0f;

        float x = Input.GetAxis("Horizontal");//Input.getAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
		// float z = Input.GetAxis("Vertical");
            //theRB.drag = dragOnGround;
            //theRB.AddForce(transform.forward * speedInput * 1000f);
            if (currentSpeed < baseTopSpeed)
            {
                currentSpeed += acceleration;
            }
        Vector3 movement = new Vector3((x+1) * currentSpeed * Time.deltaTime, 0, (z+1) * currentSpeed * Time.deltaTime);
        return (movement * 2.0f);
    }
    
    public virtual Vector3 Boost()
    {
		return new Vector3();
    }
}
