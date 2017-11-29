using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour {

	public void goTo(string sceneName)
	{
		Application.LoadLevel(sceneName);
	}

	public void quitNow()
	{
		Application.Quit();
	}
}
