using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class gameover2 : MonoBehaviour {
	public Animator CarAnim;
	public GameObject UI;

	public void Exit()
	{

		Application.Quit();
	}

	public void Retry()
	{

		CarAnim.SetInteger("Retry2",1);
		CarAnim.SetInteger("Left",0);
		CarAnim.SetInteger("Right",0);
		UI.SetActive(false);
	}

}
