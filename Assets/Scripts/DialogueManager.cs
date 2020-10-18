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
        animator.SetBool("isOpen", false);
    }

    public void SkipDialogue()
    {
        sentences.Clear();
        EndDialogue();
    }
}
