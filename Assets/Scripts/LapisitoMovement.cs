using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapisitoMovement : MonoBehaviour
{
    Transform player;

    public Rigidbody2D rb;

    float horizontal = 0.0f;

    public float speed = 1.0f;

    public float jumpmagnitude;

    public SpriteRenderer spriteRenderer;

    public Transform rayOriginTransform;

    public Animator animator;

    bool grounded;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerClose() == true)
        {
            if (player.rayOriginTransform.position.x <= rayOriginTransform.position.x)
            {
                horizontal = -1.0f;
                spriteRenderer.flipX = false;
            }
            else if (player.rayOriginTransform.position.x >= rayOriginTransform.position.x)
            {
                horizontal = 1.0f;
                spriteRenderer.flipX = true;
            }

            if (player.rayOriginTransform.position.x >= rayOriginTransform.position.x-2.0f || player.rayOriginTransform.position.x <= rayOriginTransform.position.x + 2.0f)
            jump();
        }
      


        grounded = Physics2D.Raycast(rayOriginTransform.position, Vector2.down, 0.01f);

        bool isMoving = horizontal != 0;

        animator.SetBool("isMoving", isMoving);
    }

    private void FixedUpdate()
    {

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

    }

    void jump()
    {
        if (grounded == true)
        {

            rb.AddForce(Vector2.up * jumpmagnitude);
        }
    }

    bool isPlayerClose ()
    {
        if (rayOriginTransform.position.x - 10.0f <= player.rayOriginTransform.position.x && player.rayOriginTransform.position.x <= rayOriginTransform.position.x + 10.0f)
        {
            return true;
        }
        else
            return false;
    }
}
