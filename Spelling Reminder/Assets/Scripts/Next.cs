using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Next : MonoBehaviour {

	public Show showScript;
	public GameObject dipObj;
	public float dipSpeed;
	public bool toldToChange;
	public bool gotRight;
	public bool gotWrong;
	public bool changedColor;
	public bool readyDip;
	public bool comeOut;
	public bool toldToStop;
	public bool assignedTemp;
	public bool doColor = true;

	public void checkNow()
	{
		dipObj.SetActive(true);
		if(showScript.checkResult)
		{
			gotRight = true;
		} else {
			gotWrong = true;
		}
	}

	void Update()
	{
		if(gotRight)
		{
			if(doColor)
			{
				Color temp = dipObj.GetComponent<Image>().color;
				temp.g = 255;
				temp.a = 20;
				dipObj.GetComponent<Image>().color = temp;
				doColor = false;
				Invoke("doneColor", 2.0f);
			}
			if(readyDip)
			{
				Color temp = dipObj.GetComponent<Image>().color;
				temp.a = Mathf.Lerp(temp.a, 255, dipSpeed*Time.deltaTime);
				dipObj.GetComponent<Image>().color = temp;
			}
		} 
		if(gotWrong)
		{
			if(doColor)
			{
				Color temp = dipObj.GetComponent<Image>().color;
				temp.r = 255;
				temp.a = 20;
				dipObj.GetComponent<Image>().color = temp;
				doColor = false;
				Invoke("doneColor", 2.0f);
			}
			if(readyDip)
			{
				Color temp = dipObj.GetComponent<Image>().color;
				temp.a = Mathf.Lerp(temp.a, 255, dipSpeed*Time.deltaTime);
				dipObj.GetComponent<Image>().color = temp;
			}
		}
		if(comeOut)
		{
			Debug.Log("GotCalled");
			Color temp = dipObj.GetComponent<Image>().color;
			temp.a = Mathf.Lerp(temp.a, 0, dipSpeed*Time.deltaTime*500);
			dipObj.GetComponent<Image>().color = temp;
		}
	}

	void LateUpdate()
	{
		if(gotRight)
		{
			if(!toldToChange)
			{
				Invoke("resetNow", 8.0f);
				Invoke("nowReady", 2.0f);
				toldToChange = true;
			}
		} 
		if(gotWrong)
		{
			if(!toldToChange)
			{
				Invoke("resetNow", 8.0f);
				Invoke("nowReady", 2.0f);
				toldToChange = true;
			}
		}
		if(comeOut)
		{
			if(!toldToStop)
			{
				Invoke("stopNow", 8.0f);
				toldToStop = true;
			}
		}
	}

	void stopNow()
	{
		comeOut = false;
		toldToStop = false;
		assignedTemp = false;
		dipObj.SetActive(false);
	}

	void doneColor()
	{
		Color temp = dipObj.GetComponent<Image>().color;
		temp.r = 0;
		temp.g = 0;
		temp.b = 0;
		temp.a = 0;
		dipObj.GetComponent<Image>().color = temp;
	}

	void nowReady()
	{
		readyDip = true;
	}

	void resetNow()
	{
		gotRight = false;
		gotWrong = false;
		toldToChange = false;
		readyDip = false;
		changedColor = false;
		comeOut = true;
		doColor = true;
		showScript.englishPlace.text = null;
		showScript.currentWord += 1;
	}
}
