using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour

{
    public Rigidbody2D rb;

    float horizontal = 0.0f;

    public float speed = 1.0f;

    public float jumpmagnitude;

    public SpriteRenderer spriteRenderer;

    public Transform rayOriginTransform;

    public Animator animator;

    bool grounded;
    public Transform gun;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            jump();

        }

        if (Input.GetKey(KeyCode.A))
        {
            horizontal = -1.0f;
            spriteRenderer.flipX = false;
        }
        else if (Input.GetKey(KeyCode.D))
        {

            horizontal = 1.0f;
            spriteRenderer.flipX = true;
        }
        else
            horizontal = 0.0f;

        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
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

    void Shoot()
    {
        GameObject goBullet = Instantiate(bullet, gun.position, Quaternion.identity);
        GetComponent<LinearlMovement>();
        

    }
}

