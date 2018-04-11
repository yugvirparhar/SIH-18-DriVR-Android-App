using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeup : MonoBehaviour {
	public Animator Car;
	public GameObject EndUI;
	// Use this for initialization
	public void End()
	{
		
		Car.SetInteger ("uturn", 1);
				EndUI.SetActive (true);
		StartInit.lesson = 0;
	
	}
}
