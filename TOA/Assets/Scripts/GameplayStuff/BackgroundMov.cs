using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMov : MonoBehaviour
{
    public float speed = 0.5f;
    private Renderer renderer;

    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        float offset = Time.time * speed;
        renderer.material.mainTextureOffset = new Vector2(-offset, 0);
    }
}
