using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
    public Vector2 speed = Vector2.one;

    float spriteHeight;
    bool jumping;
    Animation2d anim;

    void Start()
    {
        spriteHeight = (collider2D as BoxCollider2D).bounds.size.y / transform.localScale.y;
        anim = GetComponent<Animation2d>();
    }

    void Update()
    {
        jumping = Input.GetButton("Jump");

        float dx = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(dx * speed.x * Time.deltaTime, 0, 0));
        UpdateState(dx);
    }

    void FixedUpdate()
    {
        if (jumping && Physics2D.Raycast(transform.position, -Vector2.up, spriteHeight / 1.6f))
            rigidbody2D.AddForce(new Vector2(0, speed.y), ForceMode2D.Impulse);
    }

    void UpdateState(float xSpeed)
    {
        if (rigidbody2D.velocity.y < 0)
            anim.SetState(Animation2d.State.Fall);
        else if (rigidbody2D.velocity.y > 0)
            anim.SetState(Animation2d.State.Jump);
        else if (xSpeed != 0)
            anim.SetState(Animation2d.State.Run);
        else
            anim.SetState(Animation2d.State.Idle);
    }
}
