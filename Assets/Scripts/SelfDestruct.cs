﻿using UnityEngine;
using System.Collections;

public class SelfDestruct: MonoBehaviour
{
    public float time;

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void DestroyNow()
    {
        Destroy(gameObject);
    }
}
