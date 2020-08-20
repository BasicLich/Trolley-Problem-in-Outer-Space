using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Blinking : MonoBehaviour
{
    [SerializeField]
    float Cooldown = 0.5f;
    Tilemap tilemap;
    [SerializeField]
    Color mainColor;
    [SerializeField]
    Color alternateColor;

    // Start is called before the first frame update
    void Start()
    {
        tilemap = GetComponent<Tilemap>();

        StopAllCoroutines();
        StartCoroutine("Blink");
    }

    IEnumerator Blink()
    {
        while (true)
        {
            switch (tilemap.color.r)
            {
                case 1f:
                    tilemap.color = mainColor;
                    yield return new WaitForSeconds(Cooldown);
                    break;
                default:
                    tilemap.color = alternateColor;
                    yield return new WaitForSeconds(Cooldown);
                    break;
            }
        }
    }

}
