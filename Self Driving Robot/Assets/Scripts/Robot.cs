using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public GameObject wheelLeft;
    public GameObject wheelRight;

    private LeftWheelController leftWheelController;
    private RightWheelController rightWheelController;


    private void Start()
    {
        leftWheelController = wheelLeft.GetComponent<LeftWheelController>();
        rightWheelController = wheelRight.GetComponent<RightWheelController>();

    }
    private void FixedUpdate()
    {
        //leftWheelController.Steer(0.001f);
        //rightWheelController.Steer(0.001f);

        //leftWheelController.Accelerate(0.002f);
        //rightWheelController.Accelerate(0.001f);
    }
}
