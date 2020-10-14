using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] Text textUI;
    [SerializeField] Canvas gameCanvas;
    [SerializeField] GameObject[] codeSpawnPoints;
    [SerializeField] GameObject codeItem;


    //We also need a list of clues that have been found, as we actually need to find the clues. 

    public bool hasFoundPhoneNumber = false;
    public int phoneNumber;
    // Start is called before the first frame update
    void Start()
    {
        phoneNumber = Random.Range(1000, 9999);
        int chooseASpawnPoint = Random.Range(0, codeSpawnPoints.Length);
        GameObject code = GameObject.Instantiate(codeItem, codeSpawnPoints[chooseASpawnPoint].transform.position, codeSpawnPoints[chooseASpawnPoint].transform.rotation);
        code.GetComponent<CypherScript>().SetUIObject(textUI, gameCanvas, phoneNumber);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FoundPhoneNumber()
    {
        hasFoundPhoneNumber = true;
    }
}
