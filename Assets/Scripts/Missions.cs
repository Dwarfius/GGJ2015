using UnityEngine;
using System.Collections;

public class Missions : MonoBehaviour {
	// Use this for initialization
	public void EndLevel () {
        GameData d = GameData.Instance;
        switch(d.allAnswers[2])
        {
            case 1:
                Application.LoadLevel("VillageFood");
                break;
            case 2:
                Application.LoadLevel("VillageFood");
                break;
            case 3:
                GetComponent<DonkeyAnomaly>().enabled = true;
                enabled = false;
                break;
        }
	}
}
