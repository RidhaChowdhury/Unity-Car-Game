using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelManager : MonoBehaviour
{
    [SerializeField] Transform[] frontWheels;
    [SerializeField] CarController driving;
    [SerializeField] float visualSteerAngle = 30f, wheelTurnSpeed = 10f, targetAngle = 0f, currentAngle = 0f;

    // Update is called once per frame
    void Update()
    {
        targetAngle = Input.GetAxisRaw("Horizontal") * visualSteerAngle;
        currentAngle = Mathf.Lerp(currentAngle, targetAngle, wheelTurnSpeed * Time.deltaTime);
        for(int i = 0; i < frontWheels.Length; i++) {
            frontWheels[i].localEulerAngles = Vector3.back * currentAngle;
        }
    }
}
