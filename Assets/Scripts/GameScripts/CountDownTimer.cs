using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDownTimer : MonoBehaviour
{
    public float timeRemaining = 180f;
    public bool isRunning;
    public TMP_Text timerInfo;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                updateTimerInfo(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                isRunning = false;
                updateTimerInfo(timeRemaining);
                gameManager.isFailed = true;
            }
        }        
    }


     void updateTimerInfo(float timeToDisplay)
    {
        timeToDisplay += 1;

        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);

        string strMinutes = minutes.ToString();
        string strSeconds;
        if(seconds < 10){
            strSeconds = "0"+ seconds.ToString();
        }
        else{
            strSeconds = seconds.ToString();
        }
        string text = strMinutes+":"+strSeconds;
        timerInfo.text = text;
        timerInfo.gameObject.SetActive(true);
    }
}
