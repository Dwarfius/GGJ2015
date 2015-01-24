﻿using UnityEngine;
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
        spriteHeight = collider2D.bounds.size.y / transform.localScale.y;
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
        if (jumping && Physics2D.Raycast(transform.position, -Vector2.up, spriteHeight / 1.6f))
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
        Vector3 n = Vector3.right;
        GameObject projectile = (GameObject)Instantiate(projectilePrefab, transform.position + (facing ? n : -n) / 6, angle);
        projectile.GetComponent<Arrow>().SetTargetTag("Enemy");
        projectile.rigidbody2D.velocity = 5 * projectile.transform.right;
    }

    Interactible item = null;
    void Use()
    {
        if (item)
            item.Interact(this);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Interactible")
            item = col.gameObject.GetComponent<Interactible>();
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Interactible")
            item = null;
    }

    //used to recieve triggers from the sword arm
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
            Destroy(col.gameObject);
    }

    IEnumerator armCd()
    {
        yield return new WaitForSeconds(1.083f);
        arm.enabled = false;
        animator.SetBool("attacking", false);
    }
}
