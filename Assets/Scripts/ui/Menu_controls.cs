using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_controls : MonoBehaviour
{
    public GameObject mainmenuui;
    public GameObject settingsmenuui;
    public GameObject loadmenuui;
    public void startgame()
    {
        SceneManager.LoadScene("world");
    }
    public void loadgame()
    {
        SceneManager.LoadScene("garage");
    }
    public void settingsmenu()
    {
        settingsmenuui.SetActive(true);
    }
    public void loadmenu()
    {
        loadmenuui.SetActive(true);
    }
    public void exitgame()
    {
        Application.Quit();
        UnityEngine.Debug.Log("Exit game was pressed");
    }
}
