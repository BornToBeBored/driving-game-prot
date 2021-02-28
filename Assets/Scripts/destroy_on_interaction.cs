using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_on_interaction : MonoBehaviour, i_interactable
{
    public float maxrange { get { return maxRange; } }
    private const float maxRange = 100f;
    public GameObject uiprompt;

    
    
    void Start()
    {
        var outline = gameObject.AddComponent<Outline>();
        outline.OutlineMode = Outline.Mode.OutlineVisible;
        outline.OutlineColor = Color.green;
        outline.OutlineWidth = 0f;
    }
    void Update()
    {

    }
   
    public void onstarthover()
    {
        uiprompt.SetActive(true);

        GetComponentInChildren<Outline>().OutlineWidth = 10f;
        
    }
   

    public void oninteraction()
    {
        
        gameObject.SetActive(false);
        
    }

    public void onendhover()
    {
       Debug.Log($"The object has been lost");
       uiprompt.SetActive(false);
       
       GetComponentInChildren<Outline>().OutlineWidth = 0f;
        
    }





}
