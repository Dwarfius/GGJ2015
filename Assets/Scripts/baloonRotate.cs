using UnityEngine;
using System.Collections;

public class baloonRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);
	
	}
}
