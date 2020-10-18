using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationManager : MonoBehaviour
{
    public Text dialogueText;

    public Animator animator;

    private Queue<string> sentences;

    [FMODUnity.EventRef]
    public string nextDialogueSound = "";
    [FMODUnity.EventRef]
    public string endDialogueSound = "";

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Notification dialogue)
    {
        animator.SetBool("isOpen", true);
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void ShowClueNotification(ClueMenuItems clueDescription)
    {
        animator.SetBool("isOpen", true);
        dialogueText.text = clueDescription.thisClueSentences;

        if(clueDescription.gameObject.name == "ChemSheet")
        {
            dialogueText.text = "A chemistry sheet? Let me take a closer look"; 
        }
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        FMODUnity.RuntimeManager.PlayOneShot(nextDialogueSound);
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    public void EndDialogue()
    {
        FMODUnity.RuntimeManager.PlayOneShot(endDialogueSound);
        animator.SetBool("isOpen", false);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<CharacterController>().DisableMovement();
        Debug.Log("notificaiton out");
    }

    public void SkipDialogue()
    {
        sentences.Clear();
        EndDialogue();
    }
}
