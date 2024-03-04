using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class GameScene : BaseScene
{
    [SerializeField] Transform player;
    [SerializeField] CharacterController characterController;
    /*[SerializeField] Monster monsterPrefab;
    [SerializeField] Transform spawnrPoint;
    [SerializeField] int count;*/
    public override IEnumerator LoadingRoutine()
    {
        /*// fake loding
        yield return new WaitForSecondsRealtime(1f);
        Manager.Scene.SetLoadingBarValue(0.6f);
        Debug.Log("GameScene Load");
        yield return new WaitForSecondsRealtime(0.1f); // ���� Ÿ������ �ð��� ������.
        Manager.Scene.SetLoadingBarValue(0.8f);
        Debug.Log("Player Spawn");
        yield return new WaitForSecondsRealtime(0.1f);
        Manager.Scene.SetLoadingBarValue(0.9f);
        Debug.Log("������Ʈ Ǯ �غ�");
        yield return new WaitForSecondsRealtime(0.1f);
        // �ε��߿� ���� ����
        for (int i = 0; i < count; i++)
        {
            Vector2 randomOffset = Random.insideUnitCircle * 10;
            Vector3 spawnPos = spawnrPoint.position + new Vector3(randomOffset.x, 0, randomOffset.y);
            // Quaternion spawnRot = Random.rotation;
            Quaternion spawnRot = Quaternion.Euler(0, Random.Range(0, 360), 0);
            Monster monster = Instantiate(monsterPrefab, spawnPos, spawnRot);

            yield return new WaitForSecondsRealtime(0.2f);
        }
        Manager.Scene.SetLoadingBarValue(1f);
        yield return new WaitForSecondsRealtime(0.1f);
        Debug.Log("���Ӿ� �ε� ��!");*/
        yield return null;
    }
    public void ToTitleScene()
    {
        Manager.Data.gameData.sceneSaved[Manager.Scene.GetCurSceneIndex()] = true;
        Manager.Scene.LoadScene("TitleScene");
    }
    public override void SceneSave()
    {
        Manager.Data.gameData.gmaeSceneData.playerPos = player.position;
        Manager.Data.SaveData();
    }
    public override void SceneLoad()
    {
        if (Manager.Data.gameData.sceneSaved[Manager.Scene.GetCurSceneIndex()] == false)
            return;
        Manager.Data.LoadData();
        characterController.enabled = false;
        player.position = Manager.Data.gameData.gmaeSceneData.playerPos;
        characterController.enabled = true;
    }

}
