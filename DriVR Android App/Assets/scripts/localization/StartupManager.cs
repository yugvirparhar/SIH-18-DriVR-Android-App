using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartupManager : MonoBehaviour {


    private IEnumerator Start()
    {
        while (!LocatizationManager.instance.GetisReady())
        {
            yield return null;
        }

        
        SceneManager.LoadScene("rules");
    }
}
