using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimOptionsTry : MonoBehaviour {

	public GameObject BtnUI;
	public GameObject EndUI;



	public void GetUI()
	{
		BtnUI.SetActive(true);


	}
	public void promptgameover()
	{
		EndUI.SetActive(true);


	}

}

