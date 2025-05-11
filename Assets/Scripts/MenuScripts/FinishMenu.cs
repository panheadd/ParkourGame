using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishMenu : MonoBehaviour
{
    public GameObject finishMenuUI;
    public int level;
    public bool isFinished = false;

    void Update()
    {
        if(isFinished){
            PauseGame();
        }
    }

    public void PauseGame()
    {
        finishMenuUI.SetActive(true);
        Time.timeScale = 0;        
        Cursor.visible = true;     
        Cursor.lockState = CursorLockMode.None;
        isFinished = true; 
    }

    public void Continue()
    {
        Time.timeScale = 1;

        switch (level)
        {
            case 1:
                Time.timeScale = 1;
                SceneManager.LoadScene("Level 2");
                break;

            case 2:
                Time.timeScale = 1;
                SceneManager.LoadScene("Level 3");
                break;

            case 3:
                Time.timeScale = 1;
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


