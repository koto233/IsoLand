using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (DialogueController))]
public class ChacterH2 : Interactive
{
    private DialogueController dialogueController;

    private void Awake()
    {
        dialogueController = GetComponent<DialogueController>();
    }

    protected override void OnClickedAction()
    {
        dialogueController.showDialogueFinish();
    }

    public override void EmptyClick()
    {
        if (isDone)
        {
            dialogueController.showDialogueFinish();
        }
        else
        {
            dialogueController.showDialogueEmpty();
        }
    }
}
