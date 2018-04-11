using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitAnims : MonoBehaviour {

    public Animator CarAnim;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EnableInitAnim()
    {
        CarAnim.SetTrigger("InitTrigger");
    }

	public void EnableNoUturn()
	{
		CarAnim.SetInteger("NoUTurn",1);
		CarAnim.SetInteger("Uturn",1);
	}

	public void EnableUturn()
	{
		
	}


}
