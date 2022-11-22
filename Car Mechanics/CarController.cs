using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

    // Settings
    [SerializeField] float moveSpeed = 50;
    [SerializeField] float maxSpeed = 15;
    [SerializeField] float drag = 0.98f;
    [SerializeField] float steerAngle = 20;
    [SerializeField] float traction = 1;
    [SerializeField] float maxHeading;
    public float moveForceForwardDot{ get => Vector2.Dot(transform.up, movementForce) * steerInput; private set => moveForceForwardDot = value; }
    
    public float maxMoveForceForwardDot { get => Mathf.Cos(Mathf.Deg2Rad * steerAngle) * maxSpeed; private set => maxMoveForceForwardDot = value; }

    // Variables
    private Vector2 movementForce;
    private float heading;
    public float steerInput{private get; set;}
    public float currentSpeed;
    [SerializeField] bool autoGas = true;

    Rigidbody2D rb;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {

        // Moving
        Vector2 direction = movementForce.magnitude < 1 ? transform.up : movementForce.normalized;
        if(Input.GetAxisRaw("Vertical") > 0 || autoGas) {
            movementForce += direction * moveSpeed * Time.deltaTime;
        }
        rb.velocity = movementForce;
        currentSpeed = movementForce.magnitude;

        // Steering
        heading -= steerInput * movementForce.magnitude * steerAngle * Time.deltaTime;
        heading = Mathf.Clamp(heading, -maxHeading, maxHeading);
        transform.eulerAngles = new Vector3(0, 0, heading);
        
        // Drag and max speed limit
        movementForce *= drag;
        movementForce = Vector2.ClampMagnitude(movementForce, maxSpeed);

        // Traction
        Debug.DrawLine(transform.position, (Vector2)transform.position + movementForce.normalized * 3, Color.red);
        Debug.DrawLine(transform.position, (Vector2)transform.position + (Vector2)transform.up * 2, Color.blue);
        movementForce = Vector2.Lerp(movementForce.normalized, transform.up, traction * Time.deltaTime) * movementForce.magnitude;
    }
}