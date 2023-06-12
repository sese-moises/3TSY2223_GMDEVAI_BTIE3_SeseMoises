using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    public Transform goal;

    public float speed = 0;
    public float brakeSpeed = 0;
    public float rotSpeed = 1;
    public float acceleration = 5;
    public float deceleration = 5;
    public float minSpeed = 0;
    public float maxSpeed = 10;
    public float brakeAngle = 20;
    public float angle;
    void Start()
    {

    }

    void LateUpdate()
    {
        angle = Vector3.Angle(goal.forward, this.transform.forward);

        Vector3 lookAtGoal = new Vector3(goal.position.x, goal.position.y, goal.position.z);

        Vector3 direction = lookAtGoal - this.transform.position;

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed);

        //speed = Mathf.Clamp(speed + (acceleration * Time.deltaTime), minSpeed, maxSpeed);
        if (Vector3.Angle(goal.forward, this.transform.forward) > brakeAngle && speed > brakeSpeed)
        {
            speed = Mathf.Clamp(speed - (deceleration * Time.deltaTime), minSpeed, maxSpeed);
        }
        else
        {
            speed = Mathf.Clamp(speed + (acceleration * Time.deltaTime), minSpeed, maxSpeed);
        }
        this.transform.Translate(0, 0, speed);
    }
}
