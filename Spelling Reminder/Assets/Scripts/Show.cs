using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Show : MonoBehaviour {

	public Text latinPlace;
	public Text englishPlace;
	public Words wordScript;
	public int currentWord;

	public bool checkResult;

	void Start()
	{
		currentWord = 0;
		TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
	}

	void Update()
	{
		latinPlace.text = wordScript.LatinWord[currentWord];
	}

	public void checkNow()
	{
		if(englishPlace.text == wordScript.NormalWord[currentWord])
		{
			checkResult = true;
		} else {
			checkResult = false;
		}
	}
}
