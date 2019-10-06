using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    public Swinger leftHand, rightHand;

    private Vector2 move;
    private Vector2 toMove;

    private Rigidbody2D rb;
    private MatchTransform leftItemObj, rightItemObj;

    private HandItem leftItem, rightItem;

    public static PlayerController current { get; private set; }

    public HandItem LeftItem
    {
        get => leftItem;
        set
        {
            if (leftItem != value)
            {
                SetHandItem(value, leftHand, ref leftItemObj, ref leftItem);
            }
        }
    }
    public HandItem RightItem
    {
        get => rightItem;
        set
        {
            if (rightItem != value)
            {
                SetHandItem(value, rightHand, ref rightItemObj, ref rightItem);
            }
        }
    }

    private void SetHandItem(HandItem item, Swinger hand, ref MatchTransform obj, ref HandItem slot)
    {
        if (obj)
        {
            Destroy(obj.gameObject);
        }
        obj = item.SpawnItem(hand.transform);
        slot = item;
    }

    private void Awake()
    {
        current = this;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //leftItem = testItem1.SpawnItem(leftHand.transform);
        //rightItem = testItem2.SpawnItem(rightHand.transform);


        //GetComponent<PlayerInput>().SwitchCurrentActionMap("UI");
        //GetComponent<PlayerInput>().enabled = false;
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

    private void OnRightAction(InputValue value)
    {
        if (RightItem)
        {
            RightItem.DoSwing(rightHand);
        }
    }

    private void OnLeftAction()
    {
        if (LeftItem)
        {
            LeftItem.DoSwing(leftHand);
        }
    }
}
