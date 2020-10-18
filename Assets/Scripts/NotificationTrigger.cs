using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationTrigger : MonoBehaviour
{
    string PLAYER_TAG = "Player";
    public Notification dialogue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == PLAYER_TAG)
        {

            other.gameObject.GetComponent<CharacterController>().DisableMovement();
            TriggerNotification();
        }
    }
    public void TriggerNotification()
    {
        FindObjectOfType<NotificationManager>().StartDialogue(dialogue);
    }
}
