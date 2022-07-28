using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private Dictionary<string, bool>
        miniGameSateDic = new Dictionary<string, bool>();

    private void OnEnable()
    {
        EventHandle.AfterSceneloaded += OnAfterSceneloaded;
        EventHandle.MiniGamePass += OnMiniGamePass;
    }

    private void OnDisable()
    {
        EventHandle.AfterSceneloaded -= OnAfterSceneloaded;
        EventHandle.MiniGamePass -= OnMiniGamePass;
    }

    private void OnAfterSceneloaded()
    {
        foreach (var mgame in FindObjectsOfType<MIniGame>())
        {
            if (miniGameSateDic.TryGetValue(mgame.mgameName, out bool isPass))
            {
                Debug.Log(miniGameSateDic[mgame.mgameName]);
                mgame.isPass = isPass;
                mgame.UpdateMgameState();
            }
        }
    }

    void Start()
    {
        SceneManager.LoadScene("Menu",LoadSceneMode.Additive);
        EventHandle.CallGameStateChange(GameState.Play);
    }

    private void OnMiniGamePass(string mgameName)
    {
        miniGameSateDic[mgameName] = true;
    }
}
