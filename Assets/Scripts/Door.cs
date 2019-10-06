using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Door: MonoBehaviour
{
    public Direction direction;
    public DoorEvent doorOpened;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            doorOpened.Invoke(this);
        }
    }
}
