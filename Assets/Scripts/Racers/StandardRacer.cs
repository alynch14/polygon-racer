using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class StandardRacer : Racer
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Move());
    }
}
