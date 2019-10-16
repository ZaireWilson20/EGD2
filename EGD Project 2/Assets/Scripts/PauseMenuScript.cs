using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    public DialogueManager diaManager;
    bool paused = false;
    public GameObject[] menuItems;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject x in menuItems)
        {
            x.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("p") && !paused)
        {
            print("pause hit");
            Time.timeScale = 0;
            diaManager.speedMult = 0;

            foreach(GameObject x in menuItems)
            {
                x.SetActive(true);
            }
            paused = true;
        }
        else if(Input.GetKeyDown("p") && paused)
        {
            print("pause hit");
            this.CloseMenu();
        }
    }

    public void CloseMenu()
    {
        if(paused)
        {
            Time.timeScale = 1;
            diaManager.speedMult = 1;

            foreach (GameObject x in menuItems)
            {
                x.SetActive(false);
            }
            paused = false;
        }
    }

    public void CloseGame()
    {
        if(Application.isEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
        
    }
}
