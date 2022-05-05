using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float delta = 0.001f;

    // Update is called once per frame
    void Update()
    {
        Vector3 finalPos;
        if (target.position.x<=-5.9f)
        {
            finalPos = new Vector3(-5.9f, target.position.y + 0.6f, transform.position.z);
        }
        else if (target.position.x >= 6.4f)
        {
            finalPos = new Vector3(6.4f, target.position.y + 0.6f, transform.position.z);
        }
        else
        {
            finalPos = new Vector3(target.position.x, target.position.y + 0.6f, transform.position.z);
        }


        transform.position = Vector3.MoveTowards(transform.position, finalPos, delta);
 
    }
}
