using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour 
{
    public Vector2 speed = Vector2.one;
    public GameObject projectilePrefab;
    public List<string> items;

    float dx;
    float spriteHeight;
    bool jumping;
    Animator animator;
    bool facing = true;
    Collider2D arm;

    void Start()
    {
        arm = transform.GetChild(0).collider2D;
        animator = GetComponent<Animator>();
        spriteHeight = collider2D.bounds.size.y;
        Debug.Log(GameData.Instance); //forcing it to spawn to have a menu
    }

    void Update()
    {
        jumping = Input.GetButton("Jump");
        animator.SetBool("jump", jumping);
        animator.SetBool("falling", rigidbody2D.velocity.y < 0);

        dx = Input.GetAxis("Horizontal");
        facing = dx > 0 ? true : dx < 0 ? false : facing;
        animator.SetBool("run", dx != 0);

        Vector3 v = transform.localScale;
        v.x = facing ? Mathf.Abs(v.x) : -Mathf.Abs(v.x);
        transform.localScale = v;

        if (Input.GetButtonDown("Use"))
            Use();
        if (Input.GetButtonDown("Attack"))
            Attack();
        if (Input.GetButtonDown("Fire"))
            animator.SetBool("preppingShot", true);
        if (Input.GetButtonUp("Fire"))
        {
            animator.SetBool("preppingShot", false);
            Fire();
        }
    }

    void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector3(dx * speed.x, rigidbody2D.velocity.y, 0);
        Vector3 leftSide = collider2D.bounds.center - new Vector3(collider2D.bounds.size.x / 2, 0, 0);
        Vector3 rightSide = collider2D.bounds.center + new Vector3(collider2D.bounds.size.x / 2, 0, 0);
        Debug.DrawLine(leftSide, leftSide - Vector3.up * spriteHeight / 1.8f);
        Debug.DrawLine(rightSide, rightSide - Vector3.up * spriteHeight / 1.8f);
        if (jumping && (Physics2D.Raycast(leftSide, -Vector2.up, spriteHeight / 1.8f) ||
                        Physics2D.Raycast(rightSide, -Vector2.up, spriteHeight / 1.8f)))
            rigidbody2D.AddForce(new Vector2(0, speed.y), ForceMode2D.Impulse);
    }

    void Attack()
    {
        animator.SetBool("attack", true);
        arm.enabled = true;
        StartCoroutine(armCd());
    }

    void Fire()
    {
        Quaternion angle = Quaternion.Euler(0, 0, facing ? 30 : 150);
        GameObject projectile = (GameObject)Instantiate(projectilePrefab, transform.position, angle);
        Physics2D.IgnoreCollision(projectile.collider2D, collider2D);
        projectile.GetComponent<Arrow>().SetTargetTag("Enemy");
        projectile.rigidbody2D.velocity = 10 * projectile.transform.right;
    }

    Interactible item = null;
    void Use()
    {
        Debug.Log(item);
        if (item)
            item.Interact(this);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy" && arm.enabled && col.gameObject.GetComponent<Donkey>() == false)
            Destroy(col.gameObject);
        if (col.gameObject.tag == "Enemy" && arm.enabled && col.gameObject.GetComponent<Donkey>() == true)
        {
            Donkey donk = col.gameObject.GetComponent<Donkey>();
            donk.healthPoints--;
        }

    }

    //used to recieve triggers from the sword arm
    void OnTriggerEnter2D(Collider2D col)
    {
        

        if (col.tag == "Interactible")
            item = col.gameObject.GetComponent<Interactible>();
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Interactible")
            item = null;
    }

    IEnumerator armCd()
    {
        yield return new WaitForSeconds(0.467f);
        arm.enabled = false;
        animator.SetBool("attack", false);
    }
}
