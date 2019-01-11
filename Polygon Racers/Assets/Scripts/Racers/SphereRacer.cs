using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereEnemy : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(new Vector3(0,0,1.0f * Time.deltaTime));
        Debug.DrawRay(gameObject.transform.position, new Vector3()/*direction*/, Color.blue);

    }
    //#endif

    
}
