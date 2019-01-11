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

    public void Deaccelerate()
    {
        if (!grounded)
        {
            direction = Vector3.down;
        }
        else
        {
            direction = new Vector3(direction.x/2, direction.y/2);
            if(charge < chargeMax)
            {
                charge++;
            }
        }
    }

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

    public void Turn(bool rightTurn)
    {
        if(rightTurn)
        {
            rotatedDirection = Vector3.RotateTowards(direction, Vector3.back, currentSpeed*Time.deltaTime, 0.0f);
            //gameObject.transform.Rotate(0, 1.0f, 0, Space.Self);
        }
        else
        {
            rotatedDirection = Vector3.RotateTowards(direction, Vector3.right, 2.0f, 2.0f);
            //gameObject.transform.Rotate(0, -1.0f, 0, Space.Self);
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
        float xMove = ((currentSpeed == 0) ? 1 : currentSpeed) * Mathf.Sign(gameObject.transform.position.x);
        float zMove = ((currentSpeed == 0) ? 1 : currentSpeed) * Mathf.Sign(gameObject.transform.position.z);

        if(currentSpeed <= currentTopSpeed)
        {
            currentSpeed++;
        }
//#if UNITY_STANDALONE
        if(Input.GetMouseButton(0))
        {
            Deaccelerate();
        }
        else if(Input.GetMouseButtonUp(0))
        {
            direction = new Vector3((currentTopSpeed + charge), 0, (currentTopSpeed + charge));
            charge = 0;
        }
        else
        {
            //Accelerate till we reach maximum speed
            //acceleration *= Time.deltaTime;
            xMove *= Time.deltaTime;
            zMove *= Time.deltaTime;
            if(xMove > currentTopSpeed)
            {
                xMove = currentTopSpeed;
            }
            if(zMove > currentTopSpeed)
            {
                zMove = currentTopSpeed;
            }
            if (Input.GetKey(KeyCode.A))
            {
                Turn(false);
            }
            if (Input.GetKey(KeyCode.D))
            {
                Turn(true);
            }
            if (!grounded)
            {
                Glide();
            }
            else
            {
                yAccel = 0f;
            }

            direction = new Vector3(xMove, 0, zMove);
        }

        transform.rotation = Quaternion.LookRotation(rotatedDirection);
        gameObject.transform.Translate(direction);
    }
//#endif

    //Only executes when car exits the collision with a ramp
    /*public void OnCollisionExit(Collision collision)
    {
        grounded = false;
        departureTime = Time.time;
    }*/
}
