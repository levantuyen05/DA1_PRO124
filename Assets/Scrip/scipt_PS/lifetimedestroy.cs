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

    // Update is called once per frame
    void Update()
    {
        
    }
}
