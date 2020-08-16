using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startup : MonoBehaviour
{
    bool playing = false;
    bool clicked = false;
    public float speed = 0.5f;

    Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        target = new Vector3(0, 0, -10);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey) clicked = true;
        if (clicked && !playing)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, step);
        }
        if (transform.position.Equals(target)) playing = true;
    }
}
