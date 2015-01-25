using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class GenericWriteoutScript : MonoBehaviour 
{
    public string text;
    public float speed;
    public UnityEvent OnDone;

    float chNum;
    Text textBox;
    bool eventFired;

	void Start () 
    {
        textBox = GetComponent<Text>();
	}
	
	void Update () 
    {
        chNum += Time.deltaTime * speed;
        int chInd = (int)chNum;
        if (chInd < text.Length)
            textBox.text = text.Substring(0, chInd);
        else if(!eventFired)
        {
            OnDone.Invoke();
            eventFired = true;
        }
	}
}
