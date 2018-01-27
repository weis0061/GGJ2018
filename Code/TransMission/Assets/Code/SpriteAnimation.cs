using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteAnimation : MonoBehaviour, ITrigger
{
    public bool repeat = false;
    public float animSpeed = 1f;
    public Sprite[] sprites;

    float timeToNextFrame = 0f;
    SpriteRenderer rend;
    uint currentFrame;
    // Use this for initialization
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        timeToNextFrame = 1 / animSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeToNextFrame -= Time.deltaTime;
        if (timeToNextFrame <= 0)
        {
            currentFrame++;
            timeToNextFrame = 1 / animSpeed;
        }
        if (currentFrame >= sprites.Length)

            currentFrame = 0;
        if (!repeat)
        {
            rend.enabled = false;
            enabled = false;
        }
        rend.sprite = sprites[currentFrame];
    }

    public void Trigger()
    {
        rend.enabled = true;
        enabled = true;
    }
}
