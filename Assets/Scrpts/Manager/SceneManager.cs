using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class SceneManager : MonoBehaviour
{
    [SerializeField] Image Fade;
    [SerializeField] Slider loadingBar;

    private BaseScene curScene;
    /// <summary>
    /// ���� ���� ã�����ֵ���������
    /// </summary>
    /// <returns></returns>
    public BaseScene GetCurScene()
    {
        // �������� ã��
        if (curScene == null)
            curScene = FindObjectOfType<BaseScene>();

        return curScene;
    }

    // �Ϲ�ȭ�ؼ� ������� ã���ִ� �޼���
    public T GetCurScene<T>() where T : BaseScene
    {
        if (curScene == null)
            curScene = FindObjectOfType<BaseScene>();

        return curScene as T;
    }


    public void LoadScene(string sceneName)
    {

        StartCoroutine(LoadingRoutine(sceneName));

        // ����ϸ� �ε��߿� �����־� �ε������� �ƴ��� Ȯ���� ��ƴ�.
        // UnitySceneManager.LoadScene(sceneName);
    }

    IEnumerator LoadingRoutine(string sceneName)
    {
        // �ε��ɼ��� �����Ǵ� ȿ��
        float time = 0f;
        while (time < 0.5f)
        {
            time += Time.unscaledDeltaTime; // TimeScale�� ������� �ð��� ������
            Fade.color = new Color(0, 0, 0, time * 2);
            yield return null;
        }

        Time.timeScale = 0f;
        loadingBar.gameObject.SetActive(true);
        // ��׶���� �ε����� ���ְ� �ε��� ���ϸ� GameScene���� �Ѿ�����ش�.
        AsyncOperation oper = UnitySceneManager.LoadSceneAsync(sceneName);
        // progress = �ε��Ǵ� �ۼ�Ʈ�� �˼��ִ�.
        // isDone = bool������ �ε��� ������ �ȳ������� üũ����
        // oper.allowSceneActivation �ε��� �ٵǰ� ���� ���Ҷ� ��ȯ�����ش�.
        // oper.allowSceneActivation = true;
        //while (oper.isDone== false) ��� allowSceneActivation�� false���� ��� false�� ���Եȴ�.
        while (oper.isDone == false)
        {
            loadingBar.value = Mathf.Lerp(0f, 0.5f, oper.progress);
            yield return null;
        }
        // Space�� ������ GameScene���� �����ϱ�
        /* yield return new WaitUntil(() => { return Input.GetKeyDown(KeyCode.Space); });*/
        // oper.allowSceneActivation = true;
        // yield return new WaitForSeconds(0.1f);

        BaseScene curScene = GetCurScene();
        // ���� �ڷ�ƾ �����ϴ� ���� �ڷ�ƾ �����ϴ� �ٽ� ���ƿ�
        yield return curScene.LoadingRoutine();

        // �� �������� ���� ����ɼ� �ְ� ����
        Time.timeScale = 1f;
        loadingBar.value = 1f;
        loadingBar.gameObject.SetActive(false);
        // �������� �ٽ� ������� ������
        time = 0.5f;
        while (time > 0f)
        {
            time -= Time.deltaTime;
            Fade.color = new Color(0, 0, 0, time * 2);
            yield return null;
        }

    }
    public void SetLoadingBarValue(float value)
    {
        loadingBar.value = value;
    }

}