using System;
using UnityEngine;

public static class EventHandle
{
    public static event Action<ItemDetails, int> UpdateUI;

    public static void CallUpdateUI(ItemDetails itemDetails, int index)
    {
        UpdateUI?.Invoke(itemDetails, index);
    }

    public static event Action BeforeSceneUnload;

    public static void CallBeforeSceneUnload()
    {
        BeforeSceneUnload?.Invoke();
    }

    public static event Action AfterSceneloaded;

    public static void CallAfterSceneloaded()
    {
        AfterSceneloaded?.Invoke();
    }

    public static event Action<ItemDetails, bool> ItemSelect;

    public static void CallItemSelect(ItemDetails itemDetails, bool ifSelect)
    {
        ItemSelect?.Invoke(itemDetails, ifSelect);
    }

    public static event Action<ItemName> ItemUsed;

    public static void CallItemUsed(ItemName itemName)
    {
        ItemUsed?.Invoke(itemName);
    }

    public static event Action<int> ChangeItem;

    public static void CallChangeItem(int index)
    {
        ChangeItem?.Invoke(index);
    }

    public static event Action<string> ShowDialogueEvent;

    public static void CallShowDialogueEvent(string dialogue)
    {
        ShowDialogueEvent?.Invoke(dialogue);
    }

    public static event Action<GameState> GameStateChange;

    public static void CallGameStateChange(GameState gameState)
    {
        GameStateChange?.Invoke(gameState);
    }

    public static event Action CheckGameState;

    public static void CallCheckGameState()
    {
        CheckGameState?.Invoke();
    }

    public static event Action<string> MiniGamePass;

    public static void CallMiniGamePass(string mgameName)
    {
        MiniGamePass?.Invoke(mgameName);
    }
}
