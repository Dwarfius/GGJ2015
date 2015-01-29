using UnityEngine;
using System.Collections;

public class Missions : MonoBehaviour {
	// Use this for initialization
	public void EndLevel () {
        GameData d = GameData.Instance;
        Debug.Log(d.allAnswers[2]);
        switch(d.allAnswers[2])
        {
            case 1:
                GetComponent<VIllageFoodMission>().enabled = true;
                enabled = false;
                break;
            case 2:
                Application.LoadLevel("GameOver");
                break;
            case 3:
                GetComponent<DonkeyAnomaly>().enabled = true;
                enabled = false;
                break;
        }
	}
}
