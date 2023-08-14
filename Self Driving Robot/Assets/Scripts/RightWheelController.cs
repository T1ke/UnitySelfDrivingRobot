using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class RightWheelController : MonoBehaviour
{
    // Start is called before the first frame update

    public float motorTorque = 100f;
    public float maxSteerAngle = 30f;
    public WheelCollider wheelCollider;


    // Update is called once per frame
    private void FixedUpdate()
    {
        float motorInput = GetMotorInput();
        float steerInput = GetSteerInput();
        wheelCollider.motorTorque = motorInput * motorTorque;

        // Apply steering angle to the wheel
        wheelCollider.steerAngle = steerInput * maxSteerAngle;

        // Update visual rotation of the wheel mesh
        UpdateWheelVisualRotation();
    }

    private float GetMotorInput()
    {
        return Random.Range(0, motorTorque);
    }

    private float GetSteerInput()
    {
        return Random.Range(-maxSteerAngle, maxSteerAngle);
    }


    private void UpdateWheelVisualRotation()
    {
        Vector3 position;
        Quaternion rotation;
        wheelCollider.GetWorldPose(out position, out rotation);

        // Apply the position and rotation to the visual wheel mesh
        // Assuming you have a "visualWheel" GameObject linked to this script

    }

}

