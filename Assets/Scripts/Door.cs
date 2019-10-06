using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Door: MonoBehaviour
{
    public Direction direction;
    public float openTime = 1;
    public SpriteRenderer socket;
    public DoorEvent doorOpened;
    public Room room;

    public RoomGem Gem { get; private set; }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (room.CheckRoom(direction))
            {
                OpenDoor();
            }
            else
            {
                InventoryManager.current.PickGem(OpenDoor);
            }
        }
    }

    private void OpenDoor(RoomGem gem)
    {
        if (gem == null)
        {
            return;
        }

        Gem = gem;
        socket.color = gem.color;

        OpenDoor();
    }

    private void OpenDoor()
    {
        doorOpened.Invoke(this);
        StartCoroutine(Open());
    }

    IEnumerator Open()
    {
        var ren = GetComponent<SpriteRenderer>();
        var c = ren.color;
        var speed = c.a / openTime;

        while (c.a > 0)
        {
            c.a = Mathf.MoveTowards(c.a, 0, speed * Time.deltaTime);
            ren.color = c;
            yield return null;
        }

        Destroy(gameObject);
    }
}
