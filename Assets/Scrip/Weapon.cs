using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    

    void Update()
    {
        RotateGun();
    }
    void RotateGun()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        Quaternion  rotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = rotation;
        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
        {
            // Flip the object by rotating it 180 degrees around the x-axis
            transform.rotation = Quaternion.Euler(180f, 0f, -transform.eulerAngles.z);
        }
        else
        {
            // Ensure the object is in its normal orientation
            transform.rotation = Quaternion.Euler(0f, 0f, transform.eulerAngles.z);
        }


    }
}
