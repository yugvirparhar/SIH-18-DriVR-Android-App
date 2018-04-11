using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class backbyphone : MonoBehaviour
{
    public GameObject infopanel;
    public GameObject settingspanel;
    public GameObject mainmenupanel;
    public GameObject helppanle;
    public GameObject about_us_panel;
    private void Update ()
    {
       
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                if (SceneManager.GetActiveScene().name == "main menu")
                {
                    if (infopanel.activeSelf || settingspanel.activeSelf)
                    {
                        
                        infopanel.SetActive(false);
                        settingspanel.SetActive(false);
                        mainmenupanel.SetActive(true);
                    }
                    else if (helppanle.activeSelf || about_us_panel.activeSelf)
                    {
                      
                        helppanle.SetActive(false);
                        about_us_panel.SetActive(false);
                        settingspanel.SetActive(true);
                    }
                    else if (mainmenupanel.activeSelf)
                    {
                        SceneManager.LoadScene("start screen");
                        SceneManager.SetActiveScene(SceneManager.GetSceneByName("start screen"));
                    }
                }
                else if(SceneManager.GetActiveScene().name == "start screen"||SceneManager.GetActiveScene().name == "login")
                {
                    Application.Quit();
                }
                else if(SceneManager.GetActiveScene().name != "main menu")
                {
                    
                    {
                        SceneManager.LoadScene("main menu");
                    }

                }
                
               
            }
        }
    }
}
