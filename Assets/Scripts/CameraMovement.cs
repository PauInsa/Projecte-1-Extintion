using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float delta = .03f;

    // Update is called once per frame
    void Update()
    {
        Vector3 finalPos = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, finalPos, delta);
 
    }
}
