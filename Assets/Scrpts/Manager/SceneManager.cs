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
    /// 현재 씬을 찾을수있도록해주자
    /// </summary>
    /// <returns></returns>
    public BaseScene GetCurScene()
    {
        // 없을때만 찾자
        if (curScene == null)
            curScene = FindObjectOfType<BaseScene>();

        return curScene;
    }

    // 일반화해서 현재씬을 찾아주는 메서드
    public T GetCurScene<T>() where T : BaseScene
    {
        if (curScene == null)
            curScene = FindObjectOfType<BaseScene>();

        return curScene as T;
    }


    public void LoadScene(string sceneName)
    {

        StartCoroutine(LoadingRoutine(sceneName));

        // 얘로하면 로딩중에 멈춰있어 로딩중인지 아닌지 확인이 어렵다.
        // UnitySceneManager.LoadScene(sceneName);
    }

    IEnumerator LoadingRoutine(string sceneName)
    {
        // 로딩될수록 암전되는 효과
        float time = 0f;
        while (time < 0.5f)
        {
            time += Time.unscaledDeltaTime; // TimeScale과 관계없이 시간이 지나감
            Fade.color = new Color(0, 0, 0, time * 2);
            yield return null;
        }

        Time.timeScale = 0f;
        loadingBar.gameObject.SetActive(true);
        // 백그라운드로 로딩씬을 해주고 로딩을 다하면 GameScene으로 넘어가게해준다.
        AsyncOperation oper = UnitySceneManager.LoadSceneAsync(sceneName);
        // progress = 로딩되는 퍼센트를 알수있다.
        // isDone = bool형식의 로딩이 끝났는 안끝났는지 체크해줌
        // oper.allowSceneActivation 로딩이 다되고 내가 원할때 전환시켜준다.
        // oper.allowSceneActivation = true;
        //while (oper.isDone== false) 얘는 allowSceneActivation가 false여서 계속 false로 가게된다.
        while (oper.isDone == false)
        {
            loadingBar.value = Mathf.Lerp(0f, 0.5f, oper.progress);
            yield return null;
        }
        // Space를 누르면 GameScene으로 가게하기
        /* yield return new WaitUntil(() => { return Input.GetKeyDown(KeyCode.Space); });*/
        // oper.allowSceneActivation = true;
        // yield return new WaitForSeconds(0.1f);

        BaseScene curScene = GetCurScene();
        // 여기 코루틴 진행하다 저기 코루틴 진행하다 다시 돌아옴
        yield return curScene.LoadingRoutine();

        // 다 끝났으면 게임 진행될수 있게 만듬
        Time.timeScale = 1f;
        loadingBar.value = 1f;
        loadingBar.gameObject.SetActive(false);
        // 암전에서 다시 원래대로 보내기
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