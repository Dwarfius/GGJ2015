using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
    public Vector2 speed = Vector2.one;

    float spriteHeight;
    bool jumping;

    public Texture2D tutorial1;

    void Start()
    {
        spriteHeight = collider2D.bounds.size.y / transform.localScale.y;
        Debug.Log(GameData.Instance);
    }

    void Update()
    {
        jumping = Input.GetButton("Jump");

        float dx = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(dx * speed.x * Time.deltaTime, 0, 0));
    }

    void FixedUpdate()
    {
        if (jumping && Physics2D.Raycast(transform.position, -Vector2.up, spriteHeight / 1.6f))
            rigidbody2D.AddForce(new Vector2(0, speed.y), ForceMode2D.Impulse);
    }


}
