using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public Room testRoom;
    public LayerMask checkLayerMask;
    public Cinemachine.CinemachineVirtualCamera camera1, camera2;

    public Grid Grid { get; private set; }

    private Cinemachine.CinemachineVirtualCamera curCam;

    private void Start()
    {
        Grid = GetComponent<Grid>();

        //for (int x = -5; x < 5; x++)
        //{
        //    for (int y = -5; y < 5; y++)
        //    {
        //        Instantiate(testRoom, grid.CellToWorld(new Vector3Int(x, y, 0)), Quaternion.identity, transform);
        //    }
        //}

        curCam = camera1;
        camera2.Priority = 0;
    }

    public Room CheckRoom(Vector3Int cell)
    {
        return Physics2D.OverlapPoint(Grid.CellToWorld(cell), checkLayerMask)?.GetComponentInParent<Room>();
    }

    public Room SpawnRoom(Room room, Vector3Int cell)
    {
        Room newRoom = Instantiate(room, Grid.CellToWorld(cell), Quaternion.identity);
        newRoom.map = this;
        return newRoom;
    }

    public void EnterRoom(Room room)
    {
        if (curCam == camera1)
        {
            camera2.Follow = room.transform;
            camera2.Priority = 10;
            camera1.Priority = 0;
            curCam = camera2;
        }
        else
        {
            camera1.Follow = room.transform;
            camera1.Priority = 10;
            camera2.Priority = 0;
            curCam = camera1;
        }
    }

    public void ExitRoom(Room room)
    {
        if (curCam.Follow == room.transform)
        {
            if (curCam == camera1)
            {
                camera2.Priority = 10;
                camera1.Priority = 0;
                curCam = camera2;
            }
            else
            {
                camera1.Priority = 10;
                camera2.Priority = 0;
                curCam = camera1;
            }

        }
    }
}
