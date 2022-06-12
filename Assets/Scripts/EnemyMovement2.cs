using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement2 : MonoBehaviour
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

        bool collides = false;

        float rayLength = 0.1f;
        Vector2 rayDirection = Vector2.right;
        if (walkingDirection < 0.0f)
            rayDirection = Vector2.left;

        if (Physics2D.Raycast(rayEnemyTransform.position, rayDirection, rayLength))
        {
            collides = true;
        }

        if (collides)
            Flip();
    }

    public void Flip()
    {
        walkingDirection *= -1.0f;
    }
}