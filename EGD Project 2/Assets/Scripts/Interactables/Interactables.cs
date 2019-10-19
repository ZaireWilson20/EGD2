using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour
{
    DialogueManager diaMan;

    [SerializeField]
    private int lineID; 

    // Start is called before the first frame update
    void Start()
    {
        diaMan = GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitDialogue()
    {
        diaMan.PlayDialogue(lineID);
    }

}
