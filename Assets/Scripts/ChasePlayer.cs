using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    public float speed = 4;
    public float chaseArc = 0;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!MapManager.IsInPlayerRoom(transform.position))
        {
            return;
        }

        var target = PlayerController.current.transform.position;
        var dir = target - transform.position;

        if (chaseArc > 0)
        {
            var angle = Mathf.Atan2(dir.x, dir.y);
            if (Mathf.Abs(angle) > chaseArc)
            {
                return;
            }
        }

        rb.MovePosition(Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime));
    }
}
