using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI; 

public class FarmerText : MonoBehaviour {
   
    public string textShownOnScreen;
    public string fullText = "";
    public int wordsPerSecond = 50; // speed of typewriter
    private float timeElapsed = 0;
    public int characterCount;
    public int caseSwitch;

    public Text text;
    public Text b1Text, b2Text, b3Text;

	// Use this for initialization
	void Start () 
    {
        if (GameData.Instance.allAnswers[1] != 0)
        {
            GetComponent<Question3>().enabled = true;
            enabled = false;
        }
        int a1 = GameData.Instance.allAnswers[0];
        if (a1 == 1)
        {
            text.text = "What would a peasant want from the King?!";
            b1Text.text = "Bandits stole me pigs Sire!";
            b2Text.text = "A Dragon burned down my house!";
            b3Text.text = "Just wanted to say hello… <3";
        }
        else if (a1 == 2)
        {
            text.text = "Sir, got anything to report?";
            b1Text.text = "There are rumours that some villages in the surrounding area have sworn allegiance to our rival kingdom.";
            b2Text.text = "A dragon just sniffed me but!";
            b3Text.text = "I got balls of steel!";
        }
        else if (a1 == 3)
        {
            text.text = "You’re a long way from home sorcerer, tell me, what brings you to this kingdom?";
            b1Text.text = "A portal has opened on this land, vile creatures have been swarming through the kingdom.";
            b2Text.text = "The Nexus is opened once more, all Kings are called down for the ceremony.";
            b3Text.text = "YOU SHALL NOT PASS!!!";
        }
	}

    public void Answered(int n)
    {
        GameData.Instance.allAnswers[0] = n;
        GetComponent<FarmerText>().enabled = true;
        enabled = false;

        //rerouting callbacks
    }
}
        
