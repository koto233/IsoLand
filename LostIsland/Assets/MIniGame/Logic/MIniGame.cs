using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MIniGame : MonoBehaviour
{
    [SceneName]
    public string mgameName;

    public UnityEvent mGameFinish;

    public bool isPass;

    public void UpdateMgameState()
    {
        if (isPass)
        {
            Debug.Log("pass");
            mGameFinish?.Invoke();
            this.gameObject.SetActive(false);
        }
    }
}
