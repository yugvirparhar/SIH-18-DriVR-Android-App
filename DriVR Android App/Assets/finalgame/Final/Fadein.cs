using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fadein : MonoBehaviour {
	public Animator CarAnim;
	public GameObject End;
	// Use this for initialization
	public void Wrong()
	{
		End.SetActive (true);
		CarAnim.SetInteger("uturn",1);
	}
}
