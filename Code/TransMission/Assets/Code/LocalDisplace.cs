using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Displace))]
public class LocalDisplace : MonoBehaviour {

    public float Speed;
    Displace _displace;

    void Start()
    {
        _displace = GetComponent<Displace>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameState.isGameActive) return;
        _displace.Speed = (Vector3)transform.right.xy() * Speed;
    }
}
