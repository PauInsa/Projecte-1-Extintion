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

        bool isJumping = false;

        if (Input.GetKeyDown(KeyCode.W))
        {
            jump();
            isJumping = true;
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



        if (Input.GetKeyDown(KeyCode.K))
        {
            Shoot();
        }



        grounded = Physics2D.Raycast(rayOriginTransform.position, Vector2.down, 0.1f);


        bool isMoving = horizontal != 0;

        animator.SetBool("isMoving", isMoving);
        animator.SetBool("isJumping", isJumping);
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
        LinearMovement bulletMovement = goBullet.GetComponent<LinearMovement>();

        if (spriteRenderer.flipX == false)
        {
            bulletMovement.SetDirection(Vector3.left);
        }
        else
            bulletMovement.SetDirection(Vector3.right);



        bool collides = false;

        if (collides==true)
        {
            Destroy(goBullet);
        }
    }
}

