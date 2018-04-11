using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartInit : MonoBehaviour {
	public Animator Car;
	public GameObject ButUI;
	public GameObject uturnUI;
	public GameObject person;
	public GameObject FadeUI;
	public GameObject PedcroUI;
	public GameObject NOPARKUI;
	public GameObject uturnagainUI;
	public static int lesson=5;

	public void StartTrig()
	{
		Car.SetTrigger ("starttrig");
		Car.SetInteger("retry",0);
	}
	public void Uturn()
	{
		ButUI.SetActive (true);
		uturnUI.SetActive (false);
		lesson = 1;
	}
	public void Uturn1()
	{
		ButUI.SetActive (true);
		uturnagainUI.SetActive (false);
		lesson = 2;
	}
	public void Uturn2()
	{
		ButUI.SetActive (true);
		PedcroUI.SetActive (false);
		lesson = 3;
	}
	public void Uturn3()
	{
		ButUI.SetActive (true);
		NOPARKUI.SetActive (false);
		lesson = 4;
	}

	public void NoUturn()
	{
		

		uturnUI.SetActive (false);

	}	
	public void NoUturnAgain()
	{


		uturnagainUI.SetActive (false);

	}


	public void skipturn()
	{
		ButUI.SetActive (true);
	}

	public void next()
	{
		
		FadeUI.SetActive (true);


	}
	public void stop(){
		person.SetActive (true);
		PedcroUI.SetActive (false);

	}

	public void NOPARK(){

		NOPARKUI.SetActive (false);

	}


}
