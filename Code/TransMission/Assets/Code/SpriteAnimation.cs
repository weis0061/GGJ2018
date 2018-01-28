using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteAnimation : MonoBehaviour, ITrigger
{
    public bool repeat = false;
    public bool DisableRendererOnEnd = true;
    public float animSpeed = 1f;
    public uint startFrame = 0;
    public Sprite[] sprites;

    float timeToNextFrame = 0f;
    SpriteRenderer rend;
    uint currentFrame;
    // Use this for initialization
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        timeToNextFrame = 1 / animSpeed;
        currentFrame = startFrame;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameState.isGameActive) return;
        if (!enabled) return;
        timeToNextFrame -= Time.deltaTime;
        if (timeToNextFrame <= 0)
        {
            currentFrame++;
            if (currentFrame >= sprites.Length)
                currentFrame = 0;
            if (!repeat && currentFrame == startFrame)
            {
                if(DisableRendererOnEnd)
                rend.enabled = false;
                enabled = false;
            }
            timeToNextFrame = 1 / animSpeed;
        }

        rend.sprite = sprites[currentFrame];
    }

    public void Trigger()
    {
        rend.enabled = true;
        enabled = true;
    }
}
