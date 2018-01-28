using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Displace))]
public class WavyDisplace : MonoBehaviour {
    public float WaveSize = 0f;
    public float WaveFrequency = 10f;
    Displace displaceComponent;
    float CurrentSlope = 0f;
    float TimeSinceBirth = 0f;
	// Use this for initialization
	void Start () {
        displaceComponent = GetComponent<Displace>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!GameState.isGameActive)  return;
        TimeSinceBirth += Time.deltaTime;
        CurrentSlope = Mathf.Sin(TimeSinceBirth*WaveFrequency) * WaveSize;
        var direction = displaceComponent.Speed.normalized;
        var dispVec = Vector3.Cross(direction, Vector3.forward) * CurrentSlope;
        transform.position += dispVec;
	}
}
