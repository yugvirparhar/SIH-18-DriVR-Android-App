using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimOptions2 : MonoBehaviour {

	public GameObject BtnUI;
	public GameObject EndUI;
	public GameObject Next;


	public void GetUI()
	{
		BtnUI.SetActive(true);


	}
	public void promptgameover()
	{
		EndUI.SetActive(true);


	}
	public void Win()
	{

		SceneManager.LoadScene ("Level3");
	}
	public void nextlevel()
	{
		Next.SetActive (true);
	}
}

