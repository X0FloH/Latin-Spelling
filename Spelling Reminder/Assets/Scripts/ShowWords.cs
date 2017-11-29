using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowWords : MonoBehaviour {

	public List<string> LatinWords = new List<string>();
	public List<string> EnglishWords = new List<string>();
	public Text LatinWordList;
	public Text EnglishWordList;

	void Start()
	{
		for(int i = 0; i < LatinWords.Count; i++)
        {
            LatinWordList.text += LatinWords[i] + "\n";
        }
        for(int i = 0; i < EnglishWords.Count; i++)
        {
            EnglishWordList.text += EnglishWords[i] + "\n";
        }

	}
}
