using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject spawnPrefab;
    public Transform spawnPoint;

    public void Spawn()
    {
        var t = spawnPoint ? spawnPoint : transform;
        Instantiate(spawnPrefab, t.position, t.rotation);
    }
}
