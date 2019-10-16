using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    // public string dialogueFileLocation;

    public TextAsset dialogueFile;
    public ArrayList dialogueLines;

    public GameObject[] textBoxes;
    int numTextBoxes = 0;

    public float speed = 2;

    public bool isEpilogue = false;

    public int speedMult = 1;


    //public AudioSource audio;
    private AudioClip blackText;
    private AudioClip whiteText;

    float defaultCameraSetting;
    int currentlySpeaking;
    int bufferedLines;

    //public GameObject imageController;
    // Use this for initialization
    void Start()
    {
        // FileInfo file = new FileInfo(dialogueFileLocation);
        // StreamReader reader = file.OpenText();
        //Create an array of Strings based on an input file, where the first line is the number of dialogue lines (DEPRECATED AGAIN)
        //string line = reader.ReadLine();
        string[] fileLines = dialogueFile.text.Split(new char[] { '\n' });
        dialogueLines = new ArrayList(fileLines);


        /* Dialogue lines are of the format: {(integer defining speaker)}(ActualLine)[(integer for delay in seconds)](number of next line or -1 if that's the end of the dialogue)*/
        //1 is black
        //2 is white
        //3 is other

        AquireTextBoxes();

        for(int x = 0; x < numTextBoxes; x++)
        {
            textBoxes[x].SetActive(false);
        }


        currentlySpeaking = -1;
        bufferedLines = -1;
        defaultCameraSetting = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("j"))
        {
            speedMult = 10;
        }
        else if (Input.GetKeyUp("j"))
        {
            speedMult = 1;
        }
    }

    public void PlayDialogueTesting(string input)
    {
        PlayDialogue(int.Parse(input));
    }


    public void PlayDialogue(int input)
    {
        //Debug.Log(input);
        string lineToPrint = (string)dialogueLines[input];

        int locOfOpenBracket = lineToPrint.IndexOf("[");
        int locOfCloseBracket = lineToPrint.IndexOf("]");
        int locOfOpenCurl = lineToPrint.IndexOf("{");
        int locOfCloseCurl = lineToPrint.IndexOf("}");

        string lineActual = lineToPrint.Substring(locOfCloseCurl + 1, lineToPrint.Length - locOfCloseCurl - (lineToPrint.Length - locOfOpenBracket) - 1);
        //Debug.Log(lineActual);

        int speaker = int.Parse(lineToPrint.Substring(locOfOpenCurl + 1, lineToPrint.Length - locOfOpenCurl - (lineToPrint.Length - locOfCloseCurl) - 1));

        float delay = float.Parse(lineToPrint.Substring(locOfOpenBracket + 1, lineToPrint.Length - locOfOpenBracket - (lineToPrint.Length - locOfCloseBracket) - 1));
        //Debug.Log(delay);
        float lineSpeed = float.Parse(lineToPrint.Substring(0, locOfOpenCurl));

        //Debug.Log(lineToPrint.Substring(locOfCloseBracket + 1));
        int nextLineVar = int.Parse(lineToPrint.Substring(locOfCloseBracket + 1));

        StartCoroutine(Say(lineActual, speaker, delay, nextLineVar, lineSpeed));


    }

    IEnumerator Say(string line, int speaker, float delay, int nextLineVar, float lineSpeed)
    {

        //textbox.SetActive(true);
        //spritebox.SetActive(true);
        //print("got here 1");
        Text textbox = null;
        textbox = textBoxes[speaker].GetComponentInChildren<Text>();
        if (line.Length > 0)
        {
            textBoxes[speaker].SetActive(true);
        }
        float x = 0;
        //print("got here w");
        while (true)
        {
            if (x >= line.Length)
            {
                textbox.text = line;
                break;
            }
            else
            {
                int y = (int)Mathf.Floor(x);
                textbox.text = line.Substring(0, y);
            }
            x += lineSpeed * speedMult;
            yield return null;
        }
        //audio.Stop();
        float time = Time.time;
        while (Time.time - time < delay / speedMult)
        {
            yield return null;
        }
        //audio.Stop();
        textBoxes[speaker].SetActive(false);
        //print("got here3");
        if (nextLineVar != -1)
        {
            PlayDialogue(nextLineVar);
        }
        else
        {
            //print("got here");
            //imageController.SendMessage("DialogueFinished");
        }

    }

    void AquireTextBoxes()
    {
        Image[] holder = GameObject.FindObjectsOfType<Image>();
        textBoxes = new GameObject[holder.Length];
        int count = 0;
        foreach(Image x in holder)
        {
            print(x.gameObject.name.Substring(0, x.gameObject.name.Length - 1));
            print(x.gameObject.name.Substring(x.gameObject.name.Length - 1));
            if (x.gameObject.name.Substring(0, x.gameObject.name.Length - 1).Equals("TextBox"))
            {
                int num = int.Parse(x.gameObject.name.Substring(x.gameObject.name.Length - 1));
                textBoxes[num] = x.gameObject;
                count++;
            }
        }
        numTextBoxes = count;
    }
}
