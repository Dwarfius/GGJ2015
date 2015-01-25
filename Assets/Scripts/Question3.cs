using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Question3 : MonoBehaviour 
{
    public string textShownOnScreen;
    public string fullText = "";
    public int wordsPerSecond = 50; // speed of typewriter
    private float timeElapsed = 0;
    public int characterCount;

    public Text text;
    public Text b1Text, b2Text, b3Text;

    // Use this for initialization
	void Start () 
    {
        GameData d = GameData.Instance;
        if (d.allAnswers[2] != 0)
            Application.LoadLevel("Level 1");

        int a2 = d.allAnswers[1];
        text.text = "You have a choice of helping the country - what do you choose to do?";
        b1Text.text = "Transport food to the vilage";
        b2Text.text = "Visit the village that requires assistance";
        b3Text.text = "Investigate donkey reports";
    }

    #region Ric's past gui work
    /*void OnGUI()
    {
            GUI.Label(new Rect(100, 30, Screen.width - 200, Screen.height / 2), textShownOnScreen);
            if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 + 100, 500, 20), ))
            {
                d.allAnswers[2] = 1; //monastery
                GetComponent<Question4>().enabled = true;
                enabled = false;
            }
            if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 + 200, 500, 20), ))
            {
                d.allAnswers[2] = 2; //assist the village
                //GetComponent<Question4>().enabled = true;
                enabled = false;
                Application.LoadLevel("Level 1");
            }
            if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 + 300, 500, 20), "A note states that something strange happened in a valley, something came down from the sky with flames and it roared when it landed."))
            {
                d.allAnswers[2] = 3; //Wizard
                GetComponent<Question4>().enabled = true;
                enabled = false;
            }
            if (d.allAnswers[1] == 1 && d.stolenPigs == true)
            {
                if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 + 400, 500, 20), "You search for the bandits who stole your pigs yourself."))
                {
                    d.allAnswers[2] = 4; //assist the village
                    GetComponent<Question4>().enabled = true;
                    enabled = false;
                }
            }
            if (d.allAnswers[1] == 2 && d.dragonHouse == true)
            {
                if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 + 400, 500, 20), "You go back to the village and search for anyone who could help you face the dragon."))
                {
                    d.allAnswers[2] = 4; //assist the village
                    GetComponent<Question4>().enabled = true;
                    enabled = false;
                }
            }
            if (d.allAnswers[1] == 1 && d.villagesBetrayed == true)
            {
                if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 + 400, 500, 20), "You go and interrogate the villagers"))
                {
                    d.allAnswers[2] = 4; //assist the village
                    GetComponent<Question4>().enabled = true;
                    enabled = false;
                }
            }
            if(d.allAnswers[1]==2 && d.dragonButt == true)
            {
                if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 + 400, 500, 20), "You go kick the Dragon's butt."))
                {
                    d.allAnswers[2] = 4; //assist the village
                    GetComponent<Question4>().enabled = true;
                    enabled = false;
                }
            }
            if (d.allAnswers[1] == 1 && d.portalOpened == true)
            {
                if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 + 400, 500, 20), "You go hunt the creatures."))
                {
                    d.allAnswers[2] = 4; //assist the village
                    GetComponent<Question4>().enabled = true;
                    enabled = false;
                }
            }
            if (d.allAnswers[1] == 2 && d.nexusSomething == true)
            {
                if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 + 400, 500, 20), "You go back to the Nexus."))
                {
                    d.allAnswers[2] = 4; //assist the village
                    GetComponent<Question4>().enabled = true;
                    enabled = false;
                }
            }
    }*/
    #endregion

    void Answered(int i)
    {
        GameData.Instance.allAnswers[2] = i;
        Application.LoadLevel("Level 1");
    }
}
