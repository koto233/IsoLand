using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Button

            rightb,
            leftb;

    public SlotUI su;

    public int currentIndex;

    private void OnEnable()
    {
        EventHandle.UpdateUI += OnUpdateUI;
    }

    private void OnDisable()
    {
        EventHandle.UpdateUI -= OnUpdateUI;
    }

    private void OnUpdateUI(ItemDetails itemDetails, int index)
    {
        if (itemDetails == null)
        {
            su.SetEmpty();
            currentIndex = -1;

            leftb.interactable = false;
            rightb.interactable = false;
        }
        else
        {
            currentIndex = index;
            su.SetItem (itemDetails);
            if (index > 0)
            {
                leftb.interactable = true;
                rightb.interactable = true;
            }
        }
    }

    public void SwitchItem(int changeIndex)
    {
        var index = currentIndex + changeIndex;

        EventHandle.CallChangeItem (index);
    }
}
