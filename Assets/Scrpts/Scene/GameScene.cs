using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class GameScene : BaseScene
{
    [SerializeField] Monster monsterPrefab;
    [SerializeField] Transform spawnrPoint;
    [SerializeField] int count;
    public override IEnumerator LoadingRoutine()
    {
        // fake loding
        yield return new WaitForSecondsRealtime(1f);
        Manager.Scene.SetLoadingBarValue(0.6f);
        Debug.Log("GameScene Load");
        yield return new WaitForSecondsRealtime(0.1f); // 현실 타임으로 시간을 보낸다.
        Manager.Scene.SetLoadingBarValue(0.8f);
        Debug.Log("Player Spawn");
        yield return new WaitForSecondsRealtime(0.1f);
        Manager.Scene.SetLoadingBarValue(0.9f);
        Debug.Log("오브젝트 풀 준비");
        yield return new WaitForSecondsRealtime(0.1f);
        // 로딩중에 몬스터 스폰
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
        Debug.Log("게임씬 로딩 끝!");
    }
    public void ToTitleScene()
    {
        Manager.Scene.LoadScene("TitleScene");
    }
}
