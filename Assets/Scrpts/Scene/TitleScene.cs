using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TitleScene : BaseScene
{

    public void GameSceneLoad()
    {
        Manager.Scene.LoadScene("GameScene");
    }

    // �ε������� ���� ���� �ƹ��͵� �Ƚ�Ű���
    public override IEnumerator LoadingRoutine()
    {
        yield return null;
           
    }
}
