using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    public ItemDataList itemData;

    [SerializeField]
    private List<ItemName> itemList = new List<ItemName>();

    private void OnEnable()
    {
        EventHandle.ItemUsed += OnItemUsed;
        EventHandle.AfterSceneloaded += OnAfterSceneloaded;

        EventHandle.ChangeItem += OnChangeItem;
    }

    private void OnDisable()
    {
        EventHandle.ItemUsed -= OnItemUsed;
        EventHandle.ChangeItem -= OnChangeItem;
        EventHandle.AfterSceneloaded -= OnAfterSceneloaded;
    }

    private void OnAfterSceneloaded()
    {
        if (itemList.Count == 0)
        {
            EventHandle.CallUpdateUI(null, -1);
        }
        else
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                EventHandle
                    .CallUpdateUI(itemData.GetItemDetails(itemList[i]), i);
            }
        }
    }

    private void OnItemUsed(ItemName itemName)
    {
        var index = GetItemIndex(itemName);
        itemList.RemoveAt (index);
        if (itemList.Count == 0)
        {
            EventHandle.CallUpdateUI(null, -1);
        }
    }

    private void OnChangeItem(int index)
    {
        if (index < 0)
        {
            index = itemList.Count - 1;
        }
        else if (index > itemList.Count - 1)
        {
            index = 0;
        }

        ItemDetails item = itemData.GetItemDetails(itemList[index]);
        EventHandle.CallUpdateUI (item, index);
    }

    public void AddItem(ItemName itemName)
    {
        if (!itemList.Contains(itemName))
        {
            itemList.Add (itemName);

            EventHandle
                .CallUpdateUI(itemData.GetItemDetails(itemName),
                itemList.Count - 1);
        }
    }

    private int GetItemIndex(ItemName itemName)
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i] == itemName)
            {
                return i;
            }
        }
        return -1;
    }
}
