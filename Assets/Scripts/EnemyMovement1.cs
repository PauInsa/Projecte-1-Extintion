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
            Debug.DrawRay(rayEnemyTransform.position, rayDirection * rayLength, Color.green);
        }
        else
        {
            Debug.DrawRay(rayEnemyTransform.position, rayDirection * rayLength, Color.red);
        }

        if (collides)
            Flip();
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
