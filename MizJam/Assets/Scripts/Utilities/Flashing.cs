using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Flashing : MonoBehaviour
{
    public int maxAlpha;
    private float alpha;
    public float speed;
    int direction = -1;

    TextMeshPro text;
    // Start is called before the first frame update
    void Start()
    {
        alpha = maxAlpha / 255;
        text = GetComponent<TextMeshPro>();
        StartCoroutine(flash());
    }


    IEnumerator flash()
    {
        while (true)
        {
            Color textColor = text.color;

            if (textColor.a <= 0.1) direction = 1;
            else if (textColor.a >= 0.9) direction = -1;

            float newA = textColor.a + speed * direction;
            if (newA < 0) newA = 0;
            if (newA > 1) newA = 1;

            text.color = new Color(textColor.r, textColor.g, textColor.b, newA);

            yield return new WaitForSeconds(0.01f);
        }
    }
}
