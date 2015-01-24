using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class IntroText : MonoBehaviour {


    public string textShownOnScreen;
    public string fullText = "Once upon a time there lived a lonely King. All the King ever wanted was a son, not just someone to carry on his family name, but also someone he could teach how to hunt, how to ride a horse, how to fight and how to kill. The King had taken many wives, but none of them had ever granted him children and none of them had lived long enough for history to remember their names. And so it was for most of the people who lived close to the King, until one day a visitor was announced to the King’s Lounge…";
    public int wordsPerSecond = 50; // speed of typewriter
    private float timeElapsed = 0;
    public int characterCount;

    public Text text;



	// Use this for initialization
	void Start () {
        GameData d = GameData.Instance;
        if (d.allAnswers[0] != 0)
        {
            GetComponent<FarmerText>().enabled = true;
            enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
        timeElapsed += Time.deltaTime * wordsPerSecond;
        characterCount = Convert.ToInt32(timeElapsed);
        if (characterCount <= fullText.Length)
            textShownOnScreen = fullText.Substring(0, characterCount);
        text.text = textShownOnScreen;
	}

    public void Answered(int n)
    {
        GameData.Instance.allAnswers[0] = n;
        GetComponent<FarmerText>().enabled = true;
        enabled = false;
    }
}
