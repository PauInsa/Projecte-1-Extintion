using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearlMovement : MonoBehaviour
{
    public Vector3 speed;

    private void Update()
    {
        transform.position += speed*Time.deltaTime;
    }

    public void ChangeSpeed()
    {
        speed *= -1.0f;
    }
}
