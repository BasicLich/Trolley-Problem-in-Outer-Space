using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Effects : MonoBehaviour
{
    public TMP_Animated animatedText;
    public GameObject[] effects;

    FadeOut fade;

    // Start is called before the first frame update
    void Start()
    {
        fade = GetComponentInChildren<FadeOut>();

        foreach (GameObject obj in effects) obj.SetActive(false);

        animatedText.onEmotionChange.AddListener((Emotion) => changeEffect(Emotion));
    }

    void changeEffect(Emotion emotion)
    {
        for (int i = 0; i < effects.Length; i++)
        {
            if ((int)emotion == i) effects[i].SetActive(true);
            else effects[i].SetActive(false);

            if (emotion == Emotion.end)
            {
                effects[(int)Emotion.silent].SetActive(true);
                fade.start();
            }
        }
    }
}
