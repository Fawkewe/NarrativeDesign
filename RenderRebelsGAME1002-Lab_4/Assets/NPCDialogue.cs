using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
public class NPCDialogue : MonoBehaviour
{
    public DialogueRunner Runner;
    public GameObject SpeechPrompt;
    public string startNode;
    public bool canstartconservation;
    // Start is called before the first frame update
    void Start()
    {
        SpeechPrompt.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (!Runner.IsDialogueRunning && canstartconservation)
            {
                canstartconservation = true;
                Runner.StartDialogue(startNode);
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       //AreaTrigger player = collision.GetComponent<AreaTrigger>();
        if (SpeechPrompt != null)
        {
            SpeechPrompt.SetActive(true);
            if (! Runner.IsDialogueRunning)
            {
                canstartconservation = true;
                Runner.StartDialogue(startNode);
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
       //AreaTrigger player = collision.GetComponent<AreaTrigger>();
        if (SpeechPrompt != null)
        {
            canstartconservation = false;
            SpeechPrompt.SetActive(false);

        }
    }
    // Update is called once per frame
}
