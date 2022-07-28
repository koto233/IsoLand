using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorManager : MonoBehaviour
{
    private Vector3 MouseWorldPos =>
        Camera
            .main
            .ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y,
                0));

    private bool Canclick;

    public RectTransform hand;

    private ItemName currentItem;

    private bool holdItem;

    private void OnEnable()
    {
        EventHandle.ItemSelect += OnItemSelect;
        EventHandle.ItemUsed += OnItemUsed;
    }

    private void OnDisable()
    {
        EventHandle.ItemSelect -= OnItemSelect;
        EventHandle.ItemUsed -= OnItemUsed;
    }

    private void OnItemSelect(ItemDetails itemDetails, bool ifSelect)
    {
        holdItem = ifSelect;
        if (ifSelect)
        {
            currentItem = itemDetails.itemName;
        }
        hand.gameObject.SetActive (holdItem);
    }

    private void Update()
    {
        Canclick = ObjectAtMousePos();

        if (hand.gameObject.activeInHierarchy)
        {
            hand.position = Input.mousePosition;
        }
        if (InteractWithUI())
        {
            return;
        }
        if (Canclick && Input.GetMouseButtonDown(0))
        {
            CilckAction(ObjectAtMousePos().gameObject);
        }
    }

    private void CilckAction(GameObject clickObject)
    {
        switch (clickObject.tag)
        {
            case "Teleport":
                var teleport = clickObject.GetComponent<Teleport>();
                teleport?.TeleportToScene();
                break;
            case "item":
                var item = clickObject.GetComponent<Item>();
                item?.ItemClicked();
                break;
            case "InterActive":
                var interactive = clickObject.GetComponent<Interactive>();
                if (holdItem)
                {
                    interactive?.checkItem(currentItem);
                }
                else
                {
                    interactive?.EmptyClick();
                }
                break;
        }
    }

    private Collider2D ObjectAtMousePos()
    {
        return Physics2D.OverlapPoint(MouseWorldPos);
    }

    private void OnItemUsed(ItemName itemName)
    {
        currentItem = ItemName.None;
        holdItem = false;
        hand.gameObject.SetActive(false);
    }

    private bool InteractWithUI()
    {
        if (
            EventSystem.current != null &&
            EventSystem.current.IsPointerOverGameObject()
        )
        {
            return true;
        }
        return false;
    }
}
