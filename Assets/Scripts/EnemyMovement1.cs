using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement1 : MonoBehaviour
{
    public float walkSpeed = 2.0f;
    float walkingDirection = 1.0f;
    public Transform enemyTransform;
    public Transform rayEnemyTransform;
    public SpriteRenderer spriteRenderer;
    Vector2 walkAmount;

    public Animator animator;

    private int enemyState=0;

    // Update is called once per frame
    void Update()
    {
        walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;
        enemyTransform.Translate(walkAmount);

        bool collides= false;

        float rayLength=0.1f;
        Vector2 rayDirection=Vector2.right;
        if (walkingDirection < 0.0f)
            rayDirection = Vector2.left;

        if (Physics2D.Raycast(rayEnemyTransform.position, rayDirection, rayLength))
        {
            collides = true;
        }

        if (collides)
            Flip();

        HP hp = GetComponent<HP>();
        if (hp.hp >=40)
        {
            enemyState = 0;
        }
        else if (hp.hp >= 20)
        {
            enemyState = 1;
        }
        else if (hp.hp >= 0)
        {
            enemyState = 2;
        }

        animator.SetInteger("State", enemyState);
    }
    
    public void Flip()
    {
        walkingDirection *= -1.0f;
        if (spriteRenderer.flipX == true)
            spriteRenderer.flipX = false;
        else
            spriteRenderer.flipX = true;
    }

}
