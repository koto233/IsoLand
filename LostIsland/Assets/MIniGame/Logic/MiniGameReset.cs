using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameReset : Interactive
{
   private Transform gearTransform;
   private void Awake() {
    gearTransform=transform.GetChild(0);
   }

   public override void EmptyClick(){
    MiniGameController.Instance.ResetMinniGame();
   }
}
