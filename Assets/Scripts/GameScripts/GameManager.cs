using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isStarted = false;
    public bool isFailed = false;
    public bool isFinished = false;
    public CountDownTimer countDownTimer;
    public FailMenu failMenu;
    public FinishMenu finishMenu;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        isStarted = false;
        isFailed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFinished)
        {
            finishMenu.isFinished =true;
        }

        if (isFailed)
        {
            failMenu.isFailed = true;
        }
        
        if(isStarted){
            start();
        }
    }

    public void start(){
        startTimer();
    }

    public void startTimer(){
        countDownTimer.isRunning = true;

    }

}
