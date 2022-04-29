using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    public int hp;
    
    public void DamageReceived(int damage)
    {
        hp -= damage;
        if (hp <= 0)
            Die();
    }


    

    void Die()
    {
        gameObject.SetActive(false);
    }
}
