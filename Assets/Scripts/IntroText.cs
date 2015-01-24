using UnityEngine;
using System.Collections;
using System;

public class IntroText : MonoBehaviour {


    public string textShownOnScreen;
    public string fullText = "Once upon a time there lived a lonely King. All the King ever wanted was a son, not just someone to carry on his family name, but also someone he could teach how to hunt, how to ride a horse, how to fight and how to kill. The King had taken many wives, but none of them had ever granted him children and none of them had lived long enough for history to remember their names. And so it was for most of the people who lived close to the King, until one day a visitor was announced to the King’s Lounge…";
    public int wordsPerSecond = 50; // speed of typewriter
    private float timeElapsed = 0;
    public int characterCount;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        timeElapsed += Time.deltaTime * wordsPerSecond;
        characterCount = Convert.ToInt32(timeElapsed);
        if (characterCount <= fullText.Length)
            textShownOnScreen = fullText.Substring(0, characterCount);
	}


    void OnGUI()
    {
        GUI.Label(new Rect(100, 30, Screen.width - 200, Screen.height / 2), textShownOnScreen);
        if (characterCount >= fullText.Length) 
        {
            GameData d = GameData.Instance;
            GUI.Label(new Rect(Screen.width/2, Screen.height / 2, 500, 100), "Who are you?");
            if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 + 100, 500, 20), "Farmer"))
            {
                d.allAnswers[0] = 1; //Farmer
                GetComponent<FarmerText>().enabled = true;
                enabled = false;
            }
            if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 + 200, 500, 20), "Knight"))
            {
                d.allAnswers[0] = 2; //Knight
                GetComponent<FarmerText>().enabled = true;
                enabled = false;
            }
            if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 + 300, 500, 20), "Wizard"))
            {
                d.allAnswers[0] = 3; //Wizard
                GetComponent<FarmerText>().enabled = true;
                enabled = false;
            }
        }

    }
}
