using System.Collections;
using UnityEngine;

public abstract class BaseScene : MonoBehaviour
{
    // ������ �ε��ؾߵǴ� ������ �� �����ϰԸ������
   public abstract IEnumerator LoadingRoutine();
}
