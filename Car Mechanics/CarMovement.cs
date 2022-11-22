using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    Rigidbody2D rb;
    
    [SerializeField] float carSpeed = 5f;
    [SerializeField] float carSlideSpeedMultiplierMultiplier = 5f;
    Vector2 carVelocity;
    
    enum CarTurnStyle {
        Instant,
        Lerp,
        SmoothDamp
    }
    [SerializeField] CarTurnStyle carTurnStyle = CarTurnStyle.Instant;
    
    [SerializeField] float carSmoothDampSpeed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    float last;
    void Update() {
        // Print the difference in position between last frame and this frame
        if(Mathf.Abs(transform.position.x - last) > 0.025) Debug.Log(Mathf.Abs(transform.position.x - last));
        last = transform.position.x;
        // Turning/Sliding the car
        if(Input.GetMouseButton(0)) {
            switch (carTurnStyle)
            {
                case CarTurnStyle.Instant:
                    // Convert mouse screen position to world position and set x position to mouse x world position
                    Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    this.transform.position = new Vector2(mousePos.x, this.transform.position.y);
                    break;
                
                case CarTurnStyle.Lerp:
                    // Convert mouse screen position to world position and lerp towards mouses x world position
                    Vector2 mousePosSmooth = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    this.transform.position = Vector2.Lerp(this.transform.position, new Vector2(mousePosSmooth.x, this.transform.position.y), carSlideSpeedMultiplierMultiplier * Time.deltaTime);
                    break;

                case CarTurnStyle.SmoothDamp:
                    // Convert mouse screen position to world position and smooth damp towards mouses x world position
                    Vector2 mousePosSmoothDamp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    // Smooth damp towards mouse position with a longer time to reach the target the further the mouse is from the car
                    Vector2 carTargetPosition = new Vector2(mousePosSmoothDamp.x, this.transform.position.y);
                    this.transform.position = Vector2.SmoothDamp(this.transform.position, carTargetPosition, ref carVelocity, Vector2.Distance(this.transform.position, carTargetPosition) * carSmoothDampSpeed);
                    break;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(rb.velocity.x, carSpeed);
    }
}
