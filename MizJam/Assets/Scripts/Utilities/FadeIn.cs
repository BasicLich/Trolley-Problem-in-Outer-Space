using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FadeIn : MonoBehaviour
{
    public float speed;
    public Tilemap tilemap;
    private void Start()
    {
        //tilemap = GetComponent<Tilemap>();
    }

    public IEnumerator fade()
    {
        tilemap.color = new Color(tilemap.color.r, tilemap.color.g, tilemap.color.b, 0);
        while (true)
        {
            float alpha = tilemap.color.a;

            if (alpha >= 0.99) yield break;

            alpha += speed;
            tilemap.color = new Color(tilemap.color.r, tilemap.color.g, tilemap.color.b, alpha);
            yield return new WaitForSeconds(0.01f);
        }
    }

}
