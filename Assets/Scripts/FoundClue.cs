using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundClue : MonoBehaviour
{
    [SerializeField] GameObject UIElement;
    string PLAYER_TAG = "Player";
    public ClueMenuItems clueDescription;
    public Sprite foundSprite;

    [FMODUnity.EventRef]
    public string removeCabinetSound = "";

    [FMODUnity.EventRef]
    public string removeSound = "";
   
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

            if(UIElement == null)
            {
                if(this.gameObject.name == "Beagles_SecurityCabinet_1")
                {
                    FMODUnity.RuntimeManager.PlayOneShot(removeCabinetSound);
                    Destroy(this.gameObject); 
                }

                if(this.gameObject.name == "Beagles_MrPurrCage_0")
                {
                    FMODUnity.RuntimeManager.PlayOneShot(removeSound);
                    Destroy(this.gameObject);
                }
                return; 
            }

            UIElement.SetActive(true);

            FindObjectOfType<NotificationManager>().ShowClueNotification(clueDescription);
            other.GetComponent<CharacterController>().DisableMovement();
            FMODUnity.RuntimeManager.PlayOneShot(removeSound);
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
