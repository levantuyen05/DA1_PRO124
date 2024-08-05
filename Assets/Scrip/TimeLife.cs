using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLife : MonoBehaviour
{
    public float LifeTime = 2f;

    private void Start()
    {
        Destroy(this.gameObject, LifeTime);
    }

}
