using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enter_on_interaction : MonoBehaviour, i_interactable
{
    public float maxrange { get { return maxRange; } }
    private const float maxRange = 100f;
    public GameObject uiprompt;

    public GameObject character_controller;
    public bool is_in_car= false;
    car_player_controller car_controller;
    public GameObject car_camera;
    public GameObject spawn_point;

    
    void Start()
    {
        car_controller = GetComponentInParent<car_player_controller>();
        character_controller = GameObject.FindWithTag("Player");
        car_camera = GameObject.FindWithTag("car_camera");
        car_controller.enabled = false;
        car_camera.SetActive(false);

        var outline = gameObject.AddComponent<Outline>();
        outline.OutlineMode = Outline.Mode.OutlineVisible;
        outline.OutlineColor = Color.green;
        outline.OutlineWidth = 0f;
    }

    public void onstarthover()
    {
        uiprompt.SetActive(true);
        
        
            GetComponentInChildren<Outline>().OutlineWidth = 10f;
        
    }

    public void oninteraction ()
    {
        if(is_in_car ==false)
        {
            character_controller.transform.parent = gameObject.transform;
            car_controller.enabled = true;
            character_controller.SetActive(false);
            uiprompt.SetActive(false);
            is_in_car = true;
            car_camera.SetActive(true);
        }
       
    }
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.E) && is_in_car==true)
            {
            car_controller.enabled = false;
            character_controller.SetActive(true);
            character_controller.transform.parent = null;
            is_in_car = false;
            car_camera.SetActive(false);
            }

        if (is_in_car)
        {
            GetComponentInChildren<Outline>().OutlineWidth = 0f;
        }
    }
    

    public void onendhover()
    {
        uiprompt.SetActive(false);

        GetComponentInChildren<Outline>().OutlineWidth = 0f;

    }



}
