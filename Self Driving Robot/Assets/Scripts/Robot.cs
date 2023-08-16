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
    public Vector3 goal;
    float r = 0.0f; // wheel radius
    float d = 0.0f; // distance between wheels
    private void Start()
    {
        leftWheelController = wheelLeft.GetComponent<LeftWheelController>();
        rightWheelController = wheelRight.GetComponent<RightWheelController>();
        timer = 0.0f;
        d = Vector3.Distance(wheelLeft.transform.position, wheelRight.transform.position);
        r = leftWheelController.wheelCollider.radius;
    }
    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;

        float lWheelRotSpeed = leftWheelController.getWheelSpeed();
        float rWheelRotSpeed = rightWheelController.getWheelSpeed();

        float vr = wheelSpeed(rWheelRotSpeed);
        float vl = wheelSpeed(lWheelRotSpeed);

        float vx;
        float omega;
        (vx, omega) = bodyFrameSpeeds(vr, vl);

        // Apply forces to the wheels
        /*leftWheelController.Accelerate(lwSpeed);
        rightWheelController.Accelerate(rwSpeed);
        leftWheelController.Steer(steeringAngle);
        rightWheelController.Steer(steeringAngle);
        */
        // Update timer
        if(timer >= 2*Mathf.PI)
        {
            timer = 0.0f;
        }
    }

    private float wheelSpeed(float rotSpeed)

    {
        return r * rotSpeed;
    }

    private (float, float) bodyFrameSpeeds(float vr, float vl)
    {
        float vx = 1 / 2 * (vr + vl); // 
        float omega = 1 / d * (vr - vl);

        return (vx, omega);
    }

    private (float, float, float) odometryDiscreteModel(float v, float omega)
    { // x_t = x_t-1 + v dt cos(theta)
        // y_t = y_t-1 + v dt sin(theta)
        // theta_t = theta_t-1 + omega dt
        float x_t = this.transform.position.x + v * Time.fixedDeltaTime * Mathf.Cos(this.transform.rotation.y);
        float y_t = this.transform.position.y + v * Time.fixedDeltaTime * Mathf.Sin(this.transform.rotation.y);
        Vector3 rot = new Vector3(0, omega * Time.deltaTime, 0);
        
        return (0f,0f,0f);

    }
}
