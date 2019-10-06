using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public bool startRandomSpin;
    public float spin = 30;

    private Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (startRandomSpin)
        {
            var angle = Random.Range(0f, 360f);
            if (rb)
            {
                rb.SetRotation(angle);
            }
            else
            {
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.back);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!rb)
        {
            transform.rotation = transform.rotation * Quaternion.AngleAxis(spin * Time.deltaTime, Vector3.back);
        }
    }

    private void FixedUpdate()
    {
        if (rb)
        {
            rb.MoveRotation(spin * Time.fixedDeltaTime);
        }
    }
}
