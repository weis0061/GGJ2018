using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Drone : MonoBehaviour {
    public static float speed = 10f;
    Collider2D myCollider;
    // Use this for initialization
    void Start () {
        myCollider = GetComponent<Collider2D>();
    }
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(-Input.GetAxis("left"), Input.GetAxis("up"), 0).normalized * speed * Time.deltaTime;
        //Debug.Log("DT: " + Time.deltaTime + ", Inputs:" + Input.GetAxis("left") + ", " + Input.GetAxis("up"));

        var hits = new Collider2D[10];
        var collisionFilter = new ContactFilter2D();
        //collisionFilter.layerMask = 1 << gameObject.layer;
        Physics2D.OverlapCollider(myCollider, collisionFilter, hits);
        foreach (var hit in hits)
        {
            if (hit != null)
            {
                var bullet = hit.GetComponent<Bullet>();
                if (bullet != null)
                {
                    bullet.Destroy();
                    Debug.Log("bullet hit the drone");
                }
            }
        }
    }
}
