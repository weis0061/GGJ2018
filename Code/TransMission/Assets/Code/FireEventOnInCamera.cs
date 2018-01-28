using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEventOnInCamera : MonoBehaviour {
    public MonoBehaviour Trigger;
    ITrigger trigger;

    void Start()
    {
        trigger = Trigger as ITrigger;
    }
    void Update()
    {
        Vector2 cameraPoint = Camera.main.WorldToViewportPoint(transform.position).xy();
        if (Mathf.Abs(cameraPoint.x) < 1f && Mathf.Abs(cameraPoint.y) < 1f)
        {
            trigger.Trigger();
            enabled = false;
        }
    }
}
