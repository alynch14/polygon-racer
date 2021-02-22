using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public interface IRacer 
{ 
    void Accelerate();
    Vector3 Turn();
    Vector3 Glide();
    Vector3 Move();
    Vector3 Boost();
}
