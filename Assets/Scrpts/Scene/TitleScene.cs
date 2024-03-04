using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TitleScene : BaseScene
{
    [SerializeField] Button continueButton;
    private void Start()
    {
        bool exist = Manager.Data.ExistSaveData();
        continueButton.interactable = exist;
    }
    public void NewGame()
    {
        Manager.Data.NewData();
        Manager.Scene.LoadScene("GameScene");
    }
    public void ContinueGame()
    {
        Manager.Data.LoadData();
        Manager.Scene.LoadScene("GameScene");
    }

    // 로딩과정이 없는 씬은 아무것도 안시키면됨
    public override IEnumerator LoadingRoutine()
    {
        yield return null;
    }
}
