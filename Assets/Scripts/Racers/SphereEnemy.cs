using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereRacer : MonoBehaviour
{
    const float BASE_FRICTION = 0.5f;
    const float BASE_MAX_SPEED = 15.0f;
    const float BASE_ACCELERATION = 1.5f;
    const int BASE_CHARGE = 5;

    private float currentSpeed;
    private float acceleration;
    private float currentTopSpeed;
    private float currentFriction;

    private Vector3 direction;
    public bool grounded;
    private int charge;
    private int chargeMax;

    private float departureTime;
    private float yAccel;
    private Vector3 rotatedDirection;

    public void Glide()
    {
        if(departureTime-Time.time < 10.0f)
        {
            
        }
    }

    public Vector3 Move()
    {
        throw new System.NotImplementedException();
    }

    public void Turn(bool rightTurn, float x, float y)
    {
        if(rightTurn)
        {
            //rotatedDirection = Vector3.RotateTowards(direction, new Vector3(direction.x, 0, direction.z*Time.deltaTime), currentSpeed*Time.deltaTime, 0.0f);
            gameObject.transform.Rotate(0, Time.deltaTime / currentFriction / currentFriction, 0, Space.Self);
        }
        else
        {
            //rotatedDirection = Vector3.RotateTowards(direction, new Vector3(direction.x * Time.deltaTime, 0, direction.z), currentSpeed*Time.deltaTime, 0.0f);
            gameObject.transform.Rotate(0, -Time.deltaTime / currentFriction / currentFriction, 0, Space.Self);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentTopSpeed = BASE_MAX_SPEED;
        currentSpeed = 0f;
        acceleration = BASE_ACCELERATION;
        currentFriction = BASE_FRICTION;
        direction = Vector3.zero;
        grounded = true;
        charge = 0;
        chargeMax = BASE_CHARGE;
        yAccel = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(new Vector3(0,0,1.0f * Time.deltaTime));
        Debug.DrawRay(gameObject.transform.position, direction, Color.blue);

    }
    //#endif

    //Only executes when car exits the collision with a ramp
    public void OnCollisionExit(Collision collision)
    {
        grounded = false;
        departureTime = Time.time;
    }
}
