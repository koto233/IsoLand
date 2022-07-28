using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[
    CreateAssetMenu(
        fileName = "H2AData",
        menuName = "Mini Game Data/H2AData",
        order = 0)
]
public class H2AData : ScriptableObject
{
    [SceneName]
    public string mgameName;

    [Header("球图片与名字")]
    public List<BallDetails> ballDataList;

    [Header("游戏逻辑顺序")]
    public List<Connection> lineConnection;

    public List<BallName> startBallOrder;

    public BallDetails GetBallDetails(BallName ballName)
    {
        return ballDataList.Find(b => b.ballName == ballName);
    }
}

[System.Serializable]
public class BallDetails
{
    public BallName ballName;

    public Sprite wrongSprite;

    public Sprite rightSprite;
}

[System.Serializable]
public class Connection
{
    public int from;

    public int to;
}
