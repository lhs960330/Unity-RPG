using System.Collections;
using UnityEngine;

public abstract class BaseScene : MonoBehaviour
{
    // 씬에서 로딩해야되는 과정을 꼭 구현하게만들어줌
   public abstract IEnumerator LoadingRoutine();
}
