using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    [SerializeField] float timeLeftUntilGameOver;
    [SerializeField] Text timeText;
    [SerializeField] string failedGameScene = "FailedGame";
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeftUntilGameOver > 0.0f)
        {
            timeLeftUntilGameOver -= Time.deltaTime;
            float minutes = Mathf.FloorToInt(timeLeftUntilGameOver / 60);
            float seconds = Mathf.FloorToInt(timeLeftUntilGameOver % 60);
            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            Debug.Log("Game Over");
            timeLeftUntilGameOver = 0.0f;
            SceneManager.LoadScene(failedGameScene);
        }
    }
}
