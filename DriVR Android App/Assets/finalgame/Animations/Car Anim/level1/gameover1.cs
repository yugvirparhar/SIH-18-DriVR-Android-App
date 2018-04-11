using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class gameover1 : MonoBehaviour {
	public Animator CarAnim;
	public GameObject UI;
	public GameObject TUI;

	public void Exit()
	{
	
		Application.Quit();
	}

	public void Retry()
	{

		CarAnim.SetInteger("retry",1);
		CarAnim.SetInteger("uturn",0);
		CarAnim.SetInteger("gogo",0);
		UI.SetActive(false);
		TUI.SetActive(false);
		CarAnim.SetTrigger("starttrig");
	}

}
