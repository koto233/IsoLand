using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    private Dictionary<ItemName, bool>
        itemAvailableDict = new Dictionary<ItemName, bool>();

    private Dictionary<string, bool>
        interactiveStateDict = new Dictionary<string, bool>();

    private void OnEnable()
    {
        EventHandle.BeforeSceneUnload += OnBeforeSceneUnload;
        EventHandle.AfterSceneloaded += OnAfterSceneloaded;
        EventHandle.UpdateUI += OnUpdateUI;
    }

    private void OnDisable()
    {
        EventHandle.BeforeSceneUnload -= OnBeforeSceneUnload;
        EventHandle.AfterSceneloaded -= OnAfterSceneloaded;
        EventHandle.UpdateUI -= OnUpdateUI;
    }

    private void OnBeforeSceneUnload()
    {
        foreach (var item in FindObjectsOfType<Item>())
        {
            if (!itemAvailableDict.ContainsKey(item.itemName))
            {
                itemAvailableDict.Add(item.itemName, true);
            }
        }

        foreach (var item in FindObjectsOfType<Interactive>())
        {
            if (interactiveStateDict.ContainsKey(item.name))
            {
                interactiveStateDict[item.name]=item.isDone;
            }
            else
            {
                interactiveStateDict.Add(item.name, item.isDone);
            }
        }
    }

    private void OnAfterSceneloaded()
    {
        foreach (var item in FindObjectsOfType<Item>())
        {
            if (!itemAvailableDict.ContainsKey(item.itemName))
            {
                itemAvailableDict.Add(item.itemName, true);
            }
            else
            {
                item.gameObject.SetActive(itemAvailableDict[item.itemName]);
            }
        }

        foreach (var item in FindObjectsOfType<Interactive>())
        {
            if (interactiveStateDict.ContainsKey(item.name))
            {
                item.isDone = interactiveStateDict[item.name];
            }
            else
            {
                interactiveStateDict.Add(item.name, item.isDone);
            }
        }
    }

    private void OnUpdateUI(ItemDetails itemDetails, int index)
    {
        if (itemDetails != null)
        {
            itemAvailableDict[itemDetails.itemName] = false;
        }
    }
}
