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
    private float TorqOutput = 0.0f;
    private float SteerOutput = 0.0f;

    // Update is called once per frame
    private void FixedUpdate()
    {
        //UpdateWheelVisualRotation();
    }


    private float GetMotorInput()
    {
        return wheelCollider.motorTorque;
    }

    private float GetSteerInput()
    {
        return wheelCollider.steerAngle;
    }

    public void Steer(float input)
    {
        SteerOutput = input * maxSteerAngle + SteerOutput;
        Debug.Log(SteerOutput);
        if (SteerOutput > maxSteerAngle) { SteerOutput = maxSteerAngle; }
        wheelCollider.steerAngle = SteerOutput;

    }
    public void Accelerate(float input)
    {
        if (wheelCollider.motorTorque > motorTorque) { input = 0.0f; }
        wheelCollider.motorTorque += input;
       
        Debug.Log(wheelCollider.motorTorque);
    }


    private void UpdateWheelVisualRotation()
    {
        Vector3 position;
        Quaternion rotation;
        wheelCollider.GetWorldPose(out position, out rotation);

    }

}

