
// 직렬화가 가능하게해주는 클래스
using System;

[Serializable]
public class GameData
{
    public string name;

    public int level;
    public int gold;
    public int exp;
    public int skilPoint;

    public bool[] sceneSaved = new bool[32];
    public GameSceneData gmaeSceneData;

    // 기본 셋팅값
    public GameData()
    {
        name = "플레이어";
        level = 1;
        gold = 0;
        exp = 0;
        skilPoint = 3;

        sceneSaved = new bool[32];
        gmaeSceneData = new GameSceneData();
    }
}

