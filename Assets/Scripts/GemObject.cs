using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemObject : MonoBehaviour
{
    public RoomGem gem;

    public void Pickup()
    {
        InventoryManager.current.GetGem(gem);
        Destroy(gameObject);
    }

    [ContextMenu("Color sprite")]
    private void ColorSprite()
    {
        GetComponent<SpriteRenderer>().color = gem.color;
    }

    [ContextMenu("Color sprite", true)]
    private bool CanColor()
    {
        return gem;
    }

    private void OnValidate()
    {
        if (gem)
        {
            GetComponent<SpriteRenderer>().color = gem.color;
        }
    }
}
