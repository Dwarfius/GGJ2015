﻿using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour 
{
    public float lifeTime = 10;

	void Start () 
    {
        Destroy(gameObject, 60);
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
            Destroy(col.gameObject);
        else if (col.gameObject.tag == "Ground")
        {
            rigidbody2D.fixedAngle = true;
            rigidbody2D.isKinematic = true;
            collider2D.enabled = false;
            Destroy(gameObject, lifeTime);
        }
    }
}