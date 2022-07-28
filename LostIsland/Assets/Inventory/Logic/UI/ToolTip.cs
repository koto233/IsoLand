using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour
{
public Text itemNameText;
public void UpdateItemName(ItemName itemName){
itemNameText.text=itemName switch{
    ItemName.Key=>"信箱钥匙",
    ItemName.Ticket=>"船票",
    _=>""
};
}
}
