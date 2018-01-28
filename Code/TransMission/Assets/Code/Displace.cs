using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Displace : MonoBehaviour {
    public Vector2 Speed;
	
	// Update is called once per frame
	void Update ()
    {
        if (!GameState.isGameActive) return;
        transform.position += (Vector3) Speed * Time.deltaTime;
	}
}
