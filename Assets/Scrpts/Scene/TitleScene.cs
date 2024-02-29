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

    // 로딩과정이 없는 씬은 아무것도 안시키면됨
    public override IEnumerator LoadingRoutine()
    {
        yield return null;
           
    }
}
