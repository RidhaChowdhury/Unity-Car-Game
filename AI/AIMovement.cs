using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class AIMovement : MonoBehaviour
{
    protected Rigidbody2D rb;
    [SerializeField] protected float carSpeed = 5f;
    [SerializeField] protected float carAcceleration = 2f;
    [SerializeField] protected bool moves = false;
    [SerializeField] protected bool turns = false;
    [SerializeField] protected bool accelerates = false;
    
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    //Movement Loop
    public abstract void Movement();
    
    public void Turn()
    {
        //Turning stuff
    }

    void FixedUpdate()
    {
        Movement();
    }
}
