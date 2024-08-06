using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifetimedestroy : MonoBehaviour
{
    public float time;
    void Start()
    {
        Destroy(this.gameObject,time);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            Destroy(this.gameObject);
        }
    }
}
