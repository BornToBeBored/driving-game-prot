using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheel_driver : MonoBehaviour
{
    public bool steer;
    public bool inverted_steering;
    public bool power;

    public float steer_angle { get; set; }
    public float torque { get; set; }
    private WheelCollider wheelcollider;
    private Transform wheeltransform;

    public bool is_braking=false;
    public bool is_p_braking = false;
    public float braking_torque=500f;

    void Start()
    {
       wheelcollider = GetComponentInChildren<WheelCollider>();
       wheeltransform = GetComponentInChildren<MeshRenderer>().GetComponent<Transform>();
    }

    void Update()
    {
        wheelcollider.GetWorldPose(out Vector3 pos, out Quaternion rot);
        wheeltransform.position = pos;
        wheeltransform.rotation = rot;

        handbrake();
        parkingbrake();
    }

    void FixedUpdate()
    {
        if (steer)
        {
            wheelcollider.steerAngle = steer_angle * (inverted_steering ? -1 : 1);
        }
        if (power && !is_braking && !is_p_braking)
        {
            wheelcollider.motorTorque = torque;
        }
        if (!is_braking && !is_p_braking)
        {
            wheelcollider.brakeTorque = 0;
        }
    }

    void handbrake()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            is_braking = true;
        }
        else
        {
            is_braking = false;
        }
        if (is_braking )
        {
            wheelcollider.brakeTorque = braking_torque * 20;
            wheelcollider.motorTorque = 0;
        }
    }
    
    void parkingbrake()
    {
        if (Input.GetKeyDown(KeyCode.P) && is_p_braking==false)
        {
            is_p_braking = true;
            wheelcollider.brakeTorque = braking_torque * 20;
            wheelcollider.motorTorque = 0;
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            is_p_braking = false;

        }
        
    }
}
