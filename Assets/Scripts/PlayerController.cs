using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    public Swinger leftHand, rightHand;
    public HandItem testItem1, testItem2;

    private Vector2 move;
    private Vector2 toMove;

    private Rigidbody2D rb;
    private MatchTransform leftItem, rightItem;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        leftItem = testItem1.SpawnItem(leftHand.transform);
        rightItem = testItem2.SpawnItem(rightHand.transform);
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
            rb.SetRotation(Mathf.Atan2(-toMove.x, toMove.y) * Mathf.Rad2Deg);
            rb.MovePosition(target);
        }
        toMove = Vector2.zero;

    }

    private void OnRightAction()
    {
        testItem2.DoSwing(rightHand);
    }

    private void OnLeftAction()
    {
        testItem1.DoSwing(leftHand);
    }
}
