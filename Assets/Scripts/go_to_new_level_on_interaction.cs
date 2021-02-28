using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class go_to_new_level_on_interaction : MonoBehaviour, i_interactable
{
    public float maxrange { get { return maxRange; } }
    private const float maxRange = 100f;
    public GameObject uiprompt;


    public void onstarthover()
    {
        uiprompt.SetActive(true);
        
    }

    public void oninteraction()
    {
        SceneManager.LoadScene("garage");
    }

    public void onendhover()
    {
        Debug.Log($"The object has been lost");
        uiprompt.SetActive(false);
        
    }





}
