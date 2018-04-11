using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginAnim : MonoBehaviour {
	public Animator CarAnim;
	public GameObject ButUI;
	public GameObject UturnUI;




	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void StartAnim()
	{
		CarAnim.SetTrigger("starttrig");
	}

	public void EnableNoUturn()
	{
		
		UturnUI.SetActive (false);
		CarAnim.SetInteger("gogo",1);

	}

	public void EnableUturn()
	{
		
		ButUI.SetActive (true);



	}
	// Use this for initialization
}
