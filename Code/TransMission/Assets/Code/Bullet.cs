using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Bullet : MonoBehaviour
{
    Vector2 velocity { get { return GetComponent<Rigidbody>().velocity.xy(); } set { GetComponent<Rigidbody>().velocity = value; } }
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
