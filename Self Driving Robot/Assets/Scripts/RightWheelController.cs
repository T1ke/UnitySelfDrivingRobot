using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class RightWheelController : MonoBehaviour
{
    // Start is called before the first frame update

    public float MaxmotorTorque = 100f;
    public float maxSteerAngle = 30f;
    public WheelCollider wheelCollider;


    public void Steer(float input)
    {
        if(input > maxSteerAngle) { input = maxSteerAngle; }
        wheelCollider.steerAngle = input;
    }
    public void Accelerate(float input)
    {
        if (input > MaxmotorTorque) { input = MaxmotorTorque; }
        wheelCollider.motorTorque = input;
    }


    private void UpdateWheelVisualRotation()
    {
        Vector3 position;
        Quaternion rotation;
        wheelCollider.GetWorldPose(out position, out rotation);

        this.transform.position = position;
        this.transform.rotation = rotation;
    }

}

