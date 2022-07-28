using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{
    public ItemName requireItem;

    public bool isDone;

    public void checkItem(ItemName itemName)
    {
        if (itemName == requireItem && !isDone)
        {
            isDone = true;
            OnClickedAction();
            EventHandle.CallItemUsed(itemName);
        }
    }

    protected virtual void OnClickedAction(){

    }

    public virtual void EmptyClick(){
        Debug.Log("空点");
    }
}
