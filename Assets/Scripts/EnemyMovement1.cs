using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement1 : MonoBehaviour
{
    public float walkSpeed = 2.0f;
    float walkingDirection = 1.0f;
    public Transform enemyTransform;
    public Transform rayEnemyTransform;
    Vector2 walkAmount;


    // Update is called once per frame
    void Update()
    {
        walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;
        enemyTransform.Translate(walkAmount);

        bool collides = Physics2D.Raycast(rayEnemyTransform.position, Vector2.right, 0.01f);
        if (collides)
            Flip();
    }
    
    public void Flip()
    {
        walkingDirection *= -1.0f;
    }
}
