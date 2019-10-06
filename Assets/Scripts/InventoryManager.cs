using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public List<RoomGem> gems;
    public List<HandItem> items;
    public UnityEngine.InputSystem.InputActionAsset playerActions, uIActions;
    public GemButton gemButtonPrefab;
    public Transform gemButtonPanel;

    public static InventoryManager instance;

    private System.Action<RoomGem> pickGemCallback;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        uIActions.FindAction("Cancel").performed += UICancelPerformed; 

        uIActions.Disable();
    }

    private void UICancelPerformed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (pickGemCallback != null)
        {
            pickGemCallback(null);
            pickGemCallback = null;
        }

        EventSystem.current.SetSelectedGameObject(null);

        uIActions.Disable();
        playerActions.Enable();
    }

    public void GetGem(RoomGem gem)
    {
        gems.Add(gem);
        var button = Instantiate(gemButtonPrefab, gemButtonPanel, false);
        button.gem = gem;
    }

    public void PickGem(System.Action<RoomGem> callback)
    {
        if (gems.Count <= 0)
        {
            callback(null);
            return;
        }

        pickGemCallback = callback;

        uIActions.Enable();
        playerActions.Disable();

        EventSystem.current.SetSelectedGameObject(gemButtonPanel.GetChild(0).gameObject);
    }

    public bool ChooseGem(RoomGem gem)
    {
        if (pickGemCallback == null)
        {
            Debug.LogError("Try to pick gem while no callback.");
            return false;
        }

        pickGemCallback(gem);
        pickGemCallback = null;

        gems.Remove(gem);

        playerActions.Enable();
        uIActions.Disable();

        return true;
    }
}
