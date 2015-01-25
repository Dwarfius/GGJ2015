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

    public Text mainText;
    public Text text;
    public Text b1Text, b2Text, b3Text;

    int currentQ = 0;
	
	// Update is called once per frame
	void Update () 
    {
        timeElapsed += Time.deltaTime * wordsPerSecond;
        characterCount = Convert.ToInt32(timeElapsed);
        if (characterCount <= fullText.Length)
            textShownOnScreen = fullText.Substring(0, characterCount);
        mainText.text = textShownOnScreen;
	}

    public void Answered(int n)
    {
        GameData.Instance.allAnswers[currentQ++] = n;
        if(GameData.Instance.allAnswers[1] == 3)
            Application.LoadLevel("GameOver");
        if (currentQ > 2)
            Application.LoadLevel("Level 1");
        else
            UpdateTexts();
    }

    void UpdateTexts()
    {
        int a = GameData.Instance.allAnswers[currentQ - 1];
        if (currentQ == 1)
        {
            if (a == 1)
            {
                text.text = "What would a peasant want from the King?!";
                b1Text.text = "Bandits stole me pigs Sire!";
                b2Text.text = "A Dragon burned down my house!";
                b3Text.text = "Just wanted to say hello… <3";
            }
            else if (a == 2)
            {
                text.text = "Sir, got anything to report?";
                b1Text.text = "There are rumours that some villages in the surrounding area have sworn allegiance to our rival kingdom.";
                b2Text.text = "A dragon just sniffed me but!";
                b3Text.text = "I got balls of steel!";
            }
            else if (a == 3)
            {
                text.text = "You’re a long way from home sorcerer, tell me, what brings you to this kingdom?";
                b1Text.text = "A portal has opened on this land, vile creatures have been swarming through the kingdom.";
                b2Text.text = "The Nexus is opened once more, all Kings are called down for the ceremony.";
                b3Text.text = "YOU SHALL NOT PASS!!!";
            }
        }
        else if(currentQ == 2)
        {
            text.text = "You have a choice of helping the country - what do you choose to do?";
            b1Text.text = "Transport food to the vilage";
            b2Text.text = "Visit the village that requires assistance";
            b3Text.text = "Investigate donkey reports";
        }
    }
}
