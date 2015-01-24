using UnityEngine;
using System.Collections;

public class CharacterInstanciation : MonoBehaviour {

    public Sprite farmer;
    public Sprite knight;
    public Sprite wizard;

    private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
        GameData d = GameData.Instance;
        spriteRenderer = GetComponent<SpriteRenderer>();
        switch (d.allAnswers[0])
        {
            case 1:
                spriteRenderer.sprite = farmer;
                break;
            case 2:
                spriteRenderer.sprite = knight;
                break;
            case 3:
                spriteRenderer.sprite = wizard;
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
