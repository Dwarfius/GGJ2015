using UnityEngine;
using System.Collections;

public class EnemyKnight : MonoBehaviour 
{
    public float speed;

    int facing = -1;
    float height;

    void Start()
    {
        height = collider2D.bounds.size.y / transform.localScale.y;
    }

	void Update () 
    {
	    //before moving, check availability
        float dX = Time.deltaTime * speed;
        if (Physics2D.Raycast(transform.position, transform.right * facing, dX * 10))
            facing *= -1;
        else if (!Physics2D.Raycast(transform.position + transform.right * dX, -Vector2.up, height / 1.6f))
            facing *= -1;

        transform.Translate(transform.right * dX * facing);
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
            Destroy(col.gameObject);
    }
}
