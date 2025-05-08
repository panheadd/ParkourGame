using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isStarted = false;
    public bool isFailed = false;
    public CountDownTimer countDownTimer;
    public FailMenu failMenu;

    // Start is called before the first frame update
    void Start()
    {
        isStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
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
