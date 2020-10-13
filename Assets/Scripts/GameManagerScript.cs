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
    // Start is called before the first frame update
    void Start()
    {
        int chooseASpawnPoint = Random.Range(0, codeSpawnPoints.Length);
        GameObject code = GameObject.Instantiate(codeItem, codeSpawnPoints[chooseASpawnPoint].transform.position, codeSpawnPoints[chooseASpawnPoint].transform.rotation);
        code.GetComponent<CypherScript>().SetUIObject(textUI, gameCanvas);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
