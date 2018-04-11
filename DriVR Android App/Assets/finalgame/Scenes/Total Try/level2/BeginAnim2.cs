using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginAnim2 : MonoBehaviour {
	public Animator CarAnim;
	public GameObject BtnUI;
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void StartAnim()
	{
		CarAnim.SetTrigger("Start2");
	}

	public void EnableLeft()
	{
		CarAnim.SetInteger("Left",1);
		BtnUI.SetActive(false);

	}

	public void EnableRight()
	{
		CarAnim.SetInteger("Right",1);
		BtnUI.SetActive(false);
		CarAnim.SetInteger("Retry2",0);
	}
	// Use this for initialization
}
