using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Fade : MonoBehaviour
{
    public float speed;
    private Tilemap tilemap;

    private void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }

    IEnumerator fade()
    {
        while (true)
        {
            float alpha = tilemap.color.a;
            alpha -= speed;
            tilemap.color = new Color(tilemap.color.r, tilemap.color.g, tilemap.color.b, alpha);
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void start()
    {
        StartCoroutine(fade());
    } 
}
