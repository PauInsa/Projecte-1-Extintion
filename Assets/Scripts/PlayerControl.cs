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

    public AudioSource audioSource;

    bool grounded;
    public Transform gun;
    public GameObject bullet;

    private float timeToShoot = 0.5f;
    private float currentTimeToShoot;

    // Start is called before the first frame update
    void Start()
    {
        currentTimeToShoot = timeToShoot;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
            return;

        bool isJumping = false;
        bool isShooting = false;

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


        if (currentTimeToShoot <= 0)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                Shoot();
                currentTimeToShoot = timeToShoot;
                isShooting = true;
            }
        }
        else
        {
            currentTimeToShoot -= Time.deltaTime;
        }



        grounded = Physics2D.Raycast(rayOriginTransform.position, Vector2.down, 0.1f);


        bool isMoving = horizontal != 0;


        animator.SetBool("isMoving", isMoving);
        animator.SetBool("isJumping", isJumping);
        animator.SetBool("isShooting", isShooting);
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
            if (grounded == true)
                audioSource.Play();
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

