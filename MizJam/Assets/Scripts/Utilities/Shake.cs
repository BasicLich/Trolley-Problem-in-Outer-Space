using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public GameObject dialogue;
    public float timeLength;
    public float amount;
    public float speed;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        StartCoroutine(start());
    }

    IEnumerator shake()
    {
        float passedTime = 0;
        
        while (true)
        {
            if (passedTime >= timeLength) yield break;

            dialogue.transform.position = new Vector3(Mathf.Sin(Time.time * speed) * amount, 0, 0);
            passedTime += Time.deltaTime;
            yield return new WaitForSeconds(0.01f);
        } 
    }

    IEnumerator start()
    {
        yield return StartCoroutine(shake());
        
        // Resets after shake
        dialogue.transform.position = new Vector3(0, 0, 0);
    }
}
