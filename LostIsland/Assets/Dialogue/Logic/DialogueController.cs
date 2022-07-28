using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public DialoguData EmptyDialogue;

    public DialoguData FinishDialogue;

    private Stack<string> EmptyDialogueStack;

    private Stack<string> FinishDialogueStack;

    private bool isTaking;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        FillDialogueStack();
    }

    private void FillDialogueStack()
    {
        EmptyDialogueStack = new Stack<string>();
        FinishDialogueStack = new Stack<string>();
        for (int i = EmptyDialogue.dialogueList.Count - 1; i > -1; i--)
        {
            EmptyDialogueStack.Push(EmptyDialogue.dialogueList[i]);
        }

        for (int i = FinishDialogue.dialogueList.Count - 1; i > -1; i--)
        {
            FinishDialogueStack.Push(FinishDialogue.dialogueList[i]);
        }
    }

    public void showDialogueEmpty()
    {
        if (!isTaking)
        {
            StartCoroutine(DialoguRoutine(EmptyDialogueStack));
        }
    }

    public void showDialogueFinish()
    {
        if (!isTaking)
        {
            StartCoroutine(DialoguRoutine(FinishDialogueStack));
        }
    }

    private IEnumerator DialoguRoutine(Stack<string> data)
    {
        isTaking = true;
        if (data.Count > 0)
        {
            EventHandle.CallShowDialogueEvent (data.Pop());
            yield return null;
            isTaking = false;
            EventHandle.CallGameStateChange(GameState.Pause);
        }
        else
        {
            EventHandle.CallShowDialogueEvent(string.Empty);
            FillDialogueStack();
            isTaking = false;
            EventHandle.CallGameStateChange(GameState.Play);
        }
    }
}
