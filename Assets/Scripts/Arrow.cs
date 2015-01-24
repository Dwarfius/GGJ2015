using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour 
{
    public float lifeTime = 10;

    string targetTag;

	void Start () 
    {
        Destroy(gameObject, 60);
	}

    void Update()
    {
        transform.right = Vector3.Slerp(transform.right, rigidbody2D.velocity.normalized, Time.deltaTime * 3);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == targetTag)
            Destroy(col.gameObject);
        else if (col.gameObject.tag == "Ground")
        {
            rigidbody2D.fixedAngle = true;
            rigidbody2D.isKinematic = true;
            collider2D.enabled = false;
            Destroy(gameObject, lifeTime);
        }
    }

    public void SetTargetTag(string targetTag)
    {
        this.targetTag = targetTag;
    }
}
