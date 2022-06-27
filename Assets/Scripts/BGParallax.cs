using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGParallax : MonoBehaviour
{
    public float ParallaxRate = -3f;
    private Camera _cam;

    private void Start()
    {
        _cam = Camera.main;
    }

    private void Update()
    {
        transform.position = new Vector3(_cam.transform.position.x / ParallaxRate, 0f, 0f);
    }
}
