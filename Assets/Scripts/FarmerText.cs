using UnityEngine;
using System.Collections;
using System;

public class FarmerText : MonoBehaviour {
   
    public string textShownOnScreen;
    public string fullText = "";
    public int wordsPerSecond = 50; // speed of typewriter
    private float timeElapsed = 0;
    public int characterCount;
    public int caseSwitch;
    
	// Use this for initialization
	void Start () {
 
	}
	
	// Update is called once per frame
	void Update () {
        timeElapsed += Time.deltaTime * wordsPerSecond;
        characterCount = Convert.ToInt32(timeElapsed);
        if (characterCount <= fullText.Length)
            textShownOnScreen = fullText.Substring(0, characterCount);
      
        GameData d = GameData.Instance;
        caseSwitch = d.allAnswers[0];
	}

    void OnGUI()
    {
        GameData d = GameData.Instance;
        switch(caseSwitch)
        {
            case 1:
                fullText = "What would a peasant want from the King?!";
                GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 500, 100), textShownOnScreen);

            if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 + 100, 500, 20), "Bandits stole me pigs Sire!"))
            {
                d.allAnswers[1] = 1; //stolen pigs
                GetComponent<FarmerText>().enabled = true;
                enabled = false;
            }
            if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 + 200, 500, 20), "A Dragon burned down my house!"))
            {
                d.allAnswers[1] = 2; //Burned House
                GetComponent<FarmerText>().enabled = true;
                enabled = false;
            }
            if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 + 300, 500, 20), "Just wanted to say hello… <3"))
            {
                d.allAnswers[1] = 3; //Gay
                GetComponent<FarmerText>().enabled = true;
                enabled = false;
            }
                break;
            case 2:
                fullText = "Sir, got anything to report?";
                GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 500, 100), textShownOnScreen);
            if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 + 100, 500, 20), "There are rumours that some villages in the surrounding area have sworn allegiance to our rival kingdom."))
            {
                d.allAnswers[1] = 1; //stolen pigs
                GetComponent<FarmerText>().enabled = true;
                enabled = false;
            }
                if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 + 200, 500, 20), "A dragon just sniffed me but!"))
            {
                d.allAnswers[1] = 2; //Burned House
                GetComponent<FarmerText>().enabled = true;
                enabled = false;
            }
                if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 + 300, 500, 20), "I got balls of steel!"))
            {
                d.allAnswers[1] = 3; //Gay
                GetComponent<FarmerText>().enabled = true;
                enabled = false;
            }
                break;
            case 3:
                fullText = "You’re a long way from home sorcerer, tell me, what brings you to this kingdom?";
                GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 500, 100), textShownOnScreen);
            if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 + 100, 500, 20), "A portal has opened on this land, vile creatures have been swarming through the kingdom."))
            {
                d.allAnswers[1] = 1; //stolen pigs
                GetComponent<FarmerText>().enabled = true;
                enabled = false;
            }
            if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 + 200, 500, 20), "The Nexus is opened once more, all Kings are called down for the ceremony."))
            {
                d.allAnswers[1] = 2; //Burned House
                GetComponent<FarmerText>().enabled = true;
                enabled = false;
            }
                if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 + 300, 500, 20), "YOU SHALL NOT PASS!!!"))
            {
                d.allAnswers[1] = 3; //Gay
                GetComponent<FarmerText>().enabled = true;
                enabled = false;
            }
                break;
        }
    }
        
}
