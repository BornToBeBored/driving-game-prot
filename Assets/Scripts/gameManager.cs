using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
   public static gameManager Instance { get; private set; }
   public Input_Controller input_controller { get; private set; }
   

    void Awake()
    {
        Instance = this;
        input_controller = GetComponentInChildren<Input_Controller>();
    }

    
    void Update()
    {
        
    }
}
