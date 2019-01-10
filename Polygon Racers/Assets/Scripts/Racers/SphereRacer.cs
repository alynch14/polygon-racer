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

    public Vector3 Glide()
    {
        throw new System.NotImplementedException();
    }

    public Vector3 Move()
    {
        throw new System.NotImplementedException();
    }

    public void Turn(bool rightTurn)
    {
        if(rightTurn)
        {
            direction = Vector3.RotateTowards(direction, Vector3.right, 2.0f, 2.0f);
            gameObject.transform.Rotate(0, 1.0f, 0, Space.Self);
        }
        else
        {
            direction = Vector3.RotateTowards(direction, Vector3.back, 2.0f, 2.0f);
            gameObject.transform.Rotate(0, -1.0f, 0, Space.Self);
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
    }

    // Update is called once per frame
    void Update()
    {
        float xMove = ((currentSpeed == 0)? 1:currentSpeed) * Mathf.Sign(gameObject.transform.position.x);
        float zMove = ((currentSpeed == 0) ? 1 : currentSpeed) * Mathf.Sign(gameObject.transform.position.z);

        if(currentSpeed <= currentTopSpeed)
        {
            currentSpeed++;
        }
#if UNITY_STANDALONE
        if(Input.GetMouseButton(0))
        {
            Deaccelerate();
        }
        else if(Input.GetMouseButtonUp(0))
        {
            direction = new Vector3((currentTopSpeed + charge) * Mathf.Sign(gameObject.transform.position.x), 0, (currentTopSpeed + charge) * Mathf.Sign(gameObject.transform.position.z));
            charge = 0;
        }
        else
        {
            xMove *= Time.deltaTime * acceleration;
            zMove *= Time.deltaTime * acceleration;

            direction = new Vector3(xMove, 0, zMove);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Turn(false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Turn(true);
        }
        
        gameObject.transform.Translate(direction);
    }
#endif
}
