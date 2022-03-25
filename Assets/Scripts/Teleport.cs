using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] GameObject gameObjectToTeleport;

    public void TP(Vector2 targetPos)
    {
        gameObjectToTeleport.transform.position = targetPos;
    }


    public void TPWithDelay(Vector2 targetPos, float delay)
    {
       
        StartCoroutine( CrTpWithDelay(targetPos, delay));

    }

    IEnumerator CrTpWithDelay(Vector2 targetPos, float delay)
    {
        gameObjectToTeleport.SetActive(false);
        gameObjectToTeleport.transform.position = targetPos;
        yield return new WaitForSeconds(delay);
        gameObjectToTeleport.SetActive(true);
    }
}

