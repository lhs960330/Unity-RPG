using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    // �̷������� ó�����ָ� ������ ��Ȳ������ ���¿� ���� �����Ǿ������� ������ �������Ͽ� ����
    // ��ó������� �ִ��� �Ⱦ��°� ����.
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

    //ContextMenu�� ���� �׽�Ʈ�� ���ְ� inspector���� ȣ���Ҽ� �ְ� ����
    [ContextMenu("Save")]
    public void SaveData()
    {
        /*Debug.Log(Application.persistentDataPath);
        // ���� ����(����)�Ҷ� �������� ������ ������ ������
        // Application.persistentDataPath
        // ������ ���� ������
        if (Directory.Exists($"{Application.dataPath}/Data") == false)
        {
            // ������ ������ �������
            Directory.CreateDirectory($"{Application.dataPath}/Data");
        }*/
        // �ؽ�Ʈ�� �������
        if (Directory.Exists(path) == false)
        {
            // ������ ������ �������
            Directory.CreateDirectory(path);
        }
        string filepath = Path.Combine(path, "Test.txt");
        // json�� ���¹� (true)�� �������� �������
        string json = JsonUtility.ToJson(gameData, true);
        File.WriteAllText(filepath, json);
    }
    [ContextMenu("Load")]
    public void LoadData()
    {
        string filpath = Path.Combine(path, "Test.txt");
        // ������ �ִ��� Ȯ��
        if (File.Exists(filpath))
        {
            // �ؽ�Ʈ�� �б�(�ؽ�Ʈ�� �������°� �ƴ϶� �б�)
            string json = File.ReadAllText(filpath);
            gameData = JsonUtility.FromJson<GameData>(json);
        }
        else
        {
            gameData = new GameData();
        }
    }
    // ������ ���������� �����Ƿ� ���⿡ ���������. ���̺� ������ �����ϴ°��� Application.persistentDataPath�� ����ؾ��Ѵ�.

    public bool ExistSaveData()
    {
        string filpath = Path.Combine(path, "Test.txt");
        return File.Exists(filpath);
    }
}

