using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AnsweButton : MonoBehaviour {

    public Text answerText;
    private AnswerData answerdata;
    private GameController gamecontroller;

	// Use this for initialization
	void Start () {
        gamecontroller = FindObjectOfType<GameController>();
	}

    public void Setup(AnswerData data)
    {
        answerdata = data;
        answerText.text = answerdata.answerText;
    }

    // Update is called once per frame
    public void HandleClicked()
    {
        gamecontroller.AnswerButtonClicked(answerdata.LD, answerdata.RR);
        gamecontroller.displayResult(answerdata.LD, answerdata.RR);
    }
}
