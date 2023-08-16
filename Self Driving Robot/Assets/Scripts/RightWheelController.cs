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
    private Transform wheelMesh;

    private void Start()
    {
        wheelMesh = transform.Find("Mesh");
    }

    private void FixedUpdate()
    {
        UpdateWheelVisualRotation();
    }
    public float getWheelSpeed()
    {
        return wheelCollider.rpm;
    }
    public float getSteer()
    {
        return wheelCollider.transform.rotation.y;
    }

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

        wheelMesh.transform.position = position;
        wheelMesh.transform.rotation = rotation;
    }

}

