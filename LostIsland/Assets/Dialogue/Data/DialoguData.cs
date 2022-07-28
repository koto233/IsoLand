using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[
    CreateAssetMenu(
        fileName = "DialogueData",
        menuName = "Dialogue/DialogueData")
]

public class DialoguData : ScriptableObject
{
   public List<string> dialogueList;
}
