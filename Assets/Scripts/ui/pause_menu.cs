using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause_menu : MonoBehaviour
{
    public static bool ispaused = false;
    public GameObject pausemenuui;

        void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (ispaused)
            {
                resumegame();
            }
            else
            {
                pausegame();
            }
        }
    }
    void resumegame()
    {
        pausemenuui.SetActive(false);
        Time.timeScale = 1f;
        ispaused = false;
    }

    void pausegame()
    {
        pausemenuui.SetActive(true);
        Time.timeScale = 0f;
        ispaused = true;
    }

    public void exittomainmenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main_menu");
    }
    public void savegame()
    {
        SceneManager.LoadScene("garage");
    }
    public void exitgame()
    {
        Application.Quit();
        UnityEngine.Debug.Log("Exit game was pressed");
    }
    
}
