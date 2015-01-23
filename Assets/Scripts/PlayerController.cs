using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
    public Vector2 speed = Vector2.one;

    float spriteHeight;

    void Start()
    {
        spriteHeight = (renderer as SpriteRenderer).sprite.bounds.size.y / transform.localScale.y;
    }

    void Update()
    {
        bool jumping = Input.GetButton("Jump");
        if (jumping && Physics2D.Raycast(transform.position, -Vector2.up, spriteHeight))
            rigidbody2D.AddForce(new Vector2(0, speed.y), ForceMode2D.Impulse);

        float dx = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(dx * speed.x * Time.deltaTime, 0, 0));
    }
}
