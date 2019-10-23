using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReadyToQuit : MonoBehaviour
{

    public GameObject yesButton;
    public GameObject  noButton;
    public GameObject leaveText;


    // Start is called before the first frame update
    void Start()
    {
        yesButton.SetActive(false);
        noButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Time.timeScale = 0;
        leaveText.SetActive(true);
        yesButton.SetActive(true);
        noButton.SetActive(true);
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void NoButton()
    {
        Time.timeScale = 1;
        yesButton.SetActive(false);
        noButton.SetActive(false);
        leaveText.SetActive(false);
    }
}
