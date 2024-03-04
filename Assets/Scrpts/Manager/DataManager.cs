using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    // 이런식으로 처리해주면 에디터 상황에서는 에셋에 저장 베포되었을때는 베포한 저장파일에 생성
    // 전처리기능을 최대한 안쓰는게 좋다.
#if UNITY_EDITOR
    private string path => $"{Application.dataPath}/Data";
#else
     private string path => $"{Application.persistentDataPath}/Data";
#endif

    public GameData gameData;

    public void NewData()
    {
        gameData = new GameData();
        SaveData();
    }

    //ContextMenu은 내가 테스트할 수있게 inspector에서 호출할수 있게 해줌
    [ContextMenu("Save")]
    public void SaveData()
    {
        /*Debug.Log(Application.persistentDataPath);
        // 실제 베포(빌드)할때 저장파일 생성할 곳으로 보내줌
        // Application.persistentDataPath
        // 저장할 폴더 없을때
        if (Directory.Exists($"{Application.dataPath}/Data") == false)
        {
            // 저장할 폴더를 만들어줌
            Directory.CreateDirectory($"{Application.dataPath}/Data");
        }*/
        // 텍스트로 만들어줌
        if (Directory.Exists(path) == false)
        {
            // 저장할 폴더를 만들어줌
            Directory.CreateDirectory(path);
        }
        string filepath = Path.Combine(path, "Test.txt");
        // json를 쓰는법 (true)는 보기좋게 만들어줌
        string json = JsonUtility.ToJson(gameData, true);
        File.WriteAllText(filepath, json);
    }
    [ContextMenu("Load")]
    public void LoadData()
    {
        string filpath = Path.Combine(path, "Test.txt");
        // 파일이 있는지 확인
        if (File.Exists(filpath))
        {
            // 텍스트로 읽기(텍스트를 가져오는게 아니라 읽기)
            string json = File.ReadAllText(filpath);
            gameData = JsonUtility.FromJson<GameData>(json);
        }
        else
        {
            gameData = new GameData();
        }
    }
    // 실제론 에셋폴더가 없으므로 여기에 만들수없다. 세이브 파일을 저장하는곳은 Application.persistentDataPath를 사용해야한다.

    public bool ExistSaveData()
    {
        string filpath = Path.Combine(path, "Test.txt");
        return File.Exists(filpath);
    }
}

