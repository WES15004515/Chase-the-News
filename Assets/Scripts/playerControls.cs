using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControls : MonoBehaviour
{

    public float speed = 1.0f;
    public float jumpSpeed = 5.5f;
    public LayerMask groundLayer;

    public Transform gCheck;
    private float scaleX = 1.0f;
    private float scaleY = 1.0f;

    public float timeBetweenJumps = 0.5f;
    public float timeTilNextJump = 1.0f;

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        bool touchesGround = Physics2D.OverlapPoint(gCheck.position, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && (Time.time > timeTilNextJump))
        {
            if (touchesGround)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
                touchesGround = false;
                timeTilNextJump = Time.time + timeBetweenJumps;
            }
        }


        if (h > 0)
        {
            transform.localScale = new Vector2(scaleX, scaleY);
        }
        else if (h < 0)
        {
            transform.localScale = new Vector2(-scaleX, scaleY);
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(h * speed, GetComponent<Rigidbody2D>().velocity.y);

    }
}
