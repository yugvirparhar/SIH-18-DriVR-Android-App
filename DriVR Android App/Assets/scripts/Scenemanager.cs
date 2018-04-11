using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemanager : MonoBehaviour {
   
    public void gotobacktomainmenu()
    {
        SceneManager.LoadScene("main menu");
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("main menu"));
  
    }
    public void gotopsychtest()
    {
        SceneManager.LoadScene("Persistent");
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Persistent"));

    }
    public void gotorules()
    {
        SceneManager.LoadScene("rules");
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("rules"));

    }
    public void gottothesigns()

    {
        SceneManager.LoadScene("TrafficSigns");
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("TrafficSigns"));
    }
    public void gotothegame()
    {
        SceneManager.LoadScene("Sih final");
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Sih final"));
    }
    public void gotoawareness()
    {
        SceneManager.LoadScene("awareness");
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("awareness"));
    }
}
