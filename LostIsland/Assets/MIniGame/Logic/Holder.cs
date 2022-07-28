using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holder : Interactive
{
    public BallName MatchBall;

    public Ball CurrentBall;

    public HashSet<Holder> LinkHolders = new HashSet<Holder>();

    public bool isEmpty;

    public void CheckBall(Ball ball)
    {
        CurrentBall = ball;
        if (ball.ballDetails.ballName == MatchBall)
        {
            CurrentBall.isMatch = true;
            CurrentBall.SetRight();
        }
        else
        {
            CurrentBall.isMatch = false;
            CurrentBall.SetWrong();
        }
    }

    public override void EmptyClick()
    {
        foreach (var holder in LinkHolders)
        {
            if (holder.isEmpty)
            {
                CurrentBall.transform.position = holder.transform.position;
                CurrentBall.transform.SetParent(holder.transform);
                holder.CheckBall (CurrentBall);
                this.CurrentBall = null;
                this.isEmpty = true;
                holder.isEmpty = false;

                EventHandle.CallCheckGameState();
            }
        }
    }
}
