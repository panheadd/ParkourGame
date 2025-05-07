using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{ 
    private int level = 1;
    private Color32 greenColor = new Color32(0x42, 0xFF, 0x00, 0xFF);
    private Color32 whiteColor = new Color32(0xFF, 0xFF, 0xFF, 0xFF);
    public GameObject level1Button;
    public GameObject level2Button;
    public GameObject level3Button;

    public void LoadLevel(){

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
    public void QuitGame(){
        Application.Quit();
    }

    public void SetLevel1(){
        level1Button.GetComponent<Image>().color = greenColor;
        level2Button.GetComponent<Image>().color = whiteColor;
        level3Button.GetComponent<Image>().color = whiteColor;
        level = 1;
    }
    public void SetLevel2(){
        level1Button.GetComponent<Image>().color = whiteColor;
        level2Button.GetComponent<Image>().color = greenColor;
        level3Button.GetComponent<Image>().color = whiteColor;
        level = 2;
    }
    public void SetLevel3(){
        level1Button.GetComponent<Image>().color = whiteColor;
        level2Button.GetComponent<Image>().color = whiteColor;
        level3Button.GetComponent<Image>().color = greenColor;
        level = 3;
    }
}
