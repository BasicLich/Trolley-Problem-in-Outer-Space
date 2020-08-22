using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullStop : MonoBehaviour
{
    public FadeOut fadeo;
    public FadeIn fadei;

    public float waitTime;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        StartCoroutine(fade());
    }


    IEnumerator fade()
    {
        yield return StartCoroutine(fadei.fade());
        yield return new WaitForSeconds(waitTime);
        yield return StartCoroutine(fadeo.fade());
    }
   
}
