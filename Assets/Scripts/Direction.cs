using UnityEngine;

public enum Direction
{
    North, East, South, West
}

public static class DirectionExtensions
{
    public static Vector3Int ToVector(this Direction dir)
    {
        switch (dir)
        {
            case Direction.North:
                return Vector3Int.up;
            case Direction.East:
                return Vector3Int.right;
            case Direction.South:
                return Vector3Int.down;
            case Direction.West:
                return Vector3Int.left;
            default:
                return Vector3Int.zero;
        }
    }
}