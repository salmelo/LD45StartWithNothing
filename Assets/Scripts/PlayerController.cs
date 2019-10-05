using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;

    private Vector2 move;
    private Vector2 toMove;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMove(InputValue value)
    {
        move = value.Get<Vector2>();
    }

    private void Update()
    {
        toMove += move * speed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        Vector2 target = rb.position += toMove;
        if (toMove != Vector2.zero)
        {
            Debug.Log(Mathf.Atan2(toMove.y, toMove.x));
            rb.SetRotation(Mathf.Atan2(-toMove.x, toMove.y) * Mathf.Rad2Deg);
            rb.MovePosition(target);
        }
        toMove = Vector2.zero;

    }

    private void OnRightAction()
    {
        GetComponentInChildren<Swinger>().DoSwing(.5f, 360, 360, 1);
    }
}
