using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_player_controller : MonoBehaviour
{
    

    public float motortorque = 1500f;
    public float steerangle = 20f;

    public Transform centerofmass;

    public float steer { get; set; }
    public float throttle { get; set; }
    private wheel_driver[] wheels;

    private Rigidbody _rigidbody;



    void Start()
    {
        wheels = GetComponentsInChildren<wheel_driver>();
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.centerOfMass = centerofmass.localPosition;

    }

    void Update()
    {
        steer = gameManager.Instance.input_controller.steerinput;
        throttle = gameManager.Instance.input_controller.throttleinput;

        foreach(var wheel_driver in wheels)
        {
            wheel_driver.steer_angle = steer * steerangle;
            wheel_driver.torque = throttle * motortorque;
            
        }

        
    }
    
    
    
}


