
// ����ȭ�� �����ϰ����ִ� Ŭ����
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

    // �⺻ ���ð�
    public GameData()
    {
        name = "�÷��̾�";
        level = 1;
        gold = 0;
        exp = 0;
        skilPoint = 3;

        sceneSaved = new bool[32];
        gmaeSceneData = new GameSceneData();
    }
}

