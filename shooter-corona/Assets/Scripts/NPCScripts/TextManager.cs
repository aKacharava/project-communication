using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    float delay = 2.5f;
    bool isExecuting = false;

    void Update()
    {
        StartCoroutine(DelayHideExecution(delay));
    }

    IEnumerator DelayHideExecution(float time)
    {
        if (isExecuting == true)
            yield break;

        isExecuting = true;

        yield return new WaitForSeconds(time);

        this.gameObject.SetActive(false);

        isExecuting = false;
    }
}
