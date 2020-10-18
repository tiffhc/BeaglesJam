using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Image spriteImage;

    public Animator animator;
    public Animator textAnimator;

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
    
    public void StartDialogue(Dialogue dialogue)
    {
        //Debug.Log("Starting conversation with " + dialogue.name);
        animator.SetBool("isOpen", true);
        nameText.text = dialogue.name;
        spriteImage.sprite = dialogue.sprite;
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
        //textAnimator.SetBool("isOpen", false);
        //StartCoroutine(Wait(1.15f));
        textAnimator.Play("dialoguetext_open");
        dialogueText.text = sentence;
        //StopAllCoroutines();
        //StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }

    //IEnumerator TypeSentence(string sentence)
    //{
    //    dialogueText.text = "";
    //    foreach (char letter in sentence.ToCharArray())
    //    {
    //        dialogueText.text += letter;
    //        yield return null;
    //    }
    //}

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
