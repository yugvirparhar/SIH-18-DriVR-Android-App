using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lesson : MonoBehaviour {
	public Text mytext;
	int x;
	void Update()
	{
		x = StartInit.lesson;
		if (x == 0) {
			mytext.text = "TIME UP!";
		} else if (x == 1) {
			mytext.text = "You should have seen the 'NO U-TURN' sign!";
		} else if (x == 2) {
			mytext.text = "There wasn't a 'NO U-TURN' sign! You should have taken the U-TURN";
		} else if (x == 3) {
			mytext.text = "You should have slowed and stopped down when pedestrians walk on the crossing!";
		} else if (x == 4) {
			mytext.text = "Don't park near the NO PARKING sign!";
		} else {
			mytext.text = "";
		}
	}



}
