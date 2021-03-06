﻿using UnityEngine;
using System.Collections;

public class CharacterInstanciation : MonoBehaviour {

    public GameObject farmer;
    public GameObject knight;
    public GameObject wizard;

    private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
        GameData d = GameData.Instance;
        
        switch (d.allAnswers[0])
        {
            case 1:
                Instantiate(farmer, transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(knight, transform.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(wizard, transform.position, Quaternion.identity);
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
