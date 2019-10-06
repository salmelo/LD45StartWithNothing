using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject testRoom;
    private Grid grid;

    private void Start()
    {
        grid = GetComponent<Grid>();

        for (int x = -5; x < 5; x++)
        {
            for (int y = -5; y < 5; y++)
            {
                Instantiate(testRoom, grid.CellToWorld(new Vector3Int(x, y, 0)), Quaternion.identity, transform);
            }
        }
    }
}
