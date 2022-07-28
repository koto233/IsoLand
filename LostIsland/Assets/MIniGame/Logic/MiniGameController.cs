using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MiniGameController : Singleton<MiniGameController>
{
    public UnityEvent OnFinish;

    public H2AData gameData;

    public GameObject lineP;

    public Transform[] holderTransform;

    public LineRenderer linePrafb;

    public Ball ballPrafb;

    private void Start()
    {
        DrawLine();
        CreateBall();
    }

    private void OnEnable()
    {
        EventHandle.CheckGameState += OnCheckGameState;
    }

    private void OnDisable()
    {
        EventHandle.CheckGameState -= OnCheckGameState;
    }

    private void OnCheckGameState()
    {
        foreach (var ball in FindObjectsOfType<Ball>())
        {
            if (!ball.isMatch)
            {
                return;
            }
            else
            {
                foreach (var holder in holderTransform)
                {
                    holder.GetComponent<Collider2D>().enabled = false;
                }
                Debug.Log("pass");
                EventHandle.CallMiniGamePass(gameData.mgameName);
                OnFinish?.Invoke();
            }
        }
    }

    public void DrawLine()
    {
        foreach (var conn in gameData.lineConnection)
        {
            var line = Instantiate(linePrafb, lineP.transform);
            line.SetPosition(0, holderTransform[conn.from].position);
            line.SetPosition(1, holderTransform[conn.to].position);

            holderTransform[conn.from]
                .GetComponent<Holder>()
                .LinkHolders
                .Add(holderTransform[conn.to].GetComponent<Holder>());
            holderTransform[conn.to]
                .GetComponent<Holder>()
                .LinkHolders
                .Add(holderTransform[conn.from].GetComponent<Holder>());
        }
    }

    public void CreateBall()
    {
        for (int i = 0; i < gameData.startBallOrder.Count; i++)
        {
            if (gameData.startBallOrder[i] == BallName.None)
            {
                holderTransform[i].GetComponent<Holder>().isEmpty = true;
                continue;
            }

            Ball ball = Instantiate(ballPrafb, holderTransform[i]);

            holderTransform[i].GetComponent<Holder>().CheckBall(ball);
            holderTransform[i].GetComponent<Holder>().isEmpty = false;
            ball.SetupBall(gameData.GetBallDetails(gameData.startBallOrder[i]));
        }
    }

    public void ResetMinniGame()
    {
        foreach (var holder in holderTransform)
        {
            if (holder.childCount > 0)
            {
                Destroy(holder.GetChild(0).gameObject);
            }
        }
        CreateBall();
    }
}
