using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
    public float RotationSpeed;	
	// Update is called once per frame
	void Update ()
    {
        if (!GameState.isGameActive) return;
        transform.rotation=Quaternion.Euler(
                                            transform.rotation.eulerAngles.x,
                                            transform.rotation.eulerAngles.y, 
                                            transform.rotation.eulerAngles.z + RotationSpeed * Time.deltaTime
                                            );
	    }
}
