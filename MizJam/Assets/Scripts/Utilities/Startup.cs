using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Startup : MonoBehaviour
{
    bool playing = false;
    bool clicked = false;
    public float speed = 0.5f;

    Vector3 target;

    Tilemap tilemap;
    int fadeDir = 1;
    float fadeSpeed = 1f;
    float alpha = 0f;

    // Start is called before the first frame update
    void Start()
    {
        target = new Vector3(37, -20, -10);
        tilemap = GetComponentInChildren<Tilemap>();
        Color temp = tilemap.color; temp.a = alpha;
        tilemap.color = temp;
    }

    void fadeAlpha()
    {
        alpha += fadeDir * fadeSpeed * Time.deltaTime; 
        if (alpha > 1f) alpha = 1f;
        if (alpha < 0) this.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) clicked = true;
        if (clicked && !playing)
        {
            float step = speed * Time.deltaTime;
            //transform.position = Vector3.MoveTowards(transform.position, target, step);
            fadeAlpha();
            Color temp = tilemap.color; temp.a = alpha; tilemap.color = temp;
        }
        if (alpha == 1)
        {
            transform.position = new Vector3(0, 0, -10);
            playing = true;
        }

        if (playing)
        {
            fadeDir = -1;
            fadeAlpha();
            Color temp = tilemap.color; temp.a = alpha; tilemap.color = temp;
        }
    }
}
