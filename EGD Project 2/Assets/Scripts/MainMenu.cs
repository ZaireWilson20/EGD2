using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public Animator fade;
    public GameObject intro;
    public GameObject StartBut;
    public GameObject QuitBut; 

    public bool doneFading = false;

    public bool dontDoThis = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (doneFading && !dontDoThis)
        {
            intro.SetActive(true);
            fade.SetBool("Done", true);
            Invoke("ChangeScenes", 5f);
            dontDoThis = true; 

        }
    }

    public void QuitButton()
    {

        Application.Quit();
    }

    public void StartButton()
    {
        fade.SetBool("FadeIn", true);
        StartBut.SetActive(false);
        QuitBut.SetActive(false);
        //SceneManager.LoadScene(4);
    }

    private void ChangeScenes()
    {
        SceneManager.LoadScene(4);
    }

}
