using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LocatizationManager : MonoBehaviour {

    private Dictionary<string, string> localizedText;
    private bool isReady = false;
    private string missingTextString = "Localized text not found";

    public static LocatizationManager instance;

  


	void Awake ()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
	}

    public void LOadLocalizedText(string filename)
    {
        localizedText = new Dictionary<string, string>();
        string filePath = Path.Combine(Application.streamingAssetsPath, filename);

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            LocalizationData loadedData = JsonUtility.FromJson<LocalizationData>(dataAsJson);

            for (int i = 0; i < loadedData.items.Length; i++)
            {
                localizedText.Add(loadedData.items[i].key, loadedData.items[i].value);//placing the values and keys in the dictionary
            }
            Debug.Log("Dictionary contains : " + localizedText.Count + "entries"); 

        }
        else
        {
            Debug.LogError("cannot find file");
        }
        isReady = true;

    }

    public string GetLoclizedValue(string key)
    {
        string result = missingTextString;
        if (localizedText.ContainsKey(key))
        {
            result = localizedText[key];
        }
        return result;
    }

    public bool GetisReady()
    {
        return isReady;
    }

}
