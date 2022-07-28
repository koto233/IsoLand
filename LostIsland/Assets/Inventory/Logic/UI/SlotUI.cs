using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class
SlotUI
: MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Image ItemImage;

    public ToolTip toolTip;

    private ItemDetails currentItem;

    private bool ifSelect;

    public void SetEmpty()
    {
        this.gameObject.SetActive(false);
        ifSelect = false;
    }

    public void SetItem(ItemDetails itemDetails)
    {
        currentItem = itemDetails;
        this.gameObject.SetActive(true);

        ItemImage.sprite = itemDetails.itemSprite;

        ItemImage.SetNativeSize();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ifSelect = !ifSelect;
        EventHandle.CallItemSelect (currentItem, ifSelect);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (this.gameObject.activeInHierarchy)
        {
            toolTip.gameObject.SetActive(true);
            toolTip.UpdateItemName(currentItem.itemName);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        toolTip.gameObject.SetActive(false);
    }
}
