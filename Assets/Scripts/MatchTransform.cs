using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchTransform : MonoBehaviour
{
    public Transform target;
    
    private Rigidbody2D rb;
        private void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target)
        {
            if (rb)
            {
                rb.MovePosition(target.position);
                rb.SetRotation(target.rotation);
            }
            else
            {
                transform.position = target.position;
                transform.rotation = target.rotation;
            }
        }
    }
}
