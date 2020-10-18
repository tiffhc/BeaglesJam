using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    string PLAYER_TAG = "Player";
    public Dialogue dialogue;

    private void OnTriggerEnter(Collider other) { 
        if (other.gameObject.tag == PLAYER_TAG)
        {

            other.gameObject.GetComponent<CharacterController>().DisableMovement();
            TriggerDialogue();
        }
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
