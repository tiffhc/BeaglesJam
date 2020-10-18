using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundClue : MonoBehaviour
{
    [SerializeField] GameObject UIElement;
    string PLAYER_TAG = "Player";
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
            //TODO Pickup sound effect
            Destroy(this.gameObject);
        }
    }
}
