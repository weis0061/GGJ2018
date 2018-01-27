using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour, ITrigger {
    public GameObject BulletPrefab;
    public float BulletSpeed;

    public void Trigger()
    {
        var b = Instantiate(BulletPrefab);
        b.transform.position = transform.position;
        var bc = b.GetComponent<Bullet>();
        bc.velocity = transform.TransformDirection(Vector3.right) * BulletSpeed;
    }
}
