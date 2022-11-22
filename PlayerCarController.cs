using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCarController : MonoBehaviour
{
    public float steerInput {get; private set;}
    // public bool driftInput {get; private set;} TODO: Add drift input
    CarController car; 
    
    void Awake()
    {
        car = GetComponent<CarController>();
    }

    public void Turn(InputAction.CallbackContext context)
    {
        steerInput = context.ReadValue<float>();
        car.steerInput = steerInput;
    }
}
