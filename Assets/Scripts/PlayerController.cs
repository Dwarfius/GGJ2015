using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour 
{
    public Vector2 speed = Vector2.one;
    public GameObject projectilePrefab;
    public List<string> items;

    float spriteHeight;
    bool jumping;
    Animator animator;
    bool facing = true;
    Collider2D arm;

    public Texture2D tutorial1;

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

        float dx = Input.GetAxis("Horizontal");
        facing = dx > 0 ? true : dx < 0 ? false : facing;
        transform.Translate(new Vector3(dx * speed.x * Time.deltaTime, 0, 0));
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
        Debug.DrawLine(transform.position, transform.position - Vector3.up * spriteHeight / 1.9f);
        if (jumping && Physics2D.Raycast(transform.position, -Vector2.up, spriteHeight / 1.9f))
            rigidbody2D.AddForce(new Vector2(0, speed.y), ForceMode2D.Impulse);
    }

    void Attack()
    {
        animator.SetBool("attacking", true);
        arm.enabled = true;
        StartCoroutine(armCd());
    }

    void Fire()
    {
        Quaternion angle = Quaternion.Euler(0, 0, facing ? 30 : 150);
        GameObject projectile = (GameObject)Instantiate(projectilePrefab, transform.position, angle);
        Physics2D.IgnoreCollision(projectile.collider2D, collider2D);
        projectile.GetComponent<Arrow>().SetTargetTag("Enemy");
        projectile.rigidbody2D.velocity = 5 * projectile.transform.right;
    }

    Interactible item = null;
    void Use()
    {
        if (item)
            item.Interact(this);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy" && arm.enabled)
            Destroy(col.gameObject);

        if (col.tag == "Interactible")
            item = col.GetComponent<Interactible>();
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Interactible")
            item = null;
    }

    IEnumerator armCd()
    {
        yield return new WaitForSeconds(1.083f);
        arm.enabled = false;
        animator.SetBool("attacking", false);
    }
}
