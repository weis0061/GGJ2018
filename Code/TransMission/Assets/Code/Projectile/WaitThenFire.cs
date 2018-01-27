using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitThenFire : MonoBehaviour, ITrigger {
    public float WaitTime = 1f;
    public bool repeat = true;
    public Behaviour TriggerEvent;
    ITrigger triggerEvent;
    float timeLeft = 0f;

	// Use this for initialization
	void Start () {
        timeLeft = WaitTime;
        if (TriggerEvent)
        {
            triggerEvent = TriggerEvent as ITrigger;
            if (triggerEvent == null) Debug.LogException(new Exception("A trigger wasn't correctly assigned to the object: " + gameObject.name));
        }
	}
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            if(repeat)
                timeLeft = WaitTime;
            if (triggerEvent != null)
                triggerEvent.Trigger();
        }
	}

    public void Trigger()
    {
        timeLeft = WaitTime;
    }
}
