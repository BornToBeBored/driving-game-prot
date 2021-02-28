using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class player_control : MonoBehaviour
{
    //controller vars
    public CharacterController controller;
    public float walkspeed = 12f;
    public float speed;

    //gravity vars
    public float gravity = -9.81f;
    Vector3 velocity;
    public Transform groundcheck;
    public float grounddistance = 0.4f;
    public LayerMask groundmask;
    bool isgrounded;

    //jump vars
    public float jumpheight = 3f;

    //sprint vars
    public float sprintspeed =24f;
    bool issprinting=false;

    // crouch vars
    public float crouchspeed = 6f;
    bool iscrouching;

    void Start()
    {
        speed = walkspeed;
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        //controller basic movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        //gravity
        isgrounded = Physics.CheckSphere(groundcheck.position, grounddistance, groundmask);
        if (isgrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        //jump
        jump();

        //sprint
        sprint();

        //crouch
        crouch();    

    }

    //jump
    void jump()
    {
        if (Input.GetButtonDown("Jump") && isgrounded)
        {
            velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);

        }
    }

    //sprint
    void sprint()
    {
       if (Input.GetKeyDown(KeyCode.LeftShift) && isgrounded && !iscrouching)
        {
            speed = sprintspeed;
            issprinting = true;
        }
       else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = walkspeed;
            issprinting = false;
        }
    }

    //crouch
    void crouch()
    {
        if (Input.GetKeyDown(KeyCode.C) && isgrounded && !issprinting)
        {
            controller.height = 2.0f;
            iscrouching = true;
            speed = crouchspeed;
        }
        else if (Input.GetKeyUp(KeyCode.C))
        {
            controller.height = 3.0f;
            speed = walkspeed;
            iscrouching = false;
        }
    }
}
