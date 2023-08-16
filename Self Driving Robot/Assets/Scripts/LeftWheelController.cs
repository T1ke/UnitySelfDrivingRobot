using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class LeftWheelController : MonoBehaviour
{
    // Start is called before the first frame update

    public float MaxmotorTorque = 100f;
    public float maxSteerAngle = 10f;
    public WheelCollider wheelCollider;
    private Transform wheelMesh;

    private void Start()
    {
        wheelMesh = transform.Find("Mesh");
    }

    public float getWheelSpeed()
    {
        return wheelCollider.rpm;
    }
    public float getSteer()
    {
        return wheelCollider.transform.rotation.y;
    }

    private void FixedUpdate()
    {
        UpdateWheelVisualRotation();
    }
    public void Steer(float input)
    {
        wheelCollider.steerAngle = input * maxSteerAngle;
    }
    public void Accelerate(float input)
    {
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
