using UnityEngine;
using System.Collections;

public class Room : MonoBehaviour
{
    public MapManager map;
    public Door northDoor, eastDoor, southDoor, westDoor;
    public Transform center;

    public void OnDoorOpened(Door door)
    {
        Vector3Int dir;
        if (door == northDoor) { dir = Vector3Int.up; }
        else if (door == eastDoor) { dir = Vector3Int.right; }
        else if (door == southDoor) { dir = Vector3Int.down; }
        else if (door == westDoor) { dir = Vector3Int.left; }
        else { return; }

        Vector3Int cell = map.Grid.WorldToCell(transform.position) + dir;
        Room otherRoom = map.CheckRoom(cell);
        if(!otherRoom)
        {
            otherRoom = map.SpawnRoom(door.Gem.roomPrefab, cell);
        }
        Door otherDoor;
        if (door == northDoor) { otherDoor = otherRoom.southDoor; }
        else if (door == eastDoor) { otherDoor = otherRoom.westDoor; }
        else if (door == southDoor) { otherDoor = otherRoom.northDoor; }
        else if (door == westDoor) { otherDoor = otherRoom.eastDoor; }
        else { throw new System.InvalidOperationException(); }

        Destroy(otherDoor.gameObject);
        //Destroy(door.gameObject);
    }

    public Room CheckRoom(Direction dir)
    {
        var cell = map.Grid.WorldToCell(transform.position) + dir.ToVector();
        return map.CheckRoom(cell);
    }

    public void EnterRoom()
    {
        map.EnterRoom(this);
    }

    public void ExitRoom()
    {
        map.ExitRoom(this);
    }
}
