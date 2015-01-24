using UnityEngine;
using System.Collections;

public class Question4 : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameData d = GameData.Instance;
        if (d.allAnswers[3] != 0)
        {
            GetComponent<Question5>().enabled = true;
            enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

   

}
