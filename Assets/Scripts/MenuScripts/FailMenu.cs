using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailMenu : MonoBehaviour
{
    public GameObject failMenuUI;
    public int level;
    public bool isFailed = false;

    void Update()
    {
        if(isFailed){
            PauseGame();
        }
    }

    public void PauseGame()
    {
        failMenuUI.SetActive(true);
        Time.timeScale = 0;        
        Cursor.visible = true;     
        Cursor.lockState = CursorLockMode.None;
        isFailed = true; 
    }

    public void TryAgain()
    {
        Time.timeScale = 1;
        
        switch (level)
        {
            case 1:
                SceneManager.LoadScene("Level 1");
                break;

            case 2:
                SceneManager.LoadScene("Level 2");
                break;

            case 3:
                SceneManager.LoadScene("Level 3");
                break;

            default:
                SceneManager.LoadSceneAsync("Level 1");
                break;
        }
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu"); 
    }

    public void QuitGame(){
        Application.Quit();
    }
}


