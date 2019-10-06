using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GemButton: MonoBehaviour
{
    public RoomGem gem;
    public Image gemImage;
    
    // Use this for initialization
    void Start()
    {
        gemImage.color = gem.color;
    }

    public void ChooseGem()
    {
        if (InventoryManager.current.ChooseGem(gem))
        {
            Destroy(gameObject);
        }
    }
}
