using UnityEngine;
using System.Collections;

public class EnemyKnight : MonoBehaviour 
{
    public float speed;
    public LayerMask mask;

    int facing = 1;
    float height;

    void Start()
    {
        height = collider2D.bounds.size.y;
    }

	void Update () 
    {
	    //before moving, check availability
        float dX = Time.deltaTime * speed;
        Debug.DrawLine(transform.position, transform.position + transform.right * facing * dX * 30);
        if (Physics2D.Raycast(transform.position, transform.right * facing, dX * 30, mask))
        {
            facing *= -1;
            Vector3 v = transform.localScale;
            v.x *= -1;
            transform.localScale = v;
        }
        else if (!Physics2D.Raycast(transform.position + transform.right * dX, -Vector2.up, height / 1.6f, mask))
        {
            Debug.Log("tet");
            facing *= -1;
            Vector3 v = transform.localScale;
            v.x *= -1;
            transform.localScale = v;
        }

        transform.Translate(transform.right * dX * facing);
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
            Destroy(col.gameObject);
    }
}
