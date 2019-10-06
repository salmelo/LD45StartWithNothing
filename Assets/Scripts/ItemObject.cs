using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public HandItem item;
    
    public void Pickup()
    {
        InventoryManager.current.GetItem(item);
        Destroy(gameObject);
    }
}
