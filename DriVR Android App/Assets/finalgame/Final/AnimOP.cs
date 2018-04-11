using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimOP : MonoBehaviour {

	public GameObject BtnUI;
	public Animator Car;
	public Animator ped;
	public Animator walk;
	public GameObject FaUI;
	public GameObject PedcroUI;
	public GameObject SlowUI;
	public GameObject RunUI;
	public GameObject FINISHUI;
	public GameObject nopaUI;
	public GameObject noparkUI;
	public GameObject person;
	public GameObject RUNagainUI;

	public void GetUI()
	{
		BtnUI.SetActive(true);
		Car.SetInteger ("retry", 0);



	}

	public void Wait()
	{
		ped.SetInteger ("move", 1);
		walk.SetInteger ("move", 1);
	}



	public void Fade()
	{
		FaUI.SetActive (true);
		RunUI.SetActive (false);
		RUNagainUI.SetActive (false);

	}

	public void Slow()
	{
		PedcroUI.SetActive (true);
		FaUI.SetActive (false);
	}

	public void stop()
	{
		SlowUI.SetActive (true);


	}
	public void FadeAgain()
	{
	
		FaUI.SetActive (true);
		person.SetActive (false);
		PedcroUI.SetActive (false);

	}

	public void nopa()
	{
		nopaUI.SetActive (true);


	}

	public void nopark()
	{
		noparkUI.SetActive (true);


	}
	public void Win()
	{
		FINISHUI.SetActive (true);
	}

	public void UTURNAGAIN()
	{
		RUNagainUI.SetActive (true);
	}
}
