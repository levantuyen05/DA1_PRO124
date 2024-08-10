using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5f;

    void FixedUpdate()
    {
        Vector3 targetPosition = target.position;
        targetPosition.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
    }
}
