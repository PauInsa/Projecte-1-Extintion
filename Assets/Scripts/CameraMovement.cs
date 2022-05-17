using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float delta = 0.001f;

    private float rightLimit = 6.4f;
    private float leftLimit = -5.9f;
    private float upLimit = 1.4f;

    private float extraY = 0.6f;

    // Update is called once per frame
    void Update()
    {
        Vector3 finalPos;
        if (target.position.x<=leftLimit)
        {
            if (target.position.y >= upLimit)
            {
                finalPos = new Vector3(leftLimit, upLimit + extraY, transform.position.z);
            }
            else
                finalPos = new Vector3(leftLimit, target.position.y + extraY, transform.position.z);
        }
        else if (target.position.x >= rightLimit)
        {
            if (target.position.y >= upLimit)
            {
                finalPos = new Vector3(rightLimit, upLimit + extraY, transform.position.z);
            }
            else
                finalPos = new Vector3(rightLimit, target.position.y + extraY, transform.position.z);
        }
        else if (target.position.y >= upLimit)
        {
            finalPos = new Vector3(target.position.x, upLimit + extraY, transform.position.z);
        }
        else
        {
            finalPos = new Vector3(target.position.x, target.position.y + extraY, transform.position.z);
        }

        


        transform.position = Vector3.MoveTowards(transform.position, finalPos, delta);
 
    }
}
