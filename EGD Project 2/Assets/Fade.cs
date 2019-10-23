using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    
    private MainMenu menu; 
    
    // Start is called before the first frame update
    void Start()
    {
        menu = GameObject.FindObjectOfType<MainMenu>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FadeDone()
    {
        menu.doneFading = true; 
    }
}
