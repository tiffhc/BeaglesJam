using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkTo : MonoBehaviour
{

    [SerializeField] GameObject[] thingstoSpawn;
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
            foreach(GameObject thingtoSpawn in thingstoSpawn)
            {
                thingtoSpawn.SetActive(true);
                
            }
            this.gameObject.SetActive(false);
        }
    }
}
