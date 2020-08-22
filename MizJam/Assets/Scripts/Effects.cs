using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Effects : MonoBehaviour
{
    public TMP_Animated animatedText;
    public GameObject[] effects;

    bool emergencyOn = false;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject obj in effects) obj.SetActive(false);

        animatedText.onEmotionChange.AddListener((Emotion) => changeEffect(Emotion));
    }

    void changeEffect(Emotion emotion)
    {
        if ((int)emotion >= effects.Length) return;

        if (emotion == Emotion.end)
        {
            effects[(int)emotion].SetActive(true);
            return;
        }

        for (int i = 0; i < effects.Length; i++)
        {
            if (emergencyOn && i == (int)Emotion.danger) continue;

            if ((int)emotion == i) effects[i].SetActive(true);
            else effects[i].SetActive(false);

            
        }

        if (emotion == Emotion.danger) emergencyOn = true;
    }
}
