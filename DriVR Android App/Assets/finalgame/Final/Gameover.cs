using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Gameover : MonoBehaviour {
	public Animator Car;

	public GameObject EndUI;
	public GameObject UturnUI;
	public GameObject FadUI;	
	public GameObject FadINUI;
	public GameObject PedcroUI;
	public GameObject nopaUI;
	public GameObject runUI;
	public GameObject uturnagainUI;
	public Animator ped;
	public Animator walk;
	public void retry()
	{
		
			Car.SetInteger ("retry", 1);


		Car.SetInteger("uturn",0);
		EndUI.SetActive (false);
		UturnUI.SetActive (false);
		Car.SetTrigger ("starttrig");
		FadUI.SetActive (false);
		PedcroUI.SetActive (false);
		nopaUI.SetActive (false);
		runUI.SetActive (true);
		FadINUI.SetActive (false);
		ped.SetInteger ("move", 0);
		walk.SetInteger ("move", 0);
		uturnagainUI.SetActive (false);


	}

	public void exit()
	{
        SceneManager.LoadScene("main menu");
	}
}
