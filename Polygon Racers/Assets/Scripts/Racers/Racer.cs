using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Racer : MonoBehaviour
{
    Color myColor { get; }
    Color particleColor { get; }

    private void Start()
    {
        
    }

    public abstract void Accelerate();
    public abstract Vector3 Turn();
    public abstract Vector3 Glide();
    public abstract Vector3 Move();
}
