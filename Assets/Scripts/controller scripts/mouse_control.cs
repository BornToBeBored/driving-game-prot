using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class mouse_control : MonoBehaviour
{
    //mouse control vars
    public float mouse_sensitivity =100f;
    public Transform player_body;
    private float xrotation = 0f;

    //camera raycasting vars
    public float range;
    private i_interactable currenttarget;
    public Camera maincamera;

    
    void Start()
    {
        
        
    }

    private void Awake()
    {
        maincamera = Camera.main;
    }

    void Update()
    {
        
        //mouse control vars
        float mouse_x = Input.GetAxis("Mouse X") * mouse_sensitivity * Time.deltaTime;
        float mouse_y = Input.GetAxis("Mouse Y") * mouse_sensitivity * Time.deltaTime;
        xrotation -= mouse_y;
        xrotation = Mathf.Clamp(xrotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xrotation, 0f, 0f);
        player_body.Rotate(Vector3.up * mouse_x);

        //camera raycasting
        raycastforinteractable();
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currenttarget != null)
            {
                currenttarget.oninteraction();
                                
            }
        }

    }
    private void raycastforinteractable()
    {
        RaycastHit currentlyhit;
        Ray ray = maincamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out currentlyhit, range))
        {
            i_interactable interactable = currentlyhit.collider.GetComponent<i_interactable>();
            if(interactable != null)
            {
                
                if (currentlyhit.distance <= interactable.maxrange)
                {
                    if (interactable == currenttarget)
                    {
                        return;
                    }
                    else if(currenttarget !=null)
                    {
                        currenttarget.onendhover();
                        currenttarget = interactable;
                        currenttarget.onstarthover();
                        return;
                    }
                    else
                    {
                        currenttarget = interactable;
                        currenttarget.onstarthover();
                        return;
                    }
                }
                else
                {
                    if (currenttarget != null)
                    {
                        currenttarget.onendhover();
                        currenttarget = null;
                        return;
                    }
                }
            }
            else
            {
                if (currenttarget != null)
                {
                    currenttarget.onendhover();
                    currenttarget = null;
                    return;
                }
            }
        }
        else
        {
            if (currenttarget != null)
            {
                currenttarget.onendhover();
                currenttarget = null;
                return;
            }
        }
    }
}
