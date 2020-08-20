using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public FadeOut fadeo;
    public FadeIn fadei;

    public Interface inter;

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
        inter.gameOver = true;
        yield return StartCoroutine(fadei.fade());
        yield return new WaitForSeconds(waitTime);
        inter.gameOver = false;
        yield return StartCoroutine(fadeo.fade());
    }
}
