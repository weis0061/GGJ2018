using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Drone : MonoBehaviour {
    public float speed = 4f;
    Collider2D myCollider;
    public GameObject DeadDrone;
    public GameObject DroneRender;
    // Use this for initialization
    void Start () {
        myCollider = GetComponent<Collider2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!DeadDrone.activeInHierarchy && GameState.isGameActive)
        {
            var camerapos = Camera.main.transform.position.xy();
            var distx = Camera.main.rect.width/2;
            var disty = Camera.main.rect.height/2;
            transform.position += new Vector3(-Input.GetAxis("left"), Input.GetAxis("up"), 0).normalized * speed * Time.deltaTime;
            var x = Mathf.Clamp(transform.position.x, camerapos.x - distx, camerapos.x + distx);
            var y = Mathf.Clamp(transform.position.y, camerapos.y - disty, camerapos.y + disty);
            transform.position = new Vector3(x, y, transform.position.z);

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
                        Hit();
                    }
                }
            }
        }
    }

    private void Hit()
    {
        GameState.Singleton.DroneDeath();
        DeadDrone.SetActive(true);
        DroneRender.SetActive(false);
    }
}
