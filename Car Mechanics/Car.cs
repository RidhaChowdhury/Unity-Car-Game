using UnityEngine;

[CreateAssetMenu(fileName = "Car", menuName = "Stay In Your Lane!/Car", order = 0)]
public class Car : ScriptableObject {
    [SerializeField] float moveSpeed = 50;
    [SerializeField] float maxSpeed = 15;
    [SerializeField] float drag = 0.98f;
    [SerializeField] float steerAngle = 20;
    [SerializeField] float traction = 1;
    [SerializeField] float maxHeading;

}