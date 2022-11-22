using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class SafeDriverMovement : AIMovement
{
    // Update is called once per frame
    public override void Movement()
    {
        rb.velocity = new Vector2(rb.velocity.x, carSpeed);
    }
}
