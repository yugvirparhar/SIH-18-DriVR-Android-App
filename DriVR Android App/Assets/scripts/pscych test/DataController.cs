using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour {

    public RoundData[] allRoundData;


    void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("Menu Screen");
    }
    public RoundData GetCurrentRoundData()
    {
        return allRoundData[0];
    }

    void Update()
    {
        
    }
}
