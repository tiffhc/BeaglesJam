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
    }

    public void SkipDialogue()
    {
        sentences.Clear();
        EndDialogue();
    }
}
