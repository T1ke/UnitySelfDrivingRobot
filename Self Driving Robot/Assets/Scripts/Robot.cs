using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public GameObject wheelLeft;
    public GameObject wheelRight;

    private LeftWheelController leftWheelController;
    private RightWheelController rightWheelController;

    public float speed = 5.0f;      // Forward/backward speed
    public float rotationSpeed = 2.0f;  // Rotation speed
    private float timer;

    private void Start()
    {
        leftWheelController = wheelLeft.GetComponent<LeftWheelController>();
        rightWheelController = wheelRight.GetComponent<RightWheelController>();
        timer = 0.0f;

    }
    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;

        float moveForce = speed * Time.fixedDeltaTime;
        float steeringAngle = Mathf.Sin(timer) * Mathf.Rad2Deg; //* 30.0f;
        Debug.Log(steeringAngle);
        float lwSpeed = moveForce;
        float rwSpeed = moveForce;
        if (timer > Mathf.PI)
        {
            lwSpeed = -moveForce;
            rwSpeed = moveForce;
        }
        // Apply forces to the wheels
        leftWheelController.Accelerate(lwSpeed);
        rightWheelController.Accelerate(rwSpeed);
        leftWheelController.Steer(steeringAngle);
        rightWheelController.Steer(-steeringAngle);

        // Update timer
        if(timer >= 2*Mathf.PI)
        {
            timer = 0.0f;
        }
    }
}
