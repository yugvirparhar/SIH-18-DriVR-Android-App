using System.Collections;
using UnityEngine;

public class UI_Manager_Script : MonoBehaviour
{
	public void DisableBoolAnimator (Animator anim)
	{
		anim.SetBool("IsDisplayed", false);
	}

	public void EnableBoolAnimator (Animator anim)
	{
		anim.SetBool("IsDisplayed", true);
	}

	public void NavigateTo (int scene)
	{
		Application.LoadLevel (scene);
	}

	public void ExitGame ()
	{
		Application.Quit ();
	}
}
