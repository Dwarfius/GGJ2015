using UnityEngine;
using System.Collections;

public class EnemyKnight : MonoBehaviour 
{
    public float speed;
    public LayerMask avoidMask;
    public LayerMask attackMask;

    int facing = 1;
    float height;
    Animator animator;
    Collider2D arm;

    void Start()
    {
        height = collider2D.bounds.size.y;
        animator = GetComponent<Animator>();
        arm = transform.GetChild(0).collider2D;
    }

	void Update () 
    {
        arm.enabled = animator.GetBool("attack");
        //before moving, check availability
        float dX = Time.deltaTime * speed;
        Debug.DrawLine(transform.position, transform.position + transform.right * facing * dX * 30);
        if (!animator.GetBool("attack") && Physics2D.Raycast(transform.position, transform.right * facing, 3, attackMask)) //attempt an attack if can
        {
            StartCoroutine(AttackAnim());
        }
        if (Physics2D.Raycast(transform.position, transform.right * facing, dX * 30, avoidMask))
        {
            facing *= -1;
            Vector3 v = transform.localScale;
            v.x *= -1;
            transform.localScale = v;
        }
        else if (!Physics2D.Raycast(transform.position + transform.right * dX, -Vector2.up, height / 1.6f, avoidMask))
        {
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
            col.gameObject.GetComponent<PlayerController>().Die();
    }

    IEnumerator AttackAnim()
    {
        animator.SetBool("attack", true);
        yield return new WaitForSeconds(1f);
        animator.SetBool("attack", false);
    }
}
