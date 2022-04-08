using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMovement : MonoBehaviour
{
    public float speedMagnitude;
    Vector3 direction;

    private void Update()
    {
        transform.position += direction*speedMagnitude*Time.deltaTime;

    }

    public void SetDirection(Vector3 value)
    {
        direction=value;
    }

    public Vector3 GetDirection()
    {
        return direction;
    }
}
