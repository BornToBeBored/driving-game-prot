using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_Controller : MonoBehaviour
{
    public string inputsteeraxis = "Horizontal";
    public string inputthrotleaxis = "Vertical";
    
    
    public float throttleinput { get; private set; }
    public float steerinput { get; private set; }

    

    void Start()
    {
        
    }

   
    void Update()
    {
        steerinput = Input.GetAxis(inputsteeraxis);
        throttleinput = Input.GetAxis(inputthrotleaxis);

        
    }
    
    
}
