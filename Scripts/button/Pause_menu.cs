using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_menu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool Gameispaused = false;
    public GameObject pause_menu_ui;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (Gameispaused)
            {
                Resume();
            }
            else {
                Pause();
            }
        }
    }
    void Resume() 
    {
        pause_menu_ui.SetActive(false);
        Time.timeScale = 1f;
        Gameispaused = false;

    }
    void Pause() 
    {
        pause_menu_ui.SetActive(true);
        Time.timeScale = 0f;
        Gameispaused = true;
    }
}
