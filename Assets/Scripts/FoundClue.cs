using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundClue : MonoBehaviour
{
    [SerializeField] GameObject UIElement;
    string PLAYER_TAG = "Player";
    public ClueMenuItems clueDescription;
    public Sprite foundSprite;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == PLAYER_TAG)
        {
            UIElement.SetActive(true);
            FindObjectOfType<NotificationManager>().ShowClueNotification(clueDescription);
            other.GetComponent<CharacterController>().DisableMovement();
            //TODO Pickup sound effect
            //Destroy if clue is collectible, else just switch the sprite:
            if (this.gameObject.tag == "collectible")
            {
                Destroy(this.gameObject);
            }
            else
            {
                this.GetComponent<SpriteRenderer>().sprite = foundSprite;
                this.GetComponent<BoxCollider>().enabled = false;
            }
        }
    }
}
