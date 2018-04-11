using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quiz : MonoBehaviour {

public static int score=0;
public Text Scoretext;

	public void ScoreINC()
	{
	score++;
	Scoretext.text = "SCORE: " +score.ToString();
	}
}
