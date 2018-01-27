using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitThenFire : MonoBehaviour, ITrigger {
    public float WaitTime = 1f;
    public bool repeat = true;
    public ITrigger TriggerEvent;
    float timeLeft = 0f;

	// Use this for initialization
	void Start () {
        timeLeft = WaitTime;
	}
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            if(repeat)
                timeLeft = WaitTime;
            if (TriggerEvent != null)
                TriggerEvent.Trigger();
        }
	}

    public void Trigger()
    {
        timeLeft = WaitTime;
    }
}
