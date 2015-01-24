using UnityEngine;
using System.Collections;

public class EnemyArcher : MonoBehaviour 
{
    public float shootCooldown = 3;
    public GameObject arrowPrefab;

    Transform target;
    float shootCd;

	void Update () 
    {
        if (target && shootCd < 0)
        {
            float v = 5;
            float A = GetFiringAngleSolution(transform.position, target.position, v);
            Quaternion angle = Quaternion.Euler(0, 0, A * Mathf.Rad2Deg);
            GameObject arrow = (GameObject)Instantiate(arrowPrefab, transform.position, angle);
            Physics2D.IgnoreCollision(arrow.collider2D, collider2D);
            arrow.GetComponent<Arrow>().SetTargetTag("Player");
            arrow.rigidbody2D.velocity = v * arrow.transform.right;
            shootCd = shootCooldown;
        }
        else
            shootCd -= Time.deltaTime;
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
            target = col.transform;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
            target = col.transform;
    }

    float GetFiringAngleSolution(Vector2 p1, Vector2 p2, float v)
    {
        float x = p2.x - p1.x;
        float y = p2.y - p1.y;
        float g = Physics.gravity.magnitude;
        float a1 = Mathf.Atan((v*v + Mathf.Sqrt(Mathf.Pow(v, 4) - g*(g*x*x + 2*y*v*v)))/(g*x));
        float a2 = Mathf.Atan((v*v - Mathf.Sqrt(Mathf.Pow(v, 4) - g*(g*x*x + 2*y*v*v)))/(g*x));
        return Mathf.Min(a1, a2);
    }
}
