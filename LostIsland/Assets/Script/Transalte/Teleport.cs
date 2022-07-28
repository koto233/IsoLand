using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SceneName]
    public string sceneFrom;

    [SceneName]
    public string sceneTo;



    public void TeleportToScene(){
      TranslationManager.Instance.Transition(sceneFrom,sceneTo);
    }
}
