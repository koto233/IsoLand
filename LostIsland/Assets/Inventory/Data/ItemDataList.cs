using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[
    CreateAssetMenu(
        fileName = "ItemDataList",
        menuName = "Inventory/ItemDataList",
        order = 0)
]
public class ItemDataList : ScriptableObject
{
    public List<ItemDetails> itemDetailsLi;

    public  ItemDetails GetItemDetails(ItemName itemName)
    {
        return itemDetailsLi.Find(i => i.itemName == itemName);
    }
}

[System.Serializable]
public class ItemDetails
{
    public ItemName itemName;

    public Sprite itemSprite;
}
